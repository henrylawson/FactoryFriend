namespace FactoryFriendCore.Test
{
    using FactoryFriendCore;
    using FactoryFriendCore.Common;
    using FactoryFriendCore.Test.TestData;

    using NUnit.Framework;

    [TestFixture]
    public class FactoryFriendInlineNotationTest
    {
        private static Contact WithValidProperties(Contact entity)
        {
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            entity.Id = 22;
            return entity;
        }

        [Test]
        public void ShouldBeAbleToDefineAFactoryUsingAs()
        {
            FactoryFriend.Define<Contact>().As(WithValidProperties);

            var athlete = FactoryFriend.Build<Contact>();

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToDefineAFactoryUsingAProvidedAlias()
        {
            const string EntityFactoryAlias = "WithValidProperties";
            FactoryFriend.Define<Contact>(EntityFactoryAlias).As(WithValidProperties);

            var athlete = FactoryFriend.Build<Contact>(EntityFactoryAlias);

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendDefaultFactoryUsingAs()
        {
            FactoryFriend.Define<Contact>().As(WithValidProperties);
            const string EntityFactoryAlias = "NamedTom";
            FactoryFriend.Extend<Contact>(EntityFactoryAlias).As(x =>
            {
                x.FirstName = "Tommy";
                x.LastName = "Churchile";
                return x;
            });

            var athlete = FactoryFriend.Build<Contact>(EntityFactoryAlias);

            Assert.That(athlete.FirstName, Is.EqualTo("Tommy"));
            Assert.That(athlete.LastName, Is.EqualTo("Churchile"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendAFactoryWithAnAlias()
        {
            const string EntityFactoryAlias = "WithValidProperties";
            const string NewEntityFactoryAlias = "NoId";
            FactoryFriend.Define<Contact>(EntityFactoryAlias).As(WithValidProperties);
            FactoryFriend.Extend<Contact>(EntityFactoryAlias, NewEntityFactoryAlias).As(x =>
                {
                    x.Id = 0;
                    return x;
                });

            var athlete = FactoryFriend.Build<Contact>(NewEntityFactoryAlias);

            Assert.That(athlete.FirstName, Is.EqualTo("Joe"));
            Assert.That(athlete.LastName, Is.EqualTo("Bloggs"));
            Assert.That(athlete.Id, Is.EqualTo(0));
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void ShouldBeAbleToClearFactory()
        {
            FactoryFriend.Define<Contact>().As(WithValidProperties);
            
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
        public void ShouldOverrideFactoryWithNoErrorIfItExists()
        {
            FactoryFriend.Define<Contact>().As(WithValidProperties);

            FactoryFriend.Define<Contact>().As(WithValidProperties);

            Assert.Pass();
        }

        [Test]
        public void ShouldReturnAFreshInstanceEachBuild()
        {
            FactoryFriend.Define<Contact>().As(WithValidProperties);

            var firstInstance = FactoryFriend.Build<Contact>();
            var secondInstance = FactoryFriend.Build<Contact>();

            Assert.That(firstInstance, Is.Not.SameAs(secondInstance));
        }
    }
}