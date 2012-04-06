namespace FactoryFriendCore.Builders
{
    public class ExtendHelper<TEntity> : HelperBase
    {
        private string entityFactoryAlias;

        public ExtendHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public ExtendHelper<TEntity> WithAlias(string alias)
        {
            this.entityFactoryAlias = alias;
            return this;
        }

        public ExtendStorageHelper<TEntity> ToBe(string newAlias)
        {
            return new ExtendStorageHelper<TEntity>(this.FactoryFriend, this.entityFactoryAlias, newAlias);
        }
    }
}