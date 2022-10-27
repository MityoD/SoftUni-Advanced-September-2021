using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream("../../../../copyMe.png", FileMode.Open);
            FileStream newFile = new FileStream("../../../../copyMe-copy.png", FileMode.Create);
            byte[] buffer = new byte[256];
            while (true)
            {
                int currentBytes = file.Read(buffer, 0, buffer.Length);
                if (currentBytes == 0)
                {
                    newFile.Flush();
                    break;
                }
                newFile.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
