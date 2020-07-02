using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Int16 a = 15;
            Int32 b = 134;
            double c = 32.42;
            a = b;
            b = c;
            c = a;
        }
    }
}
