namespace DomainTest.Entities
{
    using System;

    using Domain.Entities;

    using NUnit.Framework;

    [TestFixture]
    public class CompetitionTest
    {
        [Test]
        public void ShouldNotBeEqualToNull()
        {
            var competition = new Competition();
            Assert.That(competition, Is.Not.EqualTo(null));
        }

        [Test]
        public void ShouldNotBeEqualToOtherObjectType()
        {
            var competition = new Competition();
            Assert.That(competition, Is.Not.EqualTo("Hello"));
        }

        [Test]
        public void ShouldBeEqualToItself()
        {
            var competition = new Competition();
            Assert.That(competition, Is.EqualTo(competition));
        }

        [Test]
        public void ShouldBeEqualWhenNameAreEqual()
        {
            var firstCompetition = new Competition { Name = "Comp1" };
            var secondCompetition = new Competition { Name = "Comp1" };
            Assert.That(firstCompetition, Is.EqualTo(secondCompetition));
        }

        [Test]
        public void ShouldHaveSameHashCodeWhenPropertiesAreEqual()
        {
            var competition = new Competition { Name = "Comp1" };
            var competitionWithSameName = new Competition { Name = "Comp1" };
            Assert.That(competition.GetHashCode(), Is.EqualTo(competitionWithSameName.GetHashCode()));
        }

        [Test]
        public void ShouldHaveZeroForHashCodeWhenNotNamed()
        {
            var competition = new Competition();
            Assert.That(competition.GetHashCode(), Is.EqualTo(0));
        }
    }
}
