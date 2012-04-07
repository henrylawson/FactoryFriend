namespace FactoryFriendCore.Builders
{
    public sealed class DefineHelper<TEntity> : HelperBase
        where TEntity : new()
    {
        internal DefineHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public StorageHelper<TEntity> WithAlias(string alias)
        {
            return new StorageHelper<TEntity>(FactoryFriend, alias);
        }
        
        public void As(FactoryFriend.FactoryFunction<TEntity> objectFunction)
        {
            new StorageHelper<TEntity>(FactoryFriend, string.Empty).As(objectFunction);
        }
    }
}