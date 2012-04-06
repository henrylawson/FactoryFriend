namespace FactoryFriendCore.Builders
{
    public class DefineHelper<TEntity> : HelperBase
        where TEntity : new()
    {
        private string entityFactoryAlias;

        public DefineHelper(FactoryFriend factoryFriend)
            : base(factoryFriend)
        {
            //does nothing
        }

        public DefineHelper<TEntity> WithAlias(string alias)
        {
            this.entityFactoryAlias = alias;
            return this;
        }
        
        public delegate TEntity DefineAs(TEntity entity);

        public void As(DefineAs objectFunction)
        {
            this.FactoryFriend.Add(typeof(TEntity), this.entityFactoryAlias, objectFunction(new TEntity()));
        }
    }
}