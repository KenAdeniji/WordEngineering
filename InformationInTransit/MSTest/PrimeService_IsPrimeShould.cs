/*
	2022-05-28T21:34:00	https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest
	2022-05-28T21:53:00	csc /out:InformationInTransit.dll /target:library /recurse:*.cs /reference:System.Data.Entity.dll,System.DirectoryServices.AccountManagement.dll,System.Numerics.dll,"bin\Debug\HtmlAgilityPack.dll","bin\Debug\iTextSharp.dll","bin\Debug\MongoDB.Bson.dll","bin\Debug\MongoDB.Driver.dll","bin\Debug\MongoDB.Driver.Core.dll","bin\Debug\Newtonsoft.Json.dll","C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationFramework.dll","bin\Debug\System.Speech.dll","C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll","C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.Smo.dll","C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.Dmf.Adapters.dll","C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.Dmf.dll","C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.DmfSqlClrWrapper.dll","C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll",Microsoft.VisualBasic.dll,System.Linq.dll,system.management.automation.dll,"E:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\ReferenceAssemblies\v4.0\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll" /nowarn:162,168,219,618,649 /unsafe
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            bool result = _primeService.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}