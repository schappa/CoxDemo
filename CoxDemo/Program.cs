using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CoxDemo
{
    public static class Program
    {
        /// <summary>
        /// Parses a sentence and replaces each word with the following: 
        /// first letter, number of distinct characters between first and last character, and last letter. 
        /// Words are separated by spaces or non-alphabetic characters and these separators should be maintained 
        /// in their original form and location in the answer.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            if (args.Length == 0 || args[0].Trim().Length == 0)
            {
                Console.WriteLine("No text supplied\n\nUsage: " +
                    $"{Assembly.GetExecutingAssembly().GetName().Name} \"The quick brown fox jumped over the lazy red dog\"");
                return;
            }

            try
            {
                string sentence = args[0];
                string[] sentenceParts = sentence.Split(' ');
                List<string> finalResultsList = new List<string>();

                foreach (var sentencePart in sentenceParts)
                    finalResultsList.Add(GetModifiedWord(sentencePart));

                Console.WriteLine(String.Join('-', finalResultsList.ToArray()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Encountered!\n{ex.Message}\n{ex.StackTrace}");                
            }


        }

        /// <summary>
        /// Transform a word 
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Transformed word</returns>
        private static string GetModifiedWord(string word)
        {
            if (word.Length == 1)
                return word;

            if (word.All(char.IsLetter))
                return $"{word.First()}{word.Length - 2}{word.Last()}";
            else
                return GetMixedWord(word);

        }

        /// <summary>
        /// Transform word that contains non-alpha characters
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static string GetMixedWord(string word)
        {
            string returnValue = string.Empty;

            Regex rgx = new Regex(@"[^a-zA-Z]");
            var regexSplitArray = rgx.Split(word);

            int index = 0;
            int counter = 1;
            foreach (var item in regexSplitArray)
            {
                if (counter == regexSplitArray.Count())
                    returnValue += $"{item.First()}{item.Length - 2}{item.Last()}";
                else
                {
                    //Find delimiter
                    index = word.IndexOf(item, index) + item.Length;
                    string delimiter = word.Substring(index, 1);
                    returnValue += $"{item.First()}{item.Length - 2}{item.Last()}{delimiter}";
                    ++counter;
                }
            }

            return returnValue;
        }
    }
}
