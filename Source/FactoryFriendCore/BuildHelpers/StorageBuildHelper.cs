namespace FactoryFriendCore.BuildHelpers
{
    public sealed class StorageBuildHelper<TEntity> : BuildHelperBase
        where TEntity : new()
    {
        private readonly string entityFactoryAlias;
        private readonly string newAlias;

        internal StorageBuildHelper(FactoryFriend factoryFriend, string entityFactoryAlias, string newAlias)
            : base(factoryFriend)
        {
            this.entityFactoryAlias = entityFactoryAlias;
            this.newAlias = newAlias;
        }

        internal StorageBuildHelper(FactoryFriend factoryFriend, string entityFactoryAlias)
            : base(factoryFriend)
        {
            this.entityFactoryAlias = entityFactoryAlias;
        }

        public void As(FactoryFriend.FactoryFunction<TEntity> objectFunction)
        {
            if (string.IsNullOrEmpty(this.newAlias))
            {
                this.FactoryFriend.Add(this.entityFactoryAlias, objectFunction);
            }
            else
            {
                this.FactoryFriend.Add(this.entityFactoryAlias, this.newAlias, objectFunction);   
            }
        }
    }
}