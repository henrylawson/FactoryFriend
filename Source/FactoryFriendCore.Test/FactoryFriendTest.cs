namespace FactoryFriendCore.Test
{
    using FactoryFriendCore;
    using FactoryFriendCore.Common;
    using FactoryFriendCore.Test.TestData;

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

            var athlete = FactoryFriend.Build<Contact>();

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToDefineAFactoryUsingWithAlias()
        {
            FactoryFriend.Define<Contact>("AllPropertiesSet").As(ValidAthlete);

            var athlete = FactoryFriend.Build<Contact>("AllPropertiesSet");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendAFactoryEntityWithAlias()
        {
            FactoryFriend.Define<Contact>("AllPropertiesSet").As(ValidAthlete);
            FactoryFriend.Extend<Contact>("AllPropertiesSet", "NoId").As(x =>
                {
                    x.Id = 0;
                    return x;
                });

            var athlete = FactoryFriend.Build<Contact>("NoId");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToExtendAFactoryEntityWithoutUsingAlias()
        {
            FactoryFriend.Define<Contact>().As(ValidAthlete);
            FactoryFriend.Extend<Contact>("NamedTom").As(x =>
                {
                    x.FirstName = "Tommy";
                    x.LastName = "Churchile";
                    return x;
                });

            var athlete = FactoryFriend.Build<Contact>("NamedTom");

            Assert.That(athlete.FirstName, Is.EqualTo("Tommy"));
            Assert.That(athlete.LastName, Is.EqualTo("Churchile"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void ShouldBeAbleToClearFactory()
        {
            FactoryFriend.Define<Contact>().As(ValidAthlete);
            
            FactoryFriend.Clear();

            FactoryFriend.Build<Contact>();
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void ShouldGetExceptionWhenCallingBuildOnNonExistentFactory()
        {
            FactoryFriend.Build<Contact>("Valid");
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void ShouldGetExceptionWhenCallingExtendOnNonExistentFactory()
        {
            FactoryFriend.Extend<Contact>("Valid", "NewFactory").As(x => x);
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

            var firstInstance = FactoryFriend.Build<Contact>();
            var secondInstance = FactoryFriend.Build<Contact>();

            Assert.That(firstInstance, Is.Not.SameAs(secondInstance));
        }

        [Test]
        public void ShouldLoadInPersonTemplateFactoryWithAliasValidProperties()
        {
            var athlete = FactoryFriend.Build<Athlete>("ValidProperties");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendTemplateLoadedFactory()
        {
            FactoryFriend.Extend<Athlete>("ValidProperties", "Remake").As(x =>
                { 
                    x.Id = 99;
                    return x;
                });

            var athlete = FactoryFriend.Build<Athlete>("Remake");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(99));
        }

        [Test]
        public void ShouldHavePropertiesExtendedByTemplator()
        {
            var athlete = FactoryFriend.Build<Athlete>("InvalidProperties");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToExtendExtendedTemplatorFactory()
        {
            FactoryFriend.Extend<Athlete>("InvalidProperties", "CustomExtendedInvalidProperties").As(x =>
                { 
                    x.LastName = "Ralf";
                    return x;
                });

            var athlete = FactoryFriend.Build<Athlete>("CustomExtendedInvalidProperties");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Ralf"));
            Assert.That(athlete.Id, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToDeclareMultipleExtensionsInTemplate()
        {
            var athlete = FactoryFriend.Build<Athlete>("HasTwoExtends");

            Assert.That(athlete.FirstName, Is.EqualTo("Tony"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(88));
        }
    }
}