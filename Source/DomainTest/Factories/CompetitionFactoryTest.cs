﻿namespace DomainTest.Factories
{
    using Domain.Entities;
    using Domain.Factories;

    using NUnit.Framework;

    [TestFixture]
    public class CompetitionFactoryTest
    {
        private Competition competitionWithAllPropertiesSet;

        [SetUp]
        public void SetUp()
        {
            this.competitionWithAllPropertiesSet = new CompetitionFactory().CreateWithAllPropertiesSet();
        }

        [Test]
        public void ShouldNotHaveNullId()
        {
            Assert.That(this.competitionWithAllPropertiesSet.Id, Is.Not.Null);
        }

        [Test]
        public void ShouldNotHaveZeroId()
        {
            Assert.That(this.competitionWithAllPropertiesSet.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldHaveNameProperty()
        {
            Assert.That(this.competitionWithAllPropertiesSet.Name, Is.EqualTo(CompetitionFactory.DefaultName));
        }
    }
}