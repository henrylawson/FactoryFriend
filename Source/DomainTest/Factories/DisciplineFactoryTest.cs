namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using NUnit.Framework;

    [TestFixture]
    public class DisciplineFactoryTest
    {
        private Discipline disciplineWithAllPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            this.disciplineWithAllPropertiesSet = new DisciplineFactory().CreateWithAllPropertiesSet();
        }

        [Test]
        public void ShouldHaveNonNullId()
        {
            Assert.That(disciplineWithAllPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldHaveNonZeroId()
        {
            Assert.That(disciplineWithAllPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveDisciplineShortCode()
        {
            Assert.That(!string.IsNullOrEmpty(disciplineWithAllPropertiesSet.Code));
        }

        [Test]
        public void ShouldHaveDisciplineName()
        {
            Assert.That(!string.IsNullOrEmpty(disciplineWithAllPropertiesSet.Name));
        }
    }
}
