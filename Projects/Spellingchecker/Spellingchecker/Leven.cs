using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellingchecker
{
    class Leven
    {
        public int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public int leven(char[] inword, char[] outword)
        {
            int[,] matrix = new int[inword.Length + 1, outword.Length + 1];
            for (int i = 0; i <= inword.Length; i++)
            {
                matrix[i, 0] = i;
            }

            for (int i = 0; i <= outword.Length; i++)
            {
                matrix[0, i] = i;
            }



            for (int i = 1; i <= inword.Length; i++)
            {
                for (int j = 1; j <= outword.Length; j++)
                {
                    if (inword[i - 1] == outword[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1];
                    }
                    else {
                        matrix[i, j] = Min(matrix[i - 1, j - 1] + 2, matrix[i - 1, j] + 1, matrix[i, j - 1] + 1);
                    }


                }
            }
            

            //result = matrix[inword.Length, outword.Length];
            return matrix[inword.Length, outword.Length];



        }

        public string Repl(string Source, string Find, string Replace)
        {
            int Place = Source.LastIndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

    }
}
