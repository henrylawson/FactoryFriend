namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using NUnit.Framework;

    [TestFixture]
    public class ResultFactoryTest
    {
        private Result resultWithAllPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            this.resultWithAllPropertiesSet = new ResultFactory().CreateWithAllPropertiesSet();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(resultWithAllPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(resultWithAllPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveAMillisecondTime()
        {
            Assert.That(resultWithAllPropertiesSet.MillisecondTime, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveAnAssociatedAthlete()
        {
            Assert.That(resultWithAllPropertiesSet.Athlete, Is.Not.Null);
        }

        [Test]
        public void ShouldHaveAnAssociatedEvent()
        {
            Assert.That(resultWithAllPropertiesSet.Event, Is.Not.Null);
        }

        [Test]
        public void ShouldHaveAnAssociatedCompetition()
        {
            Assert.That(resultWithAllPropertiesSet.Competition, Is.Not.Null);
        }
    }
}
