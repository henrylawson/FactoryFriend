namespace FactoryFriendCore.Builders
{
    public class BuildHelper<TEntity> : HelperBase
    {
        public BuildHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public TEntity WithAlias(string entityFactoryAlias)
        {
            return (TEntity)this.FactoryFriend.Get(typeof(TEntity), entityFactoryAlias);
        }

        public TEntity Default()
        {
            return this.WithAlias(string.Empty);
        }
    }
}