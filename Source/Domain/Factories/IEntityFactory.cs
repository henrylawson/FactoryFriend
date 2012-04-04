namespace Domain.Factories
{
    public interface IEntityFactory<out TEntityType>
    {
        TEntityType CreateWithAllPropertiesSet();
    }
}