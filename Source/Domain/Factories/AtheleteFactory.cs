namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class AtheleteFactory : IEntityFactory<Athelete>
    {
        public Athelete CreateWithAllPropertiesSet()
        {
            return new Athelete
                {
                    Id = PseudoRandomGenerate.Integer,
                    FirstName = PseudoRandomGenerate.FirstName,
                    LastName = PseudoRandomGenerate.LastName
                };
        }
    }
}
