using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = "";
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://api.pearson.com/v2/dictionaries/entries?headword=create");
            }
            
            var obj = JObject.Parse(json);
            var data = (string)obj["definition"];
            try
            {
                JToken token = obj["results"][1]["senses"][0]["definition"];
                Console.WriteLine(token.Path + " -> " + token.ToString());
            }
            catch (NullReferenceException e)
            {
                JToken token = obj["results"][0]["senses"][0]["definition"];
                Console.WriteLine(token.Path + " -> " + token.ToString());
            }
            /* string path = @"c:\temp\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            } */

            //Console.WriteLine(json + "aa");
            Console.ReadKey();


        }
    }
}
