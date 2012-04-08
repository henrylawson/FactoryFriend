namespace FactoryFriendCoreTest.TestData
{
    using FactoryFriendCore;

    public class AthleteTemplate : IFactoryFriendTemplate
    {
        public Athlete ValidProperties(Athlete entity)
        {
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            entity.Id = 22;
            return entity;
        }
    }
}
