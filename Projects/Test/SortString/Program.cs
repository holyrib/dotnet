using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Your dog stinks";
            String[] words = s.Split();
            Array.Sort(words);
            Console.WriteLine(string.Join(" ", words));
            Console.ReadKey();

        }
    }
}
