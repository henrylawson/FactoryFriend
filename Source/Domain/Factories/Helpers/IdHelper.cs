namespace Domain.Factories.Helpers
{
    using System;

    public static class IdHelper
    {
        private static readonly Random Random = new Random();

        public static int GenerateInteger()
        {
            return Random.Next(1, int.MaxValue);
        }
    }
}
