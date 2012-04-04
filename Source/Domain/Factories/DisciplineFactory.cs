namespace Domain.Factories
{
    using Domain.Entities;
    using Domain.Factories.Helpers;

    public class DisciplineFactory : IEntityFactory<Discipline>
    {
        public Discipline CreateWithAllPropertiesSet()
        {
            return new Discipline
                {
                    Id = PseudoRandomGenerate.Integer,
                    Code = PseudoRandomGenerate.StringWithCharacterCount(4).ToUpper(), 
                    Name = PseudoRandomGenerate.PhraseWithWordCount(2)
                };
        }
    }
}
