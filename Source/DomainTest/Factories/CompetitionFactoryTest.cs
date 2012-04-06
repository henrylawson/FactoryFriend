namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using FactoryFriendCore;

    using NUnit.Framework;

    [TestFixture]
    public class CompetitionFactoryTest
    {
        private Competition competitionWithAllPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            new CompetitionFactory();
            this.competitionWithAllPropertiesSet = FactoryFriend.Build<Competition>().Default();
        }

        [TearDown]
        public void TearDown()
        {
            FactoryFriend.Clear();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(competitionWithAllPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(competitionWithAllPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveNameProperty()
        {
            Assert.That(!string.IsNullOrEmpty(competitionWithAllPropertiesSet.Name));
        }
    }
}