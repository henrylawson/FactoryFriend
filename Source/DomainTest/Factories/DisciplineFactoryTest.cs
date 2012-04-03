namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using NUnit.Framework;

    [TestFixture]
    public class DisciplineFactoryTest
    {
        private Discipline discipline;

        [SetUp]
        public void SetUp()
        {
            this.discipline = DisciplineFactory.CreateDefaultWithAllPropertiesSet();
        }

        [Test]
        public void ShouldHaveNonNullId()
        {
            Assert.That(discipline.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldHaveNonZeroId()
        {
            Assert.That(discipline.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveDisciplineShortCode()
        {
            Assert.That(discipline.Code, Is.EqualTo(DisciplineFactory.DefaultCode));
        }

        [Test]
        public void ShouldHaveDisciplineName()
        {
            Assert.That(discipline.Name, Is.EqualTo(DisciplineFactory.DefaultName));
        }
    }
}
