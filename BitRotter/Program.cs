using System;
using System.IO;
using System.Text;

namespace BitRotter
{
    class Program
    {
        const string FILE = "C:/Users/johnd/Desktop/test.txt";
        const string OUTPUT = "C:/Users/johnd/Desktop/output/";
        static void Main(string[] args)
        {
            byte[] bytes = File.ReadAllBytes(FILE);

            for(int b = 0; b < bytes.Length; b++)
            {
                byte currByte = bytes[b];

                for(int n = 0; n < 8; n++)
                {
                    // flip the nth bit
                    bytes[b] = FlipBit(currByte, n);

                    // save the file
                    string fileName = b.ToString() + "_" + n.ToString() + ".txt";
                    File.WriteAllBytes(OUTPUT + fileName, bytes);

                    // restore the original byte
                    bytes[b] = currByte;
                }
            }
        }

        // flip the nth bit (0 indexed)
        private static byte FlipBit(byte b, int n)
        {
            return (byte)(b ^ (1 << n));
        }
    }
}
