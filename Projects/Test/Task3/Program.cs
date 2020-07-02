using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
       
       
        static void Main(string[] args)
        {    
            string s;
            string d = @"\\Mac\Home\Desktop\";
            s = Console.ReadLine();
            String []dir;
            try
            {
                if (Directory.Exists(d + s))
                {
                    dir = Directory.GetFiles(d + s);
                    for (int i = 0; i < dir.Length; i++)
                    {
                        Console.WriteLine(dir[i]);

                    }
                }
                else
                {
                    throw new FileNotFoundException();
                    throw new UnauthorizedAccessException();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Oops");
            }
            {

            }

            Console.ReadKey();
        }
    }
}
