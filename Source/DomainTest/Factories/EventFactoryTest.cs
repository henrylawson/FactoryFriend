namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using FactoryFriendCore;

    using NUnit.Framework;

    [TestFixture]
    public class EventFactoryTest
    {
        private Event eventWithPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            new DisciplineFactory();
            new EventFactory();
            eventWithPropertiesSet = FactoryFriend.Build<Event>();
        }

        [TearDown]
        public void TearDown()
        {
            FactoryFriend.Clear();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(eventWithPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(eventWithPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveDistance()
        {
            Assert.That(eventWithPropertiesSet.Distance, Is.EqualTo(100.00m));
        }

        [Test]
        public void ShouldHaveDiscipline()
        {
            Assert.That(eventWithPropertiesSet.Discipline, Is.Not.Null);
        }
    }
}
