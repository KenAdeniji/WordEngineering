using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// 2015-09-03 Created.
    /// </summary>
    public partial class Creature : IFruitfulMultiply
    {
		public Creature()
		{
			CreatureCollection.Add(this);
		}	

		public static Collection<Creature> CreatureCollection = new Collection<Creature>();
		
		public string FirstMention { get; set; } //Genesis 1:20
        public string Gender { get; set; }
        public string LastMention { get; set; }
        public string Name { get; set; }
        public string NameMeaning { get; set; }
        public string Role { get; set; } //Activity
        public string ScriptureReference { get; set; }
        public int YearsLived { get; set; }
    }
}
