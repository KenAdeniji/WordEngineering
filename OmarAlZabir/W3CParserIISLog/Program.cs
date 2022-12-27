/*
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
*/
using System;
using System.IO;
using W3CParser.Extensions;
using W3CParser.Instrumentation;
using W3CParser.Parser;

/*
	2022-12-25T19:40:00	https://stackoverflow.com/questions/32120528/parse-iis-log-file-is-there-an-alternative-to-logparser
	2022-12-25T19:40:00	dotnet new console
	2022-12-25T20:37:00	git clone https://github.com/AlexNolasco/SO32120528
	2022-12-25T20:14:00	https://stackoverflow.com/questions/39155571/how-to-run-net-core-console-application-from-the-command-line
	2022-12-25T21:40:00	W3CParserIISLog.csproj
						<StartupObject>MyNamespace.Program</StartupObject>
	2022-12-25T20:14:00	dotnet publish 
	2022-12-25T20:14:00	dotnet run
*/
namespace W3CParserHelper
{
    class Program
    {
        static void Main(string[] args)
        {            
            var reader = new W3CReader(File.OpenText(args.Length > 0 ? args[0] : "SO32120528/Examples/Data/foobar.log"));

            using (new ConsoleAutoStopWatch())
            {
                foreach (var @event in reader.Read())
                {
                    Console.WriteLine("{0} ({1}):{2}/{3} {4} (bytes sent)",
                                      @event.Status.ToString().Red().Bold(),
                                      @event.ToLocalTime(),
                                      @event.UriStem.Green(),
                                      @event.UriQuery,
                                      @event.BytesSent);
                }
            }
        }
    }
}
