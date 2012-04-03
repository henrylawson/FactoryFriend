namespace DomainTest.Factories.Helpers
{
    using System.Collections.Generic;

    using Domain.Factories.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class IdHelperTest
    {
        [Test]
        public void ShouldGenerateThreeUnqiueNumbers()
        {
            var generatedIntegers = new List<int>();
            generatedIntegers.Add(IdHelper.GenerateInteger());
            generatedIntegers.Add(IdHelper.GenerateInteger());
            generatedIntegers.Add(IdHelper.GenerateInteger());
            Assert.That(GetOccurenceCountOfIntegerInList(generatedIntegers[0], generatedIntegers), Is.EqualTo(1));
            Assert.That(GetOccurenceCountOfIntegerInList(generatedIntegers[1], generatedIntegers), Is.EqualTo(1));
            Assert.That(GetOccurenceCountOfIntegerInList(generatedIntegers[2], generatedIntegers), Is.EqualTo(1));
        }

        private static int GetOccurenceCountOfIntegerInList(int inetegerToFind, List<int> generatedIntegers)
        {
            return generatedIntegers.FindAll(integer => integer == inetegerToFind).Count;
        }
    }
}
