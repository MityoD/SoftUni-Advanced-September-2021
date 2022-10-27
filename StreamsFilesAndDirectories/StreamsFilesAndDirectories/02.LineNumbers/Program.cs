using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] lines = File.ReadAllLines("../../../../text.txt");
            List<string> listOfLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                int letters = lines[i].Count(x => char.IsLetter(x));
                int punctuations = lines[i].Count(x => char.IsPunctuation(x));
                listOfLines.Add($"Line {i + 1}: {lines[i]} ({letters})({punctuations})");
                
            }
            File.WriteAllLines("../../../../output.txt", listOfLines);
        }
    }
}
