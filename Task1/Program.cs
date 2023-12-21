using System;
using System.Dynamic;
using System.IO;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Delete();
        }

        static public  void Delete()
        {
            

            string FileDir = @"/Users/tyr1k_qq/Desktop/test";

            try
            {
                if (Directory.Exists(FileDir))
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(FileDir);
                    FileInfo fileInfo = new FileInfo(FileDir);
                    DateTime LastDate = DirInfo.LastAccessTime;
                    Console.WriteLine("Directories: ");

                    Console.WriteLine();

                    foreach (var Direct in DirInfo.GetDirectories())
                    {
                        Console.WriteLine(Direct.Name);
                        if ((DateTime.Now - LastDate) > TimeSpan.FromMinutes(30))
                        {
                            Console.WriteLine("Directory {0} has delete", Direct.Name);
                            Direct.Delete(true);
                        }
                        else
                        {
                            Console.WriteLine("Time < 30 minuts");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("Papki: ");

                    Console.WriteLine();

                    foreach (var File in DirInfo.GetFiles())
                    {
                        Console.WriteLine(File.Name);
                        if ((DateTime.Now - LastDate) > TimeSpan.FromMinutes(30))
                        {
                            Console.WriteLine("File {0} has Delete", File.Name);
                            File.Delete();
                        }
                        else
                        {
                            Console.WriteLine("Time < 30 minuts");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}