namespace FactoryFriendCore.Builders
{
    public sealed class StorageHelper<TEntity> : HelperBase
        where TEntity : new()
    {
        private readonly string entityFactoryAlias;
        private readonly string newAlias;

        internal StorageHelper(FactoryFriend factoryFriend, string entityFactoryAlias, string newAlias)
            : base(factoryFriend)
        {
            this.entityFactoryAlias = entityFactoryAlias;
            this.newAlias = newAlias;
        }

        internal StorageHelper(FactoryFriend factoryFriend, string entityFactoryAlias)
            : base(factoryFriend)
        {
            this.entityFactoryAlias = entityFactoryAlias;
        }

        public void As(FactoryFriend.FactoryFunction<TEntity> objectFunction)
        {
            if (string.IsNullOrEmpty(newAlias))
            {
                FactoryFriend.Add(entityFactoryAlias, objectFunction);
            }
            else
            {
                FactoryFriend.Add(entityFactoryAlias, newAlias, objectFunction);   
            }
        }
    }
}