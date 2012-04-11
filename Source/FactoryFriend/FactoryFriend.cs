namespace FactoryFriendCore
{
    using System;

    using FactoryFriendCore.BuildHelpers;

    public static class FactoryFriend
    {
        public delegate TEntity FactoryFunction<TEntity>(TEntity entity) where TEntity : new();

        private static readonly FactoryFriendInstance Instance = new FactoryFriendInstance();
        
        public static StorageBuildHelper<TEntity> Define<TEntity>(string entityFactoryAlias) where TEntity : new()
        {
            return new StorageBuildHelper<TEntity>(Instance, entityFactoryAlias);
        }

        public static StorageBuildHelper<TEntity> Define<TEntity>() where TEntity : new()
        {
            return Define<TEntity>(String.Empty);
        }

        public static TEntity Build<TEntity>(string entityFactoryAlias) where TEntity : new()
        {
            return Instance.Get(new TEntity(), entityFactoryAlias);
        }

        public static TEntity Build<TEntity>() where TEntity : new()
        {
            return Build<TEntity>(String.Empty);
        }

        public static StorageBuildHelper<TEntity> Extend<TEntity>(string originalEntityFactoryAlias, string newAlias) where TEntity : new()
        {
            return new StorageBuildHelper<TEntity>(Instance, originalEntityFactoryAlias, newAlias);
        }

        public static StorageBuildHelper<TEntity> Extend<TEntity>(string newAlias) where TEntity : new()
        {
            return new StorageBuildHelper<TEntity>(Instance, String.Empty, newAlias);
        }

        public static void Clear()
        {
            Instance.Clear();
            Instance.InitializeTemplates();
        }
    }
}
