using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {

        static void Main(string[] args)
        {
            

            getFilesRecursive(@"Y:\");
            //GetAllFiles(@"Y:\Desktop");
            Console.ReadKey();
        }
       static List<string> gfiles = new List<string>();

        private static void getFilesRecursive(string sDir)
        {
            string word = "Bonus";
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    getFilesRecursive(d);
                }
                foreach (var file in Directory.GetFiles(sDir))
                {
                    //This is where you would manipulate each file found, e.g.:
                    DoAction(file);
                    
                    if (file.Contains(word)){
                        Console.WriteLine(Path.GetFileName(file));
                    }

                }
            }

            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DoAction(string filepath)
        {
            gfiles.Add(filepath);
        }


        public static void GetAllFiles(string sDir)
        {
            try
            {

                foreach (string dir in Directory.GetDirectories(sDir))
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(dir, "**"))
                        {
                            string dfile = Path.GetFileName(file);
                            //if()
                            Console.WriteLine(dfile);
                        }
                        GetAllFiles(dir);
                    }
                    catch (Exception Error)
                    {
                        Console.WriteLine(Error.Message);
                    }
                }
            }
            catch(DirectoryNotFoundException dirEx)
            {
                Console.WriteLine("File not found" + dirEx.Message);
            }

          

        }
    }
}
