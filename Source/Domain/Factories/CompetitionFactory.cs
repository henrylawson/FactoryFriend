namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    using FactoryFriendCore;

    public class CompetitionFactory : IEntityFactory<Competition>
    {
        public Competition WithAllPropertiesSet()
        {
            return new Competition { Id = PseudoRandomGenerate.Integer, Name = PseudoRandomGenerate.PhraseWithWordCount(6) };
        }
    }
}