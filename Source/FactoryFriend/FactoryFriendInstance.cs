namespace FactoryFriendCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using FactoryFriendCore.Attributes;
    using FactoryFriendCore.Common;
    using FactoryFriendCore.Templating;

    internal sealed class FactoryFriendInstance
    {
        private readonly IDictionary<string, IList<object>> factories;
        
        private const string DefaultFactoryNotFoundMessage = "FactoryFriend could not find a default \"{0}\" entity factory";
        private const string FactoryNotFoundExceptionMessage = "FactoryFriend could not find a \"{0}\" entity factory for alias \"{1}\"";

        internal FactoryFriendInstance()
        {
            factories = new Dictionary<string, IList<object>>();
            InitializeTemplates();
        }

        internal void InitializeTemplates()
        {
            var templator = new Templator(AppDomain.CurrentDomain.GetAssemblies());
            foreach (var methodInfo in templator.GatherMethodInfosForTemplates())
            {
                Set(methodInfo.GetParameters()[0].ParameterType, methodInfo.Name, new List<object> { methodInfo });
            }
        }

        internal void Add<TEntity>(string entityFactoryAlias, string newEntityFactoryAlias, FactoryFriend.FactoryFunction<TEntity> objectFunction) where TEntity : new()
        {
            var oldObjectFunctionList = GetObjectFunctionList<TEntity>(entityFactoryAlias);
            var newObjectFunctionList = new List<object>(oldObjectFunctionList) { objectFunction };
            Set(typeof(TEntity), newEntityFactoryAlias, newObjectFunctionList);
        }

        internal void Add<TEntity>(string entityFactoryAlias, FactoryFriend.FactoryFunction<TEntity> entity) where TEntity : new()
        {
            Set(typeof(TEntity), entityFactoryAlias, new List<object> { entity });
        }

        internal TEntity Get<TEntity>(TEntity entity, string entityFactoryAlias) where TEntity : new()
        {
            var objectFunctionList = GetObjectFunctionList<TEntity>(entityFactoryAlias);
            return objectFunctionList.Aggregate(entity, ApplyCorrectObjectFunctionToEntity);
        }

        internal void Clear()
        {
            factories.Clear();
        }

        private TEntity ApplyCorrectObjectFunctionToEntity<TEntity>(TEntity entity, object objectFunction) where TEntity : new()
        {
            return (objectFunction is MethodInfo)
                       ? ApplyMethodInfoToEntity(entity, objectFunction)
                       : ApplyDelegateMethodToEntity(entity, objectFunction);
        }

        private static TEntity ApplyDelegateMethodToEntity<TEntity>(TEntity entity, object objectFunction) where TEntity : new()
        {
            var delegateMdethod = (FactoryFriend.FactoryFunction<TEntity>)objectFunction;
            entity = delegateMdethod(entity);
            return entity;
        }

        private TEntity ApplyMethodInfoToEntity<TEntity>(TEntity entity, object objectFunction) where TEntity : new()
        {
            var methodInfo = (MethodInfo)objectFunction;
            var entityFactoryAliass = RetrieveFactoriesDefinedInExtendsAttributesFor(methodInfo);
            entity = ApplyMethodsDefinedInExtendsAttribute(entity, entityFactoryAliass);
            entity = (TEntity)methodInfo.Invoke(Activator.CreateInstance(methodInfo.DeclaringType), new object[] { entity });
            return entity;
        }

        private static IEnumerable<string> RetrieveFactoriesDefinedInExtendsAttributesFor(MemberInfo memberInfo)
        {
            var extendsAttribute = Attribute.GetCustomAttribute(memberInfo, typeof(Extends)) as Extends;
            return extendsAttribute == null ? new string[0] : extendsAttribute.EntityFactoryAliass;
        }

        private TEntity ApplyMethodsDefinedInExtendsAttribute<TEntity>(TEntity entity, IEnumerable<string> entityFactoryAliass) where TEntity : new()
        {
            return entityFactoryAliass.Aggregate(entity, Get);
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
            if (!factories.ContainsKey(key))
            {
                throw new EntityNotFoundException(CreateEntityNotFoundMessage(typeof(TEntity), entityFactoryAlias));
            }
            return factories[key];
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
