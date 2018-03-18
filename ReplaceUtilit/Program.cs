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
            ReadTextFile();

            Console.ReadKey();
        }

        public static void ReadTextFile()
        {
            string[] lines = File.ReadAllLines(@"D:\titles.txt");

            foreach (string line in lines)
            {
                Console.WriteLine(ReFormat(line));
            }
        }

        private static string ReFormat(string str)
        {
            string PATTERN = @"(?<=[A-Za-z\?]+|201[5,7]|\s)([0-9]?[0-9]m\s\d{1,2}s)";
            string REPLACE_PATTERN = " ($1)";
            string REPLACE_TITLE_PATTERN = " ($1)" + "\n\n";

            if (Regex.IsMatch(str, @"\b([A-Za-z]+(?:\dm\s\d\d?s))\b"))
            {
                str = Regex.Replace(str, PATTERN, REPLACE_PATTERN);
            }
            else if (Regex.IsMatch(str, @"\b([A-Za-z]+(?:\d\dm\s\d\d?s))\b"))
            {
                str = Regex.Replace(str, PATTERN, REPLACE_TITLE_PATTERN);
                str = "\n" + str;
            }
            else if (Regex.IsMatch(str, @"\b([\?]+(?:\dm\s\d\d?s))\b"))
            {
                str = Regex.Replace(str, PATTERN, REPLACE_PATTERN);
            }
            else if (Regex.IsMatch(str, @"201[5,7](?:\dm\s\d\d?s)\b"))
            {
                str = Regex.Replace(str, PATTERN, REPLACE_PATTERN);
            }
            else if (Regex.IsMatch(str, @"\b([\s]+(?:\dm\s\d\d?s))\b"))
            {
                str = Regex.Replace(str, PATTERN, REPLACE_PATTERN);
            }

            return str;
        }
    }
}
