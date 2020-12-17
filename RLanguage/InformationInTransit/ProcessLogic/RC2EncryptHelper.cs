using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;

namespace InformationInTransit.ProcessLogic
{
    class RC2EncryptHelper
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
                string password = "";
                if (args.Length >= 2) password = args[1];
                EncryptFile(filename, password);
            }
        }

        private static void EncryptFile(string filename, string password)
        {
            // parameter checks
            bool ok = CheckParameters(filename, ref password);
            if (!ok) return;
            // start encrypting the file
            RC2 rc2 = RC2.Create();
            byte[] initvector = new byte[8] { 83, 123, 28, 95, 70, 231, 117, 156 };
            byte[] key = System.Text.Encoding.ASCII.GetBytes(password);
            string outputFilename = Path.ChangeExtension(filename, "rc2enc");
            ICryptoTransform transform = rc2.CreateEncryptor(key, initvector);
            FileStream input = null;
            FileStream output = null;
            CryptoStream crypto = null;
            try
            {
                input = new FileStream(filename, FileMode.Open);
                output = new FileStream(outputFilename, FileMode.Create);
                crypto = new CryptoStream(output, transform, CryptoStreamMode.Write);
                // encrypt file data
                CopyStream(input, crypto);
            }
            finally
            {
                if (crypto != null) crypto.Close();
                if (output != null) output.Close();
                if (input != null) input.Close();
            }
            Console.WriteLine("File encrypted.");
        }

        private static void CopyStream(Stream input, Stream output)
        {
            const int blockSize = 64 * 1024; // 64k
            // copy data block by block
            byte[] buffer = new byte[blockSize];
            int bytesRead = input.Read(buffer, 0, blockSize);
            while (bytesRead > 0)
            {
                output.Write(buffer, 0, bytesRead);
                bytesRead = input.Read(buffer, 0, blockSize);
            }
        }

        private static bool CheckParameters(string filename, ref string password)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Error: The file \"" + filename + "\" does not exist.");
                return false;
            }
            Console.WriteLine("Encrypting the file \"" + filename + "\".");
            if (String.IsNullOrEmpty(password) || (password.Length < 5) ||
                (password.Length > 16))
            {
                Console.Write("Enter password, 5-16 characters: ");
                password = Console.ReadLine();
                if (String.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Error: The password cannot be empty.");
                    return false;
                }
                if ((password.Length < 5))
                {
                    Console.WriteLine("Error: The password is too short.");
                    return false;
                }
                if ((password.Length > 16))
                {
                    Console.WriteLine("Error: The password is too long.");
                    return false;
                }
            }
            Console.WriteLine("The password is " +
                password.Length + " character(s) in length.");
            return true;
        }

        private static void ShowHelp()
        {
            Console.WriteLine("RC2Encrypt encrypts a file with the RC2 symmetric algorithm.");
            Console.WriteLine();
            Console.WriteLine("Usage: rc2encrypt filename [password]");
            Console.WriteLine("For this help: rc2encrypt [/? | -h]");
            Console.WriteLine();
            Console.WriteLine("Where filename is the name (and path) of the source " +
                "to encrypt with the given password (the password must be 5-16 characters). " +
                "A new file will created in the same location as the old file, but " +
                "with the extension .rc2enc.");
        }
    }
}
