namespace FactoryFriendCore.Builders
{
    public sealed class ExtendHelper<TEntity> : HelperBase
        where TEntity : new()
    {
        private string entityFactoryAlias;

        internal ExtendHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public ExtendHelper<TEntity> WithAlias(string alias)
        {
            this.entityFactoryAlias = alias;
            return this;
        }

        public StorageHelper<TEntity> ToBe(string newAlias)
        {
            return new StorageHelper<TEntity>(this.FactoryFriend, this.entityFactoryAlias, newAlias);
        }
    }
}