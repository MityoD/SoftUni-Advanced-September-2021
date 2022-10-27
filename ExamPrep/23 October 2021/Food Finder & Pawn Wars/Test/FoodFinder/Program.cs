using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            //Dictionary<int, string[]> pear = new Dictionary<int, string[]>();
            //Dictionary<int, string[]> flour = new Dictionary<int, string[]>();
            //Dictionary<int, string[]> pork = new Dictionary<int, string[]>();
            //Dictionary<int, string[]> olive = new Dictionary<int, string[]>();
            //pear.Add(0,new string[]{"pear", ""});
            //flour.Add(0,new string[]{ "flour", ""});
            //pork.Add(0,new string[]{ "pork", ""});
            //olive.Add(0,new string[]{ "olive", ""});

            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";
            int wordsFound = 0;
            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();
                if (pear.Contains(vowel) || pear.Contains(consonant))
                {
                    pear = pear.Replace(vowel, '0');
                    pear = pear.Replace(consonant, '0');
                }
                if (flour.Contains(vowel) || flour.Contains(consonant))
                {
                    flour = flour.Replace(vowel, '0');
                    flour = flour.Replace(consonant, '0');
                }
                if (pork.Contains(vowel) || pork.Contains(consonant))
                {
                    pork = pork.Replace(vowel, '0');
                    pork = pork.Replace(consonant, '0');
                }
                if (olive.Contains(vowel) || olive.Contains(consonant))
                {
                    olive = olive.Replace(vowel, '0');
                    olive = olive.Replace(consonant, '0');
                }
                vowels.Enqueue(vowel);
            }
            bool pearFound = false;
            if (pear == "0000")
            {
                pearFound = true;
                wordsFound++;
            }

            bool flourFound = false;
            if (flour == "00000")
            {
                flourFound = true;
                wordsFound++;
            }
            bool porkFound = false;
            if (pork == "0000")
            {
                porkFound = true;
                wordsFound++;
            }
            bool oliveFound = false;
            if (olive == "00000")
            {
                oliveFound = true;
                wordsFound++;
            }

            Console.WriteLine($"Words found: {wordsFound}");


            if (pearFound)
            {
                Console.WriteLine("pear");
            }

            if (flourFound)
            {
                Console.WriteLine("flour");
            }
            if (porkFound)
            {
                Console.WriteLine("pork");
            }
            if (oliveFound)
            {
                Console.WriteLine("olive");
            }

        }
    }
}
