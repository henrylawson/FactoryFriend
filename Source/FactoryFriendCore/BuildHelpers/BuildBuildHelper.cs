namespace FactoryFriendCore.BuildHelpers
{
    public sealed class BuildBuildHelper<TEntity> : BuildHelperBase
        where TEntity : new()
    {
        internal BuildBuildHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public TEntity WithAlias(string entityFactoryAlias)
        {
            return FactoryFriend.Get<TEntity>(entityFactoryAlias);
        }

        public TEntity Default()
        {
            return WithAlias(string.Empty);
        }
    }
}