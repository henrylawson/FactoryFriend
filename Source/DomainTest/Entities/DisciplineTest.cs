namespace DomainTest.Entities
{
    using Domain.Entities;

    using NUnit.Framework;

    [TestFixture]
    public class DisciplineTest
    {
        [Test]
        public void ShouldNotBeEqualToNull()
        {
            var discipline = new Discipline();
            Assert.That(discipline, Is.Not.EqualTo(null));
        }

        [Test]
        public void ShouldNotBeEqualToOtherObjectType()
        {
            var discipline = new Discipline();
            Assert.That(discipline, Is.Not.EqualTo("Hello"));
        }

        [Test]
        public void ShouldBeEqualToItself()
        {
            var discipline = new Discipline();
            Assert.That(discipline, Is.EqualTo(discipline));
        }

        [Test]
        public void ShouldBeEqualWhenNameAndCodeAreEqual()
        {
            var firstDiscipline = new Discipline { Name = "Free", Code = "FR" };
            var secondDiscipline = new Discipline { Name = "Free", Code = "FR" };
            Assert.That(firstDiscipline, Is.EqualTo(secondDiscipline));
        }

        [Test]
        public void ShouldHaveSameHashCodeWhenPropertiesAreEqual()
        {
            var discipline = new Discipline { Name = "Free", Code = "FR" };
            var disciplineWithSameName = new Discipline { Name = "Free", Code = "FR" };
            Assert.That(discipline.GetHashCode(), Is.EqualTo(disciplineWithSameName.GetHashCode()));
        }

        [Test]
        public void ShouldHaveZeroForHashCodeWhenNotNamed()
        {
            var discipline = new Discipline();
            Assert.That(discipline.GetHashCode(), Is.EqualTo(0));
        }
    }
}
