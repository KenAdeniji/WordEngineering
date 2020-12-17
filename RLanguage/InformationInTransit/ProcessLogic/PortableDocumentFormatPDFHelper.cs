#region Using direcives
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region PortableDocumentFormatPDFHelper definition
    public static class PortableDocumentFormatPDFHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            string destinationFileName = argv.Length < 2 ? DestinationFileName : argv[1];
            string sourceFileName = argv.Length < 1 ? SourceFileName : argv[0];
            //ConvertToPostScript(sourceFileName);
            ConvertToPortableDocumentFormatPDF(destinationFileName);
            /*
            PrintPortableDocumentFormatPDF
            (
                AdobeReader,
                DestinationFileName,
                PrinterName
            );
            */ 
        }

        private static string ConvertToPortableDocumentFormatPDF(string filename)
        {
            string ret = null;
            try
            {
                string command = "gswin32c -q -dNOPAUSE -sDEVICE=pdfwrite -sOutputFile=" + filename + @" C:\GSOutput.ps";

                Process pdfProcess = new Process();

                StreamWriter writer;
                StreamReader reader;

                ProcessStartInfo info = new ProcessStartInfo("cmd");
                info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;

                pdfProcess.StartInfo = info;
                pdfProcess.Start();

                writer = pdfProcess.StandardInput;
                reader = pdfProcess.StandardOutput;
                writer.AutoFlush = true;

                writer.WriteLine(command);

                writer.Close();

                ret = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        public static void ConvertToPostScript(string filename)
        {
            try
            {
                Process printProcess = new Process();

                printProcess.StartInfo.FileName = filename;
                printProcess.StartInfo.Verb = "printto";
                printProcess.StartInfo.Arguments = @"Ghostscript PDF";
                printProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                printProcess.StartInfo.CreateNoWindow = true;
                printProcess.Start();

                // Wait until the PostScript file is created
                try
                {
                    printProcess.WaitForExit();
                }
                catch (InvalidOperationException) { }

                printProcess.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void PrintPortableDocumentFormatPDF
        (
            string programFileName,
            string documentFileName,
            string printerName
        )
        {
            string processStartInfoArgument = "";
            String.Format
            (
                ProcessStartInfoPrintArgumentFormat,
                documentFileName,
                printerName
            );
            ProcessStartInfo processStartInfo = new ProcessStartInfo(programFileName, processStartInfoArgument);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
        }
        #endregion

        #region
        public const string AdobeReader = @"""D:\Program Files\Adobe\Reader 8.0\Reader\AcroRd32.exe""";
        public const string DestinationFileName = "PortableDocumentFormatPDFHelper.pdf";
        public const string SourceFileName = "PortableDocumentFormatPDFHelper.cs";
        public const string PrinterName = "HP LaserJet 2100 PCL6 on Salem";
        //public const string ProcessStartInfoPrintArgumentFormat = @" /t ""{0}"" ""{1}"" ";
        public const string ProcessStartInfoPrintArgumentFormat = @" /h /p ""{0}"" ""{1}"" ";
        #endregion
    }
    #endregion
}

