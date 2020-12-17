using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml.Serialization;

namespace InformationInTransit.ProcessLogic
{
    public static partial class XmlHelper
    {
        public static string ToXml(this object source)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(sw, source);

            return sb.ToString();
        }
    }
}
