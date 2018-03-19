using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ReplaceUtilit
{
    class Program
    {
        public const string path = @"D:\titles.txt";
        public const string newPath = @"D:\replace.txt";
        static void Main(string[] args)
        {
            ReadTextFile();
            File.ReadAllText(newPath);

            Console.WriteLine("Done!");

            Console.ReadKey();
        }

        public static void ReadTextFile()
        {
            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                File.AppendAllText(newPath, ReFormat(line));
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
                str = "\r\n\r\n" + str + "\r\n";
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

            return str + Environment.NewLine;            
        }
    }
}
