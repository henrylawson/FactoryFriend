namespace FactoryFriendCoreTest
{
    using Domain.Entities;
    using Domain.Factories;

    using FactoryFriendCore;

    using NUnit.Framework;

    [TestFixture]
    public class FactoryFriendTest
    {
        [Test]
        public void ShouldBeAbleToRegisterCustomFactory()
        {
            FactoryFriend.AssignEntity<Athlete>().Factory<AthleteFactory>();

            Assert.NotNull(FactoryFriend.Create<Athlete>().WithAllPropertiesSet());
        }
    }
}
