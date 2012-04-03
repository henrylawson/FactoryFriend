namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class DisciplineFactory : IEventFactory<Discipline>
    {
        public static string DefaultCode
        {
            get
            {
                return "FREE";
            }
        }

        public static string DefaultName
        {
            get
            {
                return "Freestyle";
            }
        }

        public Discipline CreateWithAllPropertiesSet()
        {
            return new Discipline { Id = IdHelper.GenerateInteger(), Code = DefaultCode, Name = DefaultName };
        }
    }
}
