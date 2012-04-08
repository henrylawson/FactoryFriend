namespace FactoryFriendCore.BuildHelpers
{
    public sealed class StorageBuildHelper<TEntity>
        where TEntity : new()
    {
        private readonly string entityFactoryAlias;
        private readonly string newAlias;
        private readonly FactoryFriendInstance factoryFriend;

        internal StorageBuildHelper(FactoryFriendInstance factoryFriend, string entityFactoryAlias, string newAlias)
        {
            this.factoryFriend = factoryFriend;
            this.entityFactoryAlias = entityFactoryAlias;
            this.newAlias = newAlias;
        }

        internal StorageBuildHelper(FactoryFriendInstance factoryFriend, string entityFactoryAlias)
            : this(factoryFriend, entityFactoryAlias, string.Empty)
        {
        }

        public void As(FactoryFriend.FactoryFunction<TEntity> objectFunction)
        {
            if (string.IsNullOrEmpty(newAlias))
            {
                factoryFriend.Add(entityFactoryAlias, objectFunction);
            }
            else
            {
                factoryFriend.Add(entityFactoryAlias, newAlias, objectFunction);   
            }
        }
    }
}