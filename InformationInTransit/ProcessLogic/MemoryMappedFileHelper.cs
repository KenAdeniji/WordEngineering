using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows;

namespace InformationInTransit.ProcessLogic
{
    public static partial class MemoryMappedFileHelper
    {
        public static void Main(string[] argv)
        {
            string executableFilename = Environment.GetCommandLineArgs()[0];
            string mapName = argv.Length < 1 ? executableFilename : argv[0];
            object data = argv.Length < 2 ? executableFilename : argv[1];
            CreateNew(mapName, data, ((string)data).Length);
            OpenExisting(mapName, ref data);
        }

        public static void CreateNew(string mapName, string data)
        {
            CreateNew(mapName, data, data.Length);
        }

        public static void CreateNew
        (
            string mapName,
            object data,
            long capacity
        )
        {
            MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateNew(mapName, capacity);
            StreamWriter streamWriter = new StreamWriter(memoryMappedFile.CreateViewStream());
            streamWriter.WriteLine(data);
            streamWriter.Close();
        }

        public static void OpenExisting
        (
                string mapName,
            ref object data
        )
        {
            MemoryMappedFile memoryMappedFile = MemoryMappedFile.OpenExisting(mapName);
            StreamReader streamReader = new StreamReader(memoryMappedFile.CreateViewStream());
            data = streamReader.ReadLine();
            System.Console.WriteLine(data);
        }
    }
}
