namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class CompetitionFactory : IEventFactory<Competition>
    {
        public static string DefaultName
        {
            get
            {
                return "Brisbane Age & Open 2010";
            }
        }

        public Competition CreateWithAllPropertiesSet()
        {
            return new Competition { Id = IdHelper.GenerateInteger(), Name = DefaultName };
        }
    }
}