namespace FactoryFriendCore.BuildHelpers
{
    public class BuildHelperBase
    {
        protected FactoryFriend FactoryFriend;

        internal BuildHelperBase(FactoryFriend factoryFriend)
        {
            FactoryFriend = factoryFriend;
        }
    }
}