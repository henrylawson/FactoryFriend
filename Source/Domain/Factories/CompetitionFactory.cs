namespace Domain.Factories
{
    using Domain.Entities;

    using FactoryFriendCore;
    using FactoryFriendCore.Helpers;

    public class CompetitionFactory
    {
        public CompetitionFactory()
        {
            FactoryFriend.Define<Competition>().As(x =>
                { 
                    x.Id = PseudoRandomGenerate.Integer;
                    x.Name = PseudoRandomGenerate.PhraseWithWordCount(6);
                    return x;
                });
        }
    }
}