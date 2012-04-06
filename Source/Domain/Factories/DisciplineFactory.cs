namespace Domain.Factories
{
    using Domain.Entities;

    using FactoryFriendCore;
    using FactoryFriendCore.Helpers;

    public class DisciplineFactory
    {
        public DisciplineFactory()
        {
            FactoryFriend.Define<Discipline>().As(x =>
                {
                    x.Id = PseudoRandomGenerate.Integer;
                    x.Name = PseudoRandomGenerate.PhraseWithWordCount(2);
                    x.Code = PseudoRandomGenerate.StringWithCharacterCount(4).ToUpper();
                    return x;
                });
        }
    }
}
