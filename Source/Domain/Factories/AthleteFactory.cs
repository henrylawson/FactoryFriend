namespace Domain.Factories
{
    using Domain.Entities;

    using FactoryFriendCore;
    using FactoryFriendCore.Helpers;

    public class AthleteFactory
    {
        public AthleteFactory()
        {
            FactoryFriend.Define<Athlete>().As(x =>
                {
                    x.Id = PseudoRandomGenerate.Integer;
                    x.FirstName = PseudoRandomGenerate.FirstName;
                    x.LastName = PseudoRandomGenerate.LastName;
                    return x;
                });
        }
    }
}
