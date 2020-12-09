using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
	public interface IPersonalInfo
	{
		string FirstName();
		string LastName();
        string Gender { get; }  
	}

    /// <summary>
    /// ActiveX control
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public partial class ActiveXInfo : IPersonalInfo
    {
        public string FirstName()
        {
            return "John";
        }
        public string LastName()
        {
            return "Smith";
        }
        public string Gender
        {
            get { return "Male"; }
        }
    }
}

