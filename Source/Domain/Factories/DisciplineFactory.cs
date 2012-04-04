namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    using FactoryFriendCore;

    public class DisciplineFactory : IEntityFactory<Discipline>
    {
        public Discipline WithAllPropertiesSet()
        {
            return new Discipline
                {
                    Id = PseudoRandomGenerate.Integer,
                    Code = PseudoRandomGenerate.StringWithCharacterCount(4).ToUpper(), 
                    Name = PseudoRandomGenerate.PhraseWithWordCount(2)
                };
        }
    }
}
