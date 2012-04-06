namespace FactoryFriendCore.Builders
{
    public class HelperBase
    {
        protected FactoryFriend FactoryFriend;

        public HelperBase(FactoryFriend factoryFriend)
        {
            this.FactoryFriend = factoryFriend;
        }
    }
}