using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// Multithreaded support. 
    /// </summary>
    public class SynchronizeHelper
    {
        private object syncHandle = new object();
        private string name;
        public string Name
        {
            get
            {
                lock (syncHandle)
                    return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(
                    "Name cannot be blank",
                    "Name");
                lock (syncHandle)
                    name = value;
            }
        }
    }
}
