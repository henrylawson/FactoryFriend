namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class EventFactory : IEntityFactory<Event>
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
                Id = PseudoRandomGenerate.Integer,
                Distance = DefaultDistance,
                Discipline = new DisciplineFactory().CreateWithAllPropertiesSet()
            };
        }
    }
}
