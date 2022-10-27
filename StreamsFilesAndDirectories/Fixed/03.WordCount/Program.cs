using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] wordLines = File.ReadAllLines("../../../../words.txt");
            string[] textLines = File.ReadAllLines("../../../../text.txt");
            foreach (var word in wordLines)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }
            foreach (var line in textLines)
            {
                foreach (var word in wordLines)
                {
                    if (line.Contains(word, StringComparison.OrdinalIgnoreCase))
                    {
                        wordsCount[word]++;
                    }
                }
            }
            List<string> lines = new List<string>();
            foreach (var word in wordsCount.OrderByDescending(x => x.Value))
            {
                lines.Add($"{word.Key} - {word.Value}");
            }
            File.WriteAllLines("../../../../actualResult.txt", lines);            
            var areEqual = File.ReadAllLines("../../../../expectedResult.txt").SequenceEqual(
                File.ReadAllLines("../../../../actualResult.txt"));
            if (areEqual)
            {
                Console.WriteLine("Files are equal!");
            }
            else
            {
                Console.WriteLine("Files are NOT equal!");
            }
        }
    }
}
