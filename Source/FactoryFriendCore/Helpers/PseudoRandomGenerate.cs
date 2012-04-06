namespace FactoryFriendCore.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PseudoRandomGenerate
    {
        private static readonly Random Random = new Random();

        private static readonly IList<string> FirstNames = new List<string>()
            {
                "Sergio",
                "Daniel",
                "Carolina",
                "David",
                "Reina",
                "Saul",
                "Bernard",
                "Danny",
                "Dimas",
                "Yuri",
                "Ivan",
                "Laura"
            };

        private static readonly IList<string> LastNames = new List<string>()
            {
                "Tapia",
                "Gutierrez",
                "Rueda",
                "Galviz",
                "Yuli",
                "Rivera",
                "Mamami",
                "Saucedo",
                "Dominguez",
                "Escobar",
                "Martin",
                "Crespo"
            };

        private const string LoremIpsumString = 
            "ipsum dolor sit amet consectetur adipiscing elit sed et sem in " + 
            "sem mattis facilisis eu quis sapien vivamus risus felis lacinia eu " + 
            "elementum et scelerisque eget libero aenean";

        public static string FirstName
        {
            get
            {
                return FirstNames[Random.Next(0, FirstNames.Count - 1)];
            }
        }

        public static string LastName
        {
            get
            {
                return LastNames[Random.Next(0, LastNames.Count - 1)];
            }
        }


        public static long Long
        {
            get
            {
                return Integer;
            }
        }

        public static int Integer
        {
            get
            {
                return Random.Next(1, int.MaxValue);
            }
        }

        public static string StringWithWordCount(int wordCount)
        {
            var loremArray = LoremIpsumString.Split(' ');
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < wordCount; i++)
            {
                var rndIndex = Random.Next(0, loremArray.Length);
                stringBuilder.Append(string.Format("{0} ", loremArray[rndIndex]));
            }
            return stringBuilder.ToString().Trim();
        }

        public static string StringWithCharacterCount(int chracterCount)
        {
            var loremStringWithNoSpaces = LoremIpsumString.Replace(" ", "");
            var startIndex = Random.Next(0, loremStringWithNoSpaces.Length - chracterCount - 1);
            return loremStringWithNoSpaces.Substring(startIndex, chracterCount);
        }

        public static string PhraseWithWordCount(int wordCount)
        {
            var phrase = StringWithWordCount(wordCount);
            return string.IsNullOrEmpty(phrase) ? phrase : 
                string.Format("{0} {1}", char.ToUpper(phrase[0]), phrase.Substring(1));
        }
    }
}