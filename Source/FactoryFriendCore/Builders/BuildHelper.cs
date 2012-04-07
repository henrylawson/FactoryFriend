namespace FactoryFriendCore.Builders
{
    public sealed class BuildHelper<TEntity> : HelperBase
        where TEntity : new()
    {
        internal BuildHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public TEntity WithAlias(string entityFactoryAlias)
        {
            return this.FactoryFriend.Get<TEntity>(entityFactoryAlias);
        }

        public TEntity Default()
        {
            return this.WithAlias(string.Empty);
        }
    }
}