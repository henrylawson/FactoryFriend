namespace FactoryFriendCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using FactoryFriendCore.Builders;
    using FactoryFriendCore.Common;
    using FactoryFriendCore.Templating;

    public sealed class FactoryFriend
    {
        public delegate TEntity FactoryFunction<TEntity>(TEntity entity) where TEntity : new();
        private static readonly FactoryFriend Instance = new FactoryFriend();
        private readonly IDictionary<string, IList<object>> factories;
        private const string DefaultFactoryNotFoundMessage = "FactoryFriend could not find a default \"{0}\" entity factory";
        private const string FactoryNotFoundExceptionMessage = "FactoryFriend could not find a \"{0}\" entity factory for alias \"{1}\"";

        private FactoryFriend()
        {
            this.factories = new Dictionary<string, IList<object>>();
            this.InitializeTemplates();
        }

        private void InitializeTemplates()
        {
            var templator = new Templator(AppDomain.CurrentDomain.RelativeSearchPath, Assembly.GetExecutingAssembly().Location);
            foreach (var methodInfo in templator.GatherMethodInfosForTemplates())
            {
                Set(methodInfo.GetParameters()[0].ParameterType, methodInfo.Name, new List<object> { methodInfo });
            }
        }

        public static DefineHelper<TEntity> Define<TEntity>() where TEntity : new()
        {
            return new DefineHelper<TEntity>(Instance);
        }

        public static BuildHelper<TEntity> Build<TEntity>() where TEntity : new()
        {
            return new BuildHelper<TEntity>(Instance);
        }

        public static ExtendHelper<TEntity> Extend<TEntity>() where TEntity : new()
        {
            return new ExtendHelper<TEntity>(Instance);
        }

        public static void Clear()
        {
            Instance.factories.Clear();
            Instance.InitializeTemplates();
        }

        internal void Add<TEntity>(string entityFactoryAlias, string newEntityFactoryAlias, FactoryFunction<TEntity> objectFunction) where TEntity : new()
        {
            var oldObjectFunctionList = this.GetObjectFunctionList<TEntity>(entityFactoryAlias);
            var newObjectFunctionList = new List<object>(oldObjectFunctionList) { objectFunction };
            Set(typeof(TEntity), newEntityFactoryAlias, newObjectFunctionList);
        }

        internal void Add<TEntity>(string entityFactoryAlias, FactoryFunction<TEntity> entity) where TEntity : new()
        {
            Set(typeof(TEntity), entityFactoryAlias, new List<object> { entity });
        }

        internal TEntity Get<TEntity>(string entityFactoryAlias) where TEntity : new()
        {
            var objectFunctionList = GetObjectFunctionList<TEntity>(entityFactoryAlias);
            var entity = new TEntity();
            return objectFunctionList.Aggregate(entity, ApplyCorrectObjectFunctionToEntity);
        }

        private static TEntity ApplyCorrectObjectFunctionToEntity<TEntity>(TEntity entity, object objectFunction) where TEntity : new()
        {
            return (objectFunction is MethodInfo)
                       ? ApplyMethodInfoToEntity(entity, objectFunction)
                       : ApplyDelegateMethodToEntity(entity, objectFunction);
        }

        private static TEntity ApplyDelegateMethodToEntity<TEntity>(TEntity entity, object objectFunction) where TEntity : new()
        {
            var delegateMdethod = (FactoryFunction<TEntity>)objectFunction;
            entity = delegateMdethod(entity);
            return entity;
        }

        private static TEntity ApplyMethodInfoToEntity<TEntity>(TEntity entity, object objectFunction) where TEntity : new()
        {
            var methodInfo = (MethodInfo)objectFunction;
            entity = (TEntity)methodInfo.Invoke(Activator.CreateInstance(methodInfo.DeclaringType), new object[] { entity });
            return entity;
        }

        private void Set(Type type, string entityFactoryAlias, IList<object> newObjectFunctionList)
        {
            var key = CreateKey(type, entityFactoryAlias);
            if (factories.ContainsKey(key))
            {
                factories[key] = newObjectFunctionList;
            }
            else
            {
                factories.Add(key, newObjectFunctionList);
            }
        }

        private IEnumerable<object> GetObjectFunctionList<TEntity>(string entityFactoryAlias) where TEntity : new()
        {
            var key = CreateKey(typeof(TEntity), entityFactoryAlias);
            if (!this.factories.ContainsKey(key))
            {
                throw new EntityNotFoundException(CreateEntityNotFoundMessage(typeof(TEntity), entityFactoryAlias));
            }
            return this.factories[key];
        }

        private static string CreateKey(Type entityType, string entityFactoryAlias)
        {
            return String.Concat(entityType, entityFactoryAlias);
        }

        private static string CreateEntityNotFoundMessage(Type entityType, string entityFactoryAlias)
        {
            var message = String.IsNullOrEmpty(entityFactoryAlias) ?
                String.Format(DefaultFactoryNotFoundMessage, entityType) :
                String.Format(FactoryNotFoundExceptionMessage, entityType, entityFactoryAlias);
            return message;
        }
    }
}
