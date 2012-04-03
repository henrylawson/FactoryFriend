namespace Domain.Factories
{
    public interface IEventFactory<out TEntityType>
    {
        TEntityType CreateWithAllPropertiesSet();
    }
}