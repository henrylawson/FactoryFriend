namespace FactoryFriendCoreTest.Helpers
{
    using FactoryFriendCore.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class PseudoRandomGenerateTest
    {
        [Test]
        public void ShouldGenerateANonNullFirstName()
        {
            Assert.That(!string.IsNullOrEmpty(PseudoRandomGenerate.FirstName));
        }

        [Test]
        public void ShouldGenerateANonNullOrEmptyLastName()
        {
            Assert.That(!string.IsNullOrEmpty(PseudoRandomGenerate.LastName));            
        }

        [Test]
        public void ShouldGenerate7WordString()
        {
            Assert.That(PseudoRandomGenerate.StringWithWordCount(7).Split(' ').Length, Is.EqualTo(7));
        }

        [Test]
        public void ShouldGenerate1WordString()
        {
            Assert.That(!string.IsNullOrEmpty(PseudoRandomGenerate.StringWithWordCount(1)));
            Assert.That(PseudoRandomGenerate.StringWithWordCount(1).Split(' ').Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGenerate0WordString()
        {
            Assert.That(PseudoRandomGenerate.StringWithWordCount(0), Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldGenerate3ChracterString()
        {
            Assert.That(PseudoRandomGenerate.StringWithCharacterCount(3).Length, Is.EqualTo(3));
        }

        [Test]
        public void ShouldGenerate1ChracterString()
        {
            Assert.That(!string.IsNullOrEmpty(PseudoRandomGenerate.StringWithCharacterCount(1)));
            Assert.That(PseudoRandomGenerate.StringWithCharacterCount(1).Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGenerate0CharacterString()
        {
            Assert.That(PseudoRandomGenerate.StringWithCharacterCount(0), Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldNotGenerateZeroIntegerNumber()
        {
            Assert.That(PseudoRandomGenerate.Integer, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldNotGenerateZeroLongNumber()
        {
            Assert.That(PseudoRandomGenerate.Long, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldGeneratePhraseWithCapitalLetter()
        {
            Assert.That(char.IsUpper(PseudoRandomGenerate.PhraseWithWordCount(2)[0]));
        }
    }
}
