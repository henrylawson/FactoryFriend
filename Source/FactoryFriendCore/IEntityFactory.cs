namespace FactoryFriendCore
{
    public interface IEntityFactory<out TEntityType>
    {
        TEntityType WithAllPropertiesSet();
    }
}