namespace DomainTest.Entities
{
    using Domain.Entities;

    using NUnit.Framework;

    [TestFixture]
    public class CompetitionTest
    {
        [Test]
        public void ShouldHaveNameProperty()
        {
            var competition = new Competition { Name = "Brisbane State Championships" };
            Assert.That(competition.Name, Is.EqualTo(competition.Name));
        }
    }
}