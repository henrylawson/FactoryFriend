namespace FactoryFriendCore.Test.TestData
{
    using FactoryFriendCore;
    using FactoryFriendCore.Attributes;

    public class AthleteTemplate : IFactoryFriendTemplate
    {
        public Athlete ValidProperties(Athlete entity)
        {
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            entity.Id = 22;
            return entity;
        }

        public Athlete NameToTonyAndIdTo88(Athlete entity)
        {
            entity.FirstName = "Tony";
            entity.Id = 88;
            return entity;
        }

        [Extends("ValidProperties")]
        public Athlete InvalidProperties(Athlete entity)
        {
            entity.Id = 0;
            return entity;
        }

        [Extends("ValidProperties", "NameToTonyAndIdTo88")]
        public Athlete HasTwoExtends(Athlete entity)
        {
            return entity;
        }
    }
}
