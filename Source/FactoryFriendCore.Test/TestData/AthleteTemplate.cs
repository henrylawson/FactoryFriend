namespace FactoryFriendCore.Test.TestData
{
    using FactoryFriendCore;
    using FactoryFriendCore.Attributes;

    public class AthleteTemplate : IFactoryFriendTemplate
    {
        public Athlete WithValidProperties(Athlete entity)
        {
            entity.FirstName = "Joe";
            entity.LastName = "Bloggs";
            entity.Id = 22;
            return entity;
        }

        public Athlete WithNameTonyAndValidProperties(Athlete entity)
        {
            entity.FirstName = "Tony";
            entity.Id = 88;
            return entity;
        }

        [Extends("WithValidProperties")]
        public Athlete WithInvalidProperties(Athlete entity)
        {
            entity.Id = 0;
            return entity;
        }

        [Extends("WithValidProperties", "WithNameTonyAndValidProperties")]
        public Athlete WithTwoExtendsAttributes(Athlete entity)
        {
            return entity;
        }
    }
}
