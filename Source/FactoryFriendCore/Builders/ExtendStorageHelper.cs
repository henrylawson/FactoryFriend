namespace FactoryFriendCore.Builders
{
    public class ExtendStorageHelper<TEntity> : HelperBase
    {
        private readonly string entityFactoryAlias;
        private readonly string newAlias;

        public ExtendStorageHelper(FactoryFriend factoryFriend, string entityFactoryAlias, string newAlias)
            : base(factoryFriend)
        {
            this.entityFactoryAlias = entityFactoryAlias;
            this.newAlias = newAlias;
        }

        public delegate TEntity DefineAs(TEntity entity);

        public void As(DefineAs objectFunction)
        {
            var entity = (TEntity)this.FactoryFriend.Get(typeof(TEntity), this.entityFactoryAlias);
            this.FactoryFriend.Add(typeof(TEntity), this.newAlias, objectFunction(entity));
        }
    }
}