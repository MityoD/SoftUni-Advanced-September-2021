using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../zipFile";         
            string zipPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/result.zip";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/result";
            ZipFile.CreateFromDirectory(filePath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, folderPath);
        }
    }
}
