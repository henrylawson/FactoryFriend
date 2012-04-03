namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public static class CompetitionFactory
    {
        public static string DefaultName
        {
            get
            {
                return "Brisbane Age & Open 2010";
            }
        }

        public static Competition CreateDefaultWithSetProperties()
        {
            return new Competition { Id = IdHelper.GenerateInteger(), Name = DefaultName };
        }
    }
}