namespace FactoryFriendCoreTest.TestData
{
    using FactoryFriendCore;

    public class FirstTemplate : IFactoryFriendTemplate
    {
        public Contact FirstDefinedMethod(Contact entity)
        {
            entity.Id = 8;
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            return entity;
        }

        public Contact SecondDefinedMethod(Contact entity)
        {
            entity.Id = 9;
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            return entity;
        }
    }
}
