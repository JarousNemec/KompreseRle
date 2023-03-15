using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace KomprecseRlel
{
    public class Rle
    {
        public static string Compress(string input)
        {
            string output = String.Empty;

            uint counter = 0;
            char previous = input[0];
            foreach (var c in input)
            {
                if (previous == c)
                {
                    counter++;
                }
                else
                {
                    output += $"{counter}{previous}";
                    previous = c;
                    counter = 1;
                }
            }

            output += $"{counter}{previous}";

            return output;
        }

        public static string RemoveDigits(string input)
        {
            // string output = string.Empty;
            // foreach (var c in input)
            // {
            //     if (!char.IsDigit(c))
            //     {
            //         output += c;
            //     }
            // }
            // return output;
            return Regex.Replace(input, @"\d", "");
        }

        public static string Decompress(string input)
        {
            var output = string.Empty;
            var number = string.Empty;
            foreach (var c in input)
            {
                if (char.IsDigit(c))
                {
                    number += c.ToString();
                }
                else
                {
                    var count = Convert.ToInt32(number);
                    number = string.Empty;
                    output += new string(c, count);
                }
            }

            return output;
        }

        public static void CompressFile(string file)
        {
            var lines = File.ReadAllLines(file);
            List<string> output = new List<string>();
            foreach (var line in lines)
            {
                var filtered = RemoveDigits(line);
                output.Add(Compress(filtered));
            }

            File.WriteAllLines("compressed-" + file, output);
        }
        
        public static void DecompressFile(string file)
        {
            var lines = File.ReadAllLines(file);
            List<string> output = new List<string>();
            foreach (var line in lines)
            {
                output.Add(Decompress(line));
            }

            File.WriteAllLines("decompressed-" + file, output);
        }
    }
}