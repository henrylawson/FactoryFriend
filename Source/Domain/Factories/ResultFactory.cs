namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class ResultFactory : IEntityFactory<Result>
    {
        public Result CreateWithAllPropertiesSet()
        {
            return new Result
                {
                    Id = PseudoRandomGenerate.Integer,
                    MillisecondTime = PseudoRandomGenerate.Long,
                    Athlete = new AtheleteFactory().CreateWithAllPropertiesSet(),
                    Event = new EventFactory().CreateWithAllPropertiesSet(),
                    Competition = new CompetitionFactory().CreateWithAllPropertiesSet()
                };
        }
    }
}
