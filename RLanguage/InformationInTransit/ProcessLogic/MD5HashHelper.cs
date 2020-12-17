using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;

namespace InformationInTransit.ProcessLogic
{
    class MD5HashHelper
    {
        static void Main(string[] args)
        {
            // check the number of arguments
            if ((args.Length == 0) || (args[0] == "/?")
                || (args[0].ToLower() == "-h"))
            {
                ShowHelp();
            }
            else
            {
                string filename = args[0];
                string literal = null;
                if (filename.ToLower().StartsWith("-l:"))
                {
                    int len = filename.Length;
                    literal = filename.Substring(3, len - 3);
                }
                if (literal != null)
                {
                    CalculateMD5Hash(literal);
                }
                else
                {
                    CalculateMD5HashFromFile(filename);
                }
            }
        }

        private static void CalculateMD5HashFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Error: The file \"" + filename + "\" does not exist.");
                return;
            }
            // step 1, calculate MD5 hash from FileStream object's data
            FileStream input = new FileStream(filename, FileMode.Open);
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(input);

            // step 2, convert byte array to hexadecimal string
            string hashHex = ByteArrayToHexString(hash);
            Console.WriteLine("The MD5 has for the file \"" + filename + "\" is:");
            Console.WriteLine(hashHex);
        }

        private static void CalculateMD5Hash(string literal)
        {
            // step 1, calculate MD5 hash from literal given as input
            MD5 md5 = MD5.Create();
            byte[] byteBuffer = System.Text.Encoding.ASCII.GetBytes(literal);
            byte[] hash = md5.ComputeHash(byteBuffer);

            // step 2, convert byte array to hexadecimal string
            string hashHex = ByteArrayToHexString(hash);
            Console.WriteLine("The MD5 has for the literal \"" + literal + "\" is:");
            Console.WriteLine(hashHex);
        }

        private static string ByteArrayToHexString(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("MD5Hash calculates the MD5 hash of a file or a literal string.");
            Console.WriteLine();
            Console.WriteLine("Usage: md5hash filename | -l:string");
            Console.WriteLine("For this help: md5hash [/? | -h]");
            Console.WriteLine();
            Console.WriteLine("Where filename is the name (and path) of the file " +
                "of which the MD5 hash should be calculated. Or, if you want to " +
                "calculate hash of a literal, specify \"-l:\" and then the string " +
                "literal.");
        }
    }
}
