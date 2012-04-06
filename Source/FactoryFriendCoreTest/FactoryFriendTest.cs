namespace FactoryFriendCoreTest
{
    using Domain.Entities;

    using FactoryFriendCore;

    using NUnit.Framework;

    [TestFixture]
    public class FactoryFriendTest
    {
        private Athlete ValidAthlete(Athlete entity)
        {
            entity.FirstName = "Henry";
            entity.LastName = "Lawson";
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
            FactoryFriend.Define<Athlete>().As(ValidAthlete);

            var athlete = FactoryFriend.Build<Athlete>().Default();

            Assert.That(athlete.FirstName, Is.EqualTo("Henry"));
            Assert.That(athlete.LastName, Is.EqualTo("Lawson"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToDefineAFactoryUsingWithAlias()
        {
            FactoryFriend.Define<Athlete>().WithAlias("AllPropertiesSet").As(ValidAthlete);

            var athlete = FactoryFriend.Build<Athlete>().WithAlias("AllPropertiesSet");

            Assert.That(athlete.FirstName, Is.EqualTo("Henry"));
            Assert.That(athlete.LastName, Is.EqualTo("Lawson"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        public void ShouldBeAbleToExtendAFactoryEntityWithAlias()
        {
            FactoryFriend.Define<Athlete>().WithAlias("AllPropertiesSet").As(ValidAthlete);
            FactoryFriend.Extend<Athlete>().WithAlias("AllPropertiesSet").ToBe("NoId").As(x =>
                {
                    x.Id = 0;
                    return x;
                });

            var athlete = FactoryFriend.Build<Athlete>().WithAlias("NoId");

            Assert.That(athlete.FirstName, Is.EqualTo("Henry"));
            Assert.That(athlete.LastName, Is.EqualTo("Lawson"));
            Assert.That(athlete.Id, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToExtendAFactoryEntityWithoutUsingAlias()
        {
            FactoryFriend.Define<Athlete>().As(this.ValidAthlete);
            FactoryFriend.Extend<Athlete>().ToBe("NamedTom").As(x =>
                {
                    x.FirstName = "Tommy";
                    x.LastName = "Churchile";
                    return x;
                });

            var athlete = FactoryFriend.Build<Athlete>().WithAlias("NamedTom");

            Assert.That(athlete.FirstName, Is.EqualTo("Tommy"));
            Assert.That(athlete.LastName, Is.EqualTo("Churchile"));
            Assert.That(athlete.Id, Is.EqualTo(22));
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException),
            ExpectedMessage = "FactoryFriend could not find a default \"Domain.Entities.Athlete\" entity factory")]
        public void ShouldBeAbleToClearFactory()
        {
            FactoryFriend.Define<Athlete>().As(ValidAthlete);
            
            FactoryFriend.Clear();

            FactoryFriend.Build<Athlete>().Default();
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException),
            ExpectedMessage = "FactoryFriend could not find a \"Domain.Entities.Athlete\" entity factory for alias \"Valid\"")]
        public void ShouldGetExceptionWhenCallingBuildOnNonExistentFactory()
        {
            FactoryFriend.Build<Athlete>().WithAlias("Valid");
        }

        [Test]
        [ExpectedException(typeof(EntityNotFoundException),
            ExpectedMessage = "FactoryFriend could not find a \"Domain.Entities.Athlete\" entity factory for alias \"Valid\"")]
        public void ShouldGetExceptionWhenCallingExtendOnNonExistentFactory()
        {
            FactoryFriend.Extend<Athlete>().WithAlias("Valid").ToBe("NewFactory").As(x => x);
        }

        [Test]
        public void ShouldOverrideAliasIfExists()
        {
            FactoryFriend.Define<Athlete>().As(this.ValidAthlete);

            FactoryFriend.Define<Athlete>().As(this.ValidAthlete);

            Assert.Pass();
        }
    }
}