using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace InformationInTransit.ProcessLogic
{
    [ServiceContract]
    public partial interface IWcfServiceAsynchrously
    {
        [OperationContract]
        string SayHelloWorld();
    }
}
