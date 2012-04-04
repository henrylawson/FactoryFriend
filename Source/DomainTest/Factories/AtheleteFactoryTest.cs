namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using NUnit.Framework;

    [TestFixture]
    public class AtheleteFactoryTest
    {
        private Athelete atheleteWithAllPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            atheleteWithAllPropertiesSet = new AtheleteFactory().CreateWithAllPropertiesSet();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(atheleteWithAllPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(atheleteWithAllPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveNonNullFirstName()
        {
            Assert.That(!string.IsNullOrEmpty(atheleteWithAllPropertiesSet.FirstName));
        }

        [Test]
        public void ShouldHaveNonNullLastName()
        {
            Assert.That(!string.IsNullOrEmpty(atheleteWithAllPropertiesSet.LastName));
        }
    }
}
