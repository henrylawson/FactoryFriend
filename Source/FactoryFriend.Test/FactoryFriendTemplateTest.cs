namespace FactoryFriendCore.Test
{
    using FactoryFriendCore.Common;
    using FactoryFriendCore.Test.TestData;

    using NUnit.Framework;

    public class FactoryFriendTemplateTest
    {
        [TearDown]
        public void Destroy()
        {
            FactoryFriend.Clear();
        }

        [Test]
        public void ShouldLoadInPersonTemplateFactoryWithAliasValidProperties()
        {
            var athlete = FactoryFriend.Build<Athlete>("WithValidProperties");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendTemplateLoadedFactory()
        {
            FactoryFriend.Extend<Athlete>("WithValidProperties", "Remake").As(x =>
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
            var athlete = FactoryFriend.Build<Athlete>("WithInvalidProperties");

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToExtendExtendedTemplatorFactory()
        {
            FactoryFriend.Extend<Athlete>("WithInvalidProperties", "CustomExtendedInvalidProperties").As(x =>
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
            var athlete = FactoryFriend.Build<Athlete>("WithTwoExtendsAttributes");

            Assert.That(athlete.FirstName, Is.EqualTo("Tony"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(88));
        }

        [Test]
        public void ShouldBeAbleToOverrideTemplateFactoryWithInline()
        {
            const string EntityFactoryAlias = "WithValidProperties";
            FactoryFriend.Define<Athlete>(EntityFactoryAlias).As(x =>
                { 
                    x.FirstName = "John";
                    x.LastName = "Greg";
                    x.Id = 99;
                    return x;
                });

            var athlete = FactoryFriend.Build<Athlete>(EntityFactoryAlias);

            Assert.That(athlete.FirstName, Is.EqualTo("John"));
            Assert.That(athlete.LastName, Is.EqualTo("Greg"));
            Assert.That(athlete.Id, Is.EqualTo(99));
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void ShouldGetExceptionWhenCallingBuildOnNonExistentFactory()
        {
            FactoryFriend.Build<Athlete>("RandomAlias");
        }

        [Test]
        public void ShouldStillHaveTemplateFactoryAfterClear()
        {
            FactoryFriend.Build<Athlete>("WithValidProperties");

            FactoryFriend.Clear();

            FactoryFriend.Build<Athlete>("WithValidProperties");
            
            Assert.Pass();
        }
    }
}
