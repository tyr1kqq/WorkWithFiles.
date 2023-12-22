using System;
using System.Dynamic;
using System.IO;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileDir = @"/Users/tyr1k_qq/Desktop/test";
            long PathSize = CalculatePathMemory(FileDir);
            Console.WriteLine("Размер папки до удаления - {0}" , PathSize);
            Console.WriteLine();
            Delete(FileDir);
            long PathSizeDelete = CalculatePathMemory(FileDir);
            Console.WriteLine();
            Console.WriteLine("Размер после удаления - {0}", PathSize);
            Console.WriteLine("Освобождено места на диске - {0} byte" , (PathSize-PathSizeDelete));
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
        static public void Delete(string FileDir)
        {


            

            try
            {
                
                if (Directory.Exists(FileDir))
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(FileDir);

                    DateTime LastDate = DirInfo.LastAccessTime;
                    Console.WriteLine("Directories: ");


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