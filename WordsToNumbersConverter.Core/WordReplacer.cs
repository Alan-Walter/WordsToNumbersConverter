using System;

namespace WordsToNumbersConverter.Core
{
    public class WordReplacer
    {
        public string Replace(string input)
        {
            var parser = new StringParser(input);
            var res = parser.Parse();
            return null;
        }
    }
}
