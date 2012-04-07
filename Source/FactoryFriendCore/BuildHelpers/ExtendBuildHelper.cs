namespace FactoryFriendCore.BuildHelpers
{
    public sealed class ExtendBuildHelper<TEntity> : BuildHelperBase
        where TEntity : new()
    {
        private string entityFactoryAlias;

        internal ExtendBuildHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public ExtendBuildHelper<TEntity> WithAlias(string alias)
        {
            this.entityFactoryAlias = alias;
            return this;
        }

        public StorageBuildHelper<TEntity> ToBe(string newAlias)
        {
            return new StorageBuildHelper<TEntity>(this.FactoryFriend, this.entityFactoryAlias, newAlias);
        }
    }
}