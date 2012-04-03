namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using NUnit.Framework;

    [TestFixture]
    public class EventFactoryTest
    {
        private Event eventWithPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            this.eventWithPropertiesSet = new EventFactory().CreateWithAllPropertiesSet();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(this.eventWithPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(this.eventWithPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveDistance()
        {
            Assert.That(this.eventWithPropertiesSet.Distance, Is.EqualTo(EventFactory.DefaultDistance));
        }

        [Test]
        public void ShouldHaveDiscipline()
        {
            Assert.That(this.eventWithPropertiesSet.Discipline, Is.Not.Null);
        }
    }
}
