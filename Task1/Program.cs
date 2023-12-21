using System;
using System.IO;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeleteFile();
        }

        static public  void DeleteFile()
        {
            string FileDir = @"/Users/tyr1k_qq/Desktop";
            DirectoryInfo DirInf = new DirectoryInfo(FileDir );
            try
            {
                if (DirInf.Exists)
                {
                    DateTime LastTime = DirInf.LastAccessTime;
                    
                    if (( DateTime.Now - LastTime) > TimeSpan.FromMinutes(30)) 
                    {
                        DirInf.Delete(true);
                        Console.WriteLine("Your file is Delete");
                    }
                    else
                    {
                        Console.WriteLine("File used za poslednie 30 minut");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Wrong adress");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}