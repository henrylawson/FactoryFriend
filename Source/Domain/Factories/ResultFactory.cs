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
                    x.Athlete = FactoryFriend.Build<Athlete>();
                    x.Competition = FactoryFriend.Build<Competition>();
                    x.Event = FactoryFriend.Build<Event>();
                    return x;
                });
        }
    }
}
