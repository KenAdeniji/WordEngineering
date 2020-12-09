using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting;

namespace InformationInTransit.ProcessLogic
{
    public class SampleRemoteClass : MarshalByRefObject
    {
        private int callCount = 0;

        public int GetCount()
        {
            callCount++;
            return (callCount);
        }
    }
}
