namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    using FactoryFriendCore;

    public class AthleteFactory : IEntityFactory<Athlete>
    {
        public Athlete WithAllPropertiesSet()
        {
            return new Athlete
                {
                    Id = PseudoRandomGenerate.Integer,
                    FirstName = PseudoRandomGenerate.FirstName,
                    LastName = PseudoRandomGenerate.LastName
                };
        }
    }
}
