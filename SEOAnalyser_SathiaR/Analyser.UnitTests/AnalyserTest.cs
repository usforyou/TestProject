using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analyser.UnitTests
{
    [TestClass]
    public class AnalyserTest
    {
        private WebClient.util.Analyser _analyser;

        [TestInitialize]
        public void Initialize()
        {
            _analyser = new WebClient.util.Analyser();
        }

        private class CreatedEmptyWordsKeywordsStopwordsDic
        {
            public Dictionary<string, int> WordsDictionary = new Dictionary<string, int>();
            public Dictionary<string, int> KeywordsDictionary = new Dictionary<string, int>();
            public Dictionary<string, int> StopWordsDictionary = new Dictionary<string, int>();
            public char[] WordsSeparator = { ' ', ',', '.', '\r', '\n', '\t', '/' };
        }

        [TestMethod]
        public void RemoveSpecialCharacters()
        {
            string text = "&#123;test&#123;test234&#556;";
            string result= "test test234";
            string str = WebClient.util.Analyser.ReplaceSpecialCharacters(text);
            Assert.AreEqual(str, result);
        }


        [TestCase("word11 __word**", "word word ")]
        [TestCase("word word", "word word")]
        [TestCase("word  word", "word word")]
        public void ReplaceNotLetters_SomeText_TextWithLettersAndOneSpaceInsteadNotLettersGroup(string text, string etalon)
        {
            string str = WebClient.util.Analyser.ReplaceNotLetters(text);

            Assert.AreEqual(str, etalon);
        }

    }
}
