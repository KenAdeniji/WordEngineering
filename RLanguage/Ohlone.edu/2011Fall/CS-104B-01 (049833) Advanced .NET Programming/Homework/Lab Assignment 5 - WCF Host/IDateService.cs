using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;

namespace Lab_Assignment_5___WCF_Host
{
    [ServiceContract]
    interface IDateService
    {
        [OperationContract]
        string Today();
    }
}
