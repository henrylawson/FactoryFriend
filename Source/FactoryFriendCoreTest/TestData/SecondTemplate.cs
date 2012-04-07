namespace FactoryFriendCoreTest.TestData
{
    using FactoryFriendCore;

    public class SecondTemplate : IFactoryFriendTemplate
    {
        public Contact InvalidProperties(Contact entity)
        {
            entity.Id = 99;
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            return entity;
        }
    }
}
