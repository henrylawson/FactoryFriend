namespace FactoryFriendCore
{
    using System;
    using System.Collections.Generic;

    using FactoryFriendCore.Builders;

    public class FactoryFriend
    {
        private static readonly FactoryFriend Instance = new FactoryFriend();

        private readonly IDictionary<string, object> factories;

        private const string DefaultFactoryNotFoundMessage = "FactoryFriend could not find a default \"{0}\" entity factory";

        private const string FactoryNotFoundExceptionMessage = "FactoryFriend could not find a \"{0}\" entity factory for alias \"{1}\"";

        private FactoryFriend()
        {
            this.factories = new Dictionary<string, object>();
        }

        private static string CreateKey(Type entityType, string entityFactoryAlias)
        {
            return string.Concat(entityType, entityFactoryAlias);
        }

        internal void Add(Type entityType, string entityFactoryAlias, object entity)
        {
            var key = CreateKey(entityType, entityFactoryAlias);
            if (this.factories.ContainsKey(key))
            {
                this.factories[key] = entity;
            }
            else
            {
                this.factories.Add(key, entity);
            }
        }

        internal object Get(Type entityType, string entityFactoryAlias)
        {
            var key = CreateKey(entityType, entityFactoryAlias);
            if (!this.factories.ContainsKey(key))
            {
                throw new EntityNotFoundException(
                    CreateEntityNotFoundExceptionMessage(entityType, entityFactoryAlias));
            }
            return this.factories[key];
        }

        private static string CreateEntityNotFoundExceptionMessage(Type entityType, string entityFactoryAlias)
        {
            string message = string.IsNullOrEmpty(entityFactoryAlias) ? 
                string.Format(DefaultFactoryNotFoundMessage, entityType) : 
                string.Format(FactoryNotFoundExceptionMessage, entityType, entityFactoryAlias);
            return message;
        }

        public static DefineHelper<TEntity> Define<TEntity>() where TEntity : new()
        {
            return new DefineHelper<TEntity>(Instance);
        }

        public static BuildHelper<TEntity> Build<TEntity>()
        {
            return new BuildHelper<TEntity>(Instance);
        }

        public static ExtendHelper<TEntity> Extend<TEntity>()
        {
            return new ExtendHelper<TEntity>(Instance);
        }

        public static void Clear()
        {
            Instance.factories.Clear();
        }
    }
}
