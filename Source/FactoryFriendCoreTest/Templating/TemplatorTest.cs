namespace FactoryFriendCoreTest.Templating
{
    using System;
    using System.IO;
    using System.Reflection;

    using FactoryFriendCore;
    using FactoryFriendCore.Templating;
    using FactoryFriendCore.TestData;

    using NUnit.Framework;

    [TestFixture]
    public class TemplatorTest
    {
        private Templator templator;

        [SetUp]
        public void SetUp()
        {
            templator = new Templator(AppDomain.CurrentDomain.RelativeSearchPath, Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public void ShouldBeAbleToGetAssembliesPathFromCurrentDomain()
        {
            const string CurrentDomainSearchPath = "AppDomain.CurrentDomain.RelativeSearchPath";
            var executingAssemblyLocation = string.Empty;

            templator = new Templator(CurrentDomainSearchPath, executingAssemblyLocation);

            Assert.Pass("Should not throw an exception, current domain search path is not empty");
        }

        [Test]
        public void ShouldBeAbleToGetAssembliesPathFromAssemblyWhenCurrentDomainEmpty()
        {
            var currentDomainSearchPath = string.Empty;
            var executingAssemblyLocation = Assembly.GetExecutingAssembly().Location;

            templator = new Templator(currentDomainSearchPath, executingAssemblyLocation);

            Assert.Pass("Should not throw an exception, executing assembly location should exist");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Assembly location folder is null or empty")]
        public void ShouldThrowExeceptionWhenBothAreNull()
        {
            var currentDomainSearchPath = string.Empty;
            const string ExecutingAssemblyLocation = "Non-exitent path";

            templator = new Templator(currentDomainSearchPath, ExecutingAssemblyLocation);
        }

        [Test]
        public void ShouldFindTwoTemplatesInAssemblies()
        {
            var templateTypes = templator.GatherTemplates();

            Assert.That(templateTypes.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldFindThreeMethodInfosDefinedInTheTwoTemplates()
        {
            var templateTypes = templator.GatherMethodInfosForTemplates();

            Assert.That(templateTypes.Count, Is.EqualTo(3));
        }
    }
}
