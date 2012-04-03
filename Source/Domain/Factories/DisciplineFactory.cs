namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class DisciplineFactory
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

        public static Discipline CreateDefaultWithAllPropertiesSet()
        {
            return new Discipline { Id = IdHelper.GenerateInteger(), Code = DefaultCode, Name = DefaultName };
        }
    }
}
