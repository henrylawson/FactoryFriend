namespace FactoryFriendCore
{
    using System;

    public class EntityFactoryHolder<TEntity> : IEntityFactoryHolder
    {
        internal IEntityFactory<TEntity> FactoryInstance { get; private set; }

        internal Type FactoryInstanceType { get; private set; }

        public void Factory<TEntityFactory>() where TEntityFactory : IEntityFactory<TEntity>, new()
        {
            this.FactoryInstance = new TEntityFactory();
            this.FactoryInstanceType = typeof(TEntityFactory);
        }
    }
}