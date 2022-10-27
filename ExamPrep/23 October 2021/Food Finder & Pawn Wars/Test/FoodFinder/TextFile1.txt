using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 	•	"pear"
	•	"flour"
	•	"pork"
	•	"olive"
*/          string[] collection = new string[] { "pear", "flour", "pork", "olive" };
            List<string> words = new List<string>();
            List<HashSet<char>> word = new List<HashSet<char>>();
            HashSet<char> pear = new HashSet<char>();
            HashSet<char> flour = new HashSet<char>();
            HashSet<char> pork = new HashSet<char>();
            HashSet<char> olive = new HashSet<char>();
            word.Add(pear);
            word.Add(flour);
            word.Add(pork);
            word.Add(olive);
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            while (consonants.Count > 0)
            {
                char vowelLetter = vowels.Dequeue();
                char consonantLetter = consonants.Pop();
                for (int i = 0; i < collection.Length; i++)
                {
                    if (collection[i].Contains(vowelLetter))
                    {
                        word[i].Add(vowelLetter);
                    }
                    if (collection[i].Contains(consonantLetter))
                    {
                        word[i].Add(consonantLetter);
                    }
                }
                vowels.Enqueue(vowelLetter);
            }
            for (int i = 0; i < collection.Length; i++)
            {
                if (word[i].Count == collection[i].Length)
                {
                    words.Add(collection[i]);
                }
            }
            Console.WriteLine($"Words found: {words.Count}");
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }

    }
}
