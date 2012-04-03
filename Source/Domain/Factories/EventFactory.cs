namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class EventFactory : IEventFactory<Event>
    {
        public static decimal DefaultDistance
        {
            get
            {
                return 100.00m;
            }
        }

        public Event CreateWithAllPropertiesSet()
        {
            return new Event
            {
                Id = IdHelper.GenerateInteger(),
                Distance = DefaultDistance,
                Discipline = new DisciplineFactory().CreateWithAllPropertiesSet()
            };
        }
    }
}
