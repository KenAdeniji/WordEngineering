using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public partial class WcfServiceAsynchrously : IWcfServiceAsynchrously
    {
        public string SayHelloWorld()
        {
            //Simulate it running longer than it usually takes for the page to handle request
            System.Threading.Thread.Sleep(5000);
            return "Hello World";
        }
    }
}
