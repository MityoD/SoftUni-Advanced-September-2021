using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input -> .");
            string input = Console.ReadLine();
            string[] files = Directory.GetFiles("../../../../", $"{input}");
            Dictionary<string, Dictionary<string, double>> groupedFiles = new Dictionary<string, Dictionary<string, double>>();
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string name = fileInfo.Name;
                double size = fileInfo.Length;
                string extension = fileInfo.Extension;
                if (!groupedFiles.ContainsKey(extension))
                {
                    groupedFiles.Add(extension, new Dictionary<string, double>());
                }
                groupedFiles[extension].Add(name, size / 1024);
            }
            List<string> newFileData = new List<string>();
            foreach (var extension in groupedFiles.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                newFileData.Add(extension.Key);
                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                    newFileData.Add($"--{file.Key} - {file.Value:F3}kb");
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            File.WriteAllLines(path, newFileData);
        }
    }
}
