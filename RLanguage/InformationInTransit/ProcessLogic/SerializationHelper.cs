#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Windows.Markup;
using System.Xml.Serialization;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region SerializationHelper definition
    public static partial class SerializationHelper
    {
        #region Methods

        public static object FromJson<T>(string json) where T : class
        {
            MemoryStream ms = null;
            DataContractJsonSerializer ser;
            object obj; 
            try
            {
                ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                ser = new DataContractJsonSerializer(typeof(T));
                obj = ser.ReadObject(ms) as T;
            }
            finally
            {
                ms.Close();
                ms.Dispose();
            }
            return obj;
        } 

        public static string ToJsonObsolete(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        
        /*
        public static string ToJson(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }
        */

        public static string ToJson<T>(this T obj)
        {
            MemoryStream stream = new MemoryStream();

            try
            {
                //serialize data to a stream, then to a JSON string
                /* The DataContractJsonSerializer requires using System.Runtime.Serialization.Json; 
                 * which is in the System.ServiceModel.Web assembly.
                */
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, obj);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
        } 

        public static string ToXaml(this object obj)
        {
            return XamlWriter.Save(obj);
        }
        #endregion
    }
    #endregion
}
