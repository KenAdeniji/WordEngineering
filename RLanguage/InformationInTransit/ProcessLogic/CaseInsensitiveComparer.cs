using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace InformationInTransit.ProcessLogic
//{
    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }
    }
//}
