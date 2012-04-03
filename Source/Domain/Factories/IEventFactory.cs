namespace Domain.Factories
{
    using Domain.Entities;

    public interface IEventFactory<out TEntityType>
    {
        TEntityType CreateWithAllPropertiesSet();
    }
}