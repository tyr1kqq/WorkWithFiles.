using System.IO;
using System.Security.Cryptography;
using System.Xml.Schema;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string DirectPath = @"/Users/tyr1k_qq/Desktop/test";
            long PathSize = CalculatePathMemory(DirectPath);

            Console.WriteLine($"Размер папки {DirectPath} = {PathSize}");
     
        }
        static long CalculatePathMemory(string DirectPath)
        {
            long PathSize = 0;

            if (Directory.Exists(DirectPath))
            {
                try
                {
                    string[] Files = Directory.GetFiles(DirectPath, ".", SearchOption.AllDirectories);

                    foreach (string File in Files)
                    {
                        FileInfo file = new FileInfo(File);
                        PathSize += file.Length;
                    }
                    string[] SubDir = Directory.GetDirectories(DirectPath);
                    foreach (string subdirectories in SubDir)
                    {
                        PathSize += CalculatePathMemory(subdirectories);
                    }
                }
                catch (Exception e) { Console.WriteLine("Warning :" + e); }
                return PathSize;
            }
            else { Console.WriteLine("Wrong Direct"); return 0; }
        }
    }
}
