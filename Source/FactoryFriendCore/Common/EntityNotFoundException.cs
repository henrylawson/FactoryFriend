namespace FactoryFriendCore.Common
{
    using System;

    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
    }
}