namespace FactoryFriendCore.BuildHelpers
{
    public sealed class DefineBuildHelper<TEntity> : BuildHelperBase
        where TEntity : new()
    {
        internal DefineBuildHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public StorageBuildHelper<TEntity> WithAlias(string alias)
        {
            return new StorageBuildHelper<TEntity>(this.FactoryFriend, alias);
        }
        
        public void As(FactoryFriend.FactoryFunction<TEntity> objectFunction)
        {
            new StorageBuildHelper<TEntity>(this.FactoryFriend, string.Empty).As(objectFunction);
        }
    }
}