using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

//using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	/*
		2006-10-28T09:23:22	Wrote to the Roman empire asking to release Paul, and yet she just wasn't moving.
		2019-12-09			Created.
	*/	
    public partial class WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving
    {
		public static void Main(String[] argv)
		{
			Stub();
		}
		
		public static void Stub()
		{
			ObjectDumper.Write(WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovings);
		}
		
		public WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving()
		{
		
		}

        public static readonly Collection<WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving> WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovings = new Collection<WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving>
        {
            new WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving
			{ 
				Actor = "Adam (Genesis 2:7-8)",
				Event = "The Fall of Man (Genesis 3)",
				Fulfillment = "Adam died (Genesis 5:5)",
				Image = "Tree of the knowledge of good and evil (Genesis 2:9)",
				Prophecy = "Eating of the tree of good and evil will cause spiritual death (Genesis 2:16-17)"
			},
            new WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving
			{ 
				Actor = "Cain (Genesis 4:1)",
				Event = "Cain and Abel (Genesis 4)",
				Fulfillment = "Cain went out of the Presence of the LORD (Genesis 4:8-16)",
				Image = "Blood from the ground (Genesis 4:10-11)",
				Prophecy = "Sacrifice (Genesis 4:6-7)"
			}
		};
		
		public string Actor {get; set;}
		public string Event {get; set;}
		public string Fulfillment {get; set;}
		public string Image {get; set;}
		public string Prophecy {get; set;}
    }
}
