#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ObjectHelper definition
    public static partial class ObjectHelper
    {
        class ObjectHelperStub
        {
            public int Stub{ get; set;}
        }

        #region Methods
        public static void Main(string[] argv)
        {
            ObjectHelperStub objectHelperStub = new ObjectHelperStub { Stub = 1 };
            System.Console.WriteLine(objectHelperStub.DisplayObjectInfo());
        }

        public static string DisplayObjectInfo(this Object o)
        {
            StringBuilder sb = new StringBuilder();

            // Include the type of the object
            System.Type type = o.GetType();
            sb.Append("Type: " + type.Name);

            // Include information for each Field
            sb.AppendFormat("{0}{0}Fields:", System.Environment.NewLine);
            System.Reflection.FieldInfo[] fi = type.GetFields();
            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
                {
                    sb.Append("\r\n " + f.ToString() + " = " + f.GetValue(o));
                }
            }
            else
            {
                sb.AppendFormat("{0}None", System.Environment.NewLine);
            }

            // Include information for each Property
            sb.AppendFormat("{0}{0}Properties:", System.Environment.NewLine);
            System.Reflection.PropertyInfo[] pi = type.GetProperties();
            if (pi.Length > 0)
            {
                foreach (PropertyInfo p in pi)
                {
                    sb.Append("\r\n " + p.ToString() + " = " +
                              p.GetValue(o, null));
                }
            }
            else
            {
                sb.AppendFormat("{0}None", System.Environment.NewLine);
            }
            return sb.ToString();
        }

        public static bool IsNotNullOrEmpty(this string input)
        {
            return !String.IsNullOrEmpty(input);
        }

        public static bool IsNull(this object source)
        {
            return source == null;
        }
        #endregion
    }
    #endregion
}
