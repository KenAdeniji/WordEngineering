using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

namespace InformationInTransit.OceanSenior
{
    /*
		2019-02-03	Created.
		2019-02-07	Lights.Clear(); Lights.TrimExcess(); or Lights.Capacity = 0;
	*/
	public partial class Light
    {
        public static void Main(string[] argv)
        {
			Stub();	
        }

        public static void Stub()
        {
            ObjectDumper.Write(Lights);
        }

		//The sun and the moon differs from the stars in brightness.
        public string Intensity
        {
            get; set;
        }

        public string Title 
        {
            get; set;
        }
		
		//Joshua 10:12
		public void Intermission()
		{
		}	
		
		[XmlArray("Lights")]
		[XmlArrayItem("Light")]
        public static readonly Collection<Light> Lights = new Collection<Light>
        {
            new Light{ Title = "Sun", Intensity = "Greater"},
			new Light{ Title = "Moon", Intensity = "Lesser"},			
        };   
    }
}
