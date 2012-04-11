namespace FactoryFriendCore.Attributes
{
    public class Extends : System.Attribute
    {
        public string[] EntityFactoryAliass { get; set; }

        public Extends(params string[] entityFactoryAliass)
        {
            EntityFactoryAliass = entityFactoryAliass;
        }
    }
}
