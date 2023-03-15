using System;
using System.Runtime.InteropServices;

namespace KomprecseRlel
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            // string input = "aaabb555ccccccd";
            // string filtered = Rle.RemoveDigits(input);
            // string output = Rle.Compress(filtered);
            // Console.WriteLine(input);
            Rle.CompressFile("rle.txt");
            Rle.DecompressFile("compressed-rle.txt");
            // Console.WriteLine(output);

            // string decompressed = Rle.Decompress(output);
            // Console.WriteLine(decompressed);
        }
    }
}