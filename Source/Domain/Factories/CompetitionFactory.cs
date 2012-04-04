namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class CompetitionFactory : IEntityFactory<Competition>
    {
        public Competition CreateWithAllPropertiesSet()
        {
            return new Competition { Id = PseudoRandomGenerate.Integer, Name = PseudoRandomGenerate.PhraseWithWordCount(6) };
        }
    }
}