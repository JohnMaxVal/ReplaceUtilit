using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceUtilit
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader reading = File.OpenText(@"D:\titles.txt");

            //string str = reading.ReadToEnd();
            //Console.WriteLine(str);
            ReadTextFile();

            Console.ReadKey();
        }

        public static void ReadTextFile()
        {
            string[] lines = File.ReadAllLines(@"D:\titles.txt");

            foreach (string line in lines)
            {
                Console.WriteLine("Original: {0}", line);
                Console.WriteLine("Replaced: {0}", ReFormat(line));
            }
        }

        private static string ReFormat(string str)
        {
            string PATTERN = @"\b([A-Za-z]+(?:\dm\s\d{2}s))\b";
            string REPLACE_PATTERN = @"\b([A-Za-z]+(?:\s\dm\s\d\ds))\b";
            string newStr;

            Match match = Regex.Match(str, PATTERN);

            if(match.Success)
            {
                Regex.Replace(str, PATTERN, REPLACE_PATTERN, RegexOptions.IgnoreCase);
            }

            return newStr.Tex;
        }
    }
}
