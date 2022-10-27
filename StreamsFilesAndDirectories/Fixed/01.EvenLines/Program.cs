using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../../text.txt");
            char[] toReplace = new[] { '-', ',', '.', '!', '?' };
            int counter = 0;
            while (!reader.EndOfStream)
            {
                string result = reader.ReadLine();
                if (counter % 2 == 0)
                {
                    foreach (var item in toReplace)
                    {
                        result = result.Replace(item, '@');
                    }
                    Console.WriteLine(string.Join(" ", result.Split().Reverse()));
                }
                counter++;
            }
        }
    }
}
