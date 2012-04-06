namespace Domain.Factories
{
    using Domain.Entities;

    using FactoryFriendCore;
    using FactoryFriendCore.Helpers;

    public class EventFactory
    {
        public EventFactory()
        {
            FactoryFriend.Define<Event>().As(x =>
                { 
                    x.Id = PseudoRandomGenerate.Integer;
                    x.Discipline = FactoryFriend.Build<Discipline>().Default();
                    x.Distance = 100.00m;
                    return x;
                });
        }
    }
}
