namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using FactoryFriendCore;

    using NUnit.Framework;

    [TestFixture]
    public class AthleteFactoryTest
    {
        private Athlete athleteWithAllPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            new AthleteFactory();
            athleteWithAllPropertiesSet = FactoryFriend.Build<Athlete>().Default();
        }

        [TearDown]
        public void TearDown()
        {
            FactoryFriend.Clear();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(athleteWithAllPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(athleteWithAllPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveNonNullFirstName()
        {
            Assert.That(!string.IsNullOrEmpty(athleteWithAllPropertiesSet.FirstName));
        }

        [Test]
        public void ShouldHaveNonNullLastName()
        {
            Assert.That(!string.IsNullOrEmpty(athleteWithAllPropertiesSet.LastName));
        }
    }
}
