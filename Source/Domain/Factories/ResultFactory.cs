namespace Domain.Factories
{
    using Domain.Entities;

    using FactoryFriendCore;
    using FactoryFriendCore.Helpers;

    public class ResultFactory
    {
        public ResultFactory()
        {
            FactoryFriend.Define<Result>().As(x =>
                { 
                    x.Id = PseudoRandomGenerate.Integer;
                    x.MillisecondTime = PseudoRandomGenerate.Long;
                    x.Athlete = FactoryFriend.Build<Athlete>().Default();
                    x.Competition = FactoryFriend.Build<Competition>().Default();
                    x.Event = FactoryFriend.Build<Event>().Default();
                    return x;
                });
        }
    }
}
