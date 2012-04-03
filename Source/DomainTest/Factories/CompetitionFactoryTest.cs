namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using NUnit.Framework;

    [TestFixture]
    public class CompetitionFactoryTest
    {
        private Competition competitionWithSetProperties;

        [SetUp]
        public void SetUp()
        {
            this.competitionWithSetProperties = CompetitionFactory.CreateDefaultWithSetProperties();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(this.competitionWithSetProperties.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(this.competitionWithSetProperties.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveNameProperty()
        {
            Assert.That(this.competitionWithSetProperties.Name, Is.EqualTo(CompetitionFactory.DefaultName));
        }
    }
}