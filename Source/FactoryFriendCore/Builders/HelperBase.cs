namespace FactoryFriendCore.Builders
{
    public class HelperBase
    {
        protected FactoryFriend FactoryFriend;

        internal HelperBase(FactoryFriend factoryFriend)
        {
            this.FactoryFriend = factoryFriend;
        }
    }
}