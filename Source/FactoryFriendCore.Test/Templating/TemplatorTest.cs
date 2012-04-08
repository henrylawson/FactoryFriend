namespace FactoryFriendCore.Test.Templating
{
    using System;

    using FactoryFriendCore.Templating;

    using NUnit.Framework;

    [TestFixture]
    public class TemplatorTest
    {
        private Templator templator;

        [SetUp]
        public void SetUp()
        {
            templator = new Templator(AppDomain.CurrentDomain.GetAssemblies());
        }

        [Test]
        public void ShouldFindFourTemplatesInAssemblies()
        {
            var templateTypes = templator.GatherTemplates();

            Assert.That(templateTypes.Count, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldFindFourMethodInfosDefinedInTheTwoTemplates()
        {
            var templateTypes = templator.GatherMethodInfosForTemplates();

            Assert.That(templateTypes.Count, Is.GreaterThan(0));
        }
    }
}
