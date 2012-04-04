namespace FactoryFriendCore
{
    using System.Collections.Generic;

    public class FactoryFriend
    {
        private static readonly FactoryFriend Instance = new FactoryFriend();

        internal IDictionary<string, IEntityFactoryHolder> FactoryDictionary { get; set; }
        
        private FactoryFriend()
        {
            FactoryDictionary = new Dictionary<string, IEntityFactoryHolder>();   
        }

        public static EntityFactoryHolder<TEntity> AssignEntity<TEntity>()
        {
            var factoryHolder = new EntityFactoryHolder<TEntity>();
            var key = EntityKey<TEntity>();
            if (Instance.FactoryDictionary.ContainsKey(key))
            {
                Instance.FactoryDictionary[key] = factoryHolder;
            }
            else
            {
                Instance.FactoryDictionary.Add(key, factoryHolder);
            }
            return factoryHolder;
        }

        public static IEntityFactory<TEntity> Create<TEntity>()
        {
            var factoryAssignment = (EntityFactoryHolder<TEntity>) Instance.FactoryDictionary[EntityKey<TEntity>()];
            return factoryAssignment.FactoryInstance;
        }

        private static string EntityKey<TEntity>()
        {
            return typeof(TEntity).ToString();
        }
    }
}
