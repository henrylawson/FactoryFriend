namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    using FactoryFriendCore;

    public class ResultFactory : IEntityFactory<Result>
    {
        public Result WithAllPropertiesSet()
        {
            return new Result
                {
                    Id = PseudoRandomGenerate.Integer,
                    MillisecondTime = PseudoRandomGenerate.Long,
                    Athlete = new AthleteFactory().WithAllPropertiesSet(),
                    Event = new EventFactory().WithAllPropertiesSet(),
                    Competition = new CompetitionFactory().WithAllPropertiesSet()
                };
        }
    }
}
