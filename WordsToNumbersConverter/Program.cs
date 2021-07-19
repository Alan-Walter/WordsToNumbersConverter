using System;

using WordsToNumbersConverter.Core;

namespace WordsToNumbersConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordReplacer = new WordReplacer();

            Console.WriteLine(wordReplacer.Replace("Он заплатил двадцать миллионов за три таких автомобиля"));
        }
    }
}
