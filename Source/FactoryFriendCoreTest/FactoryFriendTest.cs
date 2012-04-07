namespace FactoryFriendCoreTest
{
    using FactoryFriendCore;
    using FactoryFriendCore.Common;
    using FactoryFriendCore.TestData;

    using FactoryFriendCoreTest.TestData;

    using NUnit.Framework;

    [TestFixture]
    public class FactoryFriendTest
    {

        private static Contact ValidAthlete(Contact entity)
        {
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            entity.Id = 22;
            return entity;
        }

        [TearDown]
        public void Destroy()
        {
            FactoryFriend.Clear();
        }

        [Test]
        public void ShouldBeAbleToDefineAFactoryUsingAs()
        {
            FactoryFriend.Define<Contact>().As(ValidAthlete);

            var athlete = FactoryFriend.Build<Contact>().Default();

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToDefineAFactoryUsingWithAlias()
        {
            FactoryFriend.Define<Contact>().WithAlias("AllPropertiesSet").As(ValidAthlete);

            var athlete = FactoryFriend.Build<Contact>().WithAlias("AllPropertiesSet");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendAFactoryEntityWithAlias()
        {
            FactoryFriend.Define<Contact>().WithAlias("AllPropertiesSet").As(ValidAthlete);
            FactoryFriend.Extend<Contact>().WithAlias("AllPropertiesSet").ToBe("NoId").As(x =>
                {
                    x.Id = 0;
                    return x;
                });

            var athlete = FactoryFriend.Build<Contact>().WithAlias("NoId");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToExtendAFactoryEntityWithoutUsingAlias()
        {
            FactoryFriend.Define<Contact>().As(ValidAthlete);
            FactoryFriend.Extend<Contact>().ToBe("NamedTom").As(x =>
                {
                    x.FirstName = "Tommy";
                    x.LastName = "Churchile";
                    return x;
                });

            var athlete = FactoryFriend.Build<Contact>().WithAlias("NamedTom");

            Assert.That(athlete.FirstName, Is.EqualTo("Tommy"));
            Assert.That(athlete.LastName, Is.EqualTo("Churchile"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException),
            ExpectedMessage = "FactoryFriend could not find a default \"FactoryFriendCoreTest.TestData.Contact\" entity factory")]
        public void ShouldBeAbleToClearFactory()
        {
            FactoryFriend.Define<Contact>().As(ValidAthlete);
            
            FactoryFriend.Clear();

            FactoryFriend.Build<Contact>().Default();
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException),
            ExpectedMessage = "FactoryFriend could not find a \"FactoryFriendCoreTest.TestData.Contact\" entity factory for alias \"Valid\"")]
        public void ShouldGetExceptionWhenCallingBuildOnNonExistentFactory()
        {
            FactoryFriend.Build<Contact>().WithAlias("Valid");
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException),
            ExpectedMessage = "FactoryFriend could not find a \"FactoryFriendCoreTest.TestData.Contact\" entity factory for alias \"Valid\"")]
        public void ShouldGetExceptionWhenCallingExtendOnNonExistentFactory()
        {
            FactoryFriend.Extend<Contact>().WithAlias("Valid").ToBe("NewFactory").As(x => x);
        }

        [Test]
        public void ShouldOverrideAliasIfExists()
        {
            FactoryFriend.Define<Contact>().As(ValidAthlete);

            FactoryFriend.Define<Contact>().As(ValidAthlete);

            Assert.Pass();
        }

        [Test]
        public void ShouldReturnAFreshInstanceEachBuild()
        {
            FactoryFriend.Define<Contact>().As(ValidAthlete);

            var firstInstance = FactoryFriend.Build<Contact>().Default();
            var secondInstance = FactoryFriend.Build<Contact>().Default();

            Assert.That(firstInstance, Is.Not.SameAs(secondInstance));
        }

        [Test]
        public void ShouldLoadInPersonWithAliasValidProperties()
        {
            var athlete = FactoryFriend.Build<Athlete>().WithAlias("ValidProperties");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendTemplateLoadedFactory()
        {
            FactoryFriend.Extend<Athlete>().WithAlias("ValidProperties").ToBe("Remake").As(x =>
                { 
                    x.Id = 99;
                    return x;
                });

            var athlete = FactoryFriend.Build<Athlete>().WithAlias("Remake");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(99));
        }
    }
}