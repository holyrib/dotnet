using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace Lab3
{
    class Program
    {
        public static bool IsPhone(string text)
        {
            Regex rx = new Regex(@"^(\d{3}||\(\d{3}\))[\s\-]?\d{3}\-?\d{4}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(text);
        }
        public static bool IsZip(string text)
        {
            Regex rx = new Regex(@"^\d{5}([-\s]\d{4})?$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(text);
        }
        public static bool IsMail(string text)
        {
            Regex rx = new Regex(@"^[\w\-\.]+@[a-z]+\.[a-z]+[^\s]$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(text);
        }
        public static string Reformat(string text)
        {
            Regex rx = new Regex(@"^\(\d{3}\)[\s\-]?\d{3}\-?\d{4}$",
             RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(text))
            {
                return text;
            }
            else
            {
                int cnt = 0;
                string num = "";
                string pt =@"\d+";
                if (Regex.Matches(text, pt).Count == 1)
                {
                    num = num + "(";
                    for(int i = 0; i < text.Length; i++)
                    {
                        num = num + text[i];
                        if(i == 2)
                        {
                            num = num + ") ";
                        }
                        else if (i == 5)
                        {
                            num = num + "-";
                        }
                    }
                    return num;
                }
                else
                {
                    string refo =  "(";
                    foreach (Match m in Regex.Matches(text, pt))
                    {
                        num = num + m;
                    }
                   
                    for (int i = 0; i < num.Length; i++)
                    {
                        refo = refo + num[i];
                        if (i == 2)
                        {
                            refo = refo + ") ";
                        }
                        else if (i == 5)
                        {
                            refo = refo + "-";
                        }
                    }
                    return refo;
                }
               
                
            }
        }
        static void Main(string[] args)
        {
            
            // Define a test string.        
            string text = "555)9991234";
            // \(?\d{3}\)?[\s\-]?\d{3}\-?\d{4}$
            // Find matches.
            //MatchCollection matches = rx.Matches(text);
            Console.WriteLine("lol");
            if (Program.IsPhone(text))
            {
                Console.WriteLine("Phone number matches");
            }
            else
            {
                Console.WriteLine("Phone number doesn't match");
            }
            string text2 = "12345-1234";
            if (Program.IsZip(text2))
            {
                Console.WriteLine("Zip number matches");
            }
            else
            {
                Console.WriteLine("Zip number doesn't match");
            }
            string text3 = "aidana@gmail.com";
            if (Program.IsMail(text3))
            {
                Console.WriteLine("Mail matches");
            }
            else
            {
                Console.WriteLine("Mail doesn't match");
            }
            string phone = "(123456-7890";
            Console.WriteLine(Reformat(phone));


            Console.ReadKey();
        }

    }
}
