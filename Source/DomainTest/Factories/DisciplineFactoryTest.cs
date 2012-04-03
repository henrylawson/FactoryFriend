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
            Assert.That(this.disciplineWithAllPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldHaveNonZeroId()
        {
            Assert.That(this.disciplineWithAllPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveDisciplineShortCode()
        {
            Assert.That(this.disciplineWithAllPropertiesSet.Code, Is.EqualTo(DisciplineFactory.DefaultCode));
        }

        [Test]
        public void ShouldHaveDisciplineName()
        {
            Assert.That(this.disciplineWithAllPropertiesSet.Name, Is.EqualTo(DisciplineFactory.DefaultName));
        }
    }
}
