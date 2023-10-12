using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

/*
	2023-10-11T17:48:00...2023-10-11T18:51:00 Created.
*/
namespace InformationInTransit.UnifiedModelingLanguage
{
    public partial class Activity
    {
        public static void Main(string[] argv)
        {
			Stub();
        }

        public static void Stub()
        {
            //ObjectDumper.Write(Activities);
        }

        /// <summary>Indexer.</summary>
        /// <code>
        ///     <example>
        ///         Activity creation = new Activity()["Creation"];
        ///     </example>
        /// </code>
        public Activity this[string title]
        {
            get
            {
                if (String.IsNullOrEmpty(title))
                {
                    throw new ArgumentOutOfRangeException("parameter must be the name of an Activity.");
                }

                Activity Activity = Activities.SingleOrDefault(element => element.Title == title);
                if (Activity == null) throw new ArgumentOutOfRangeException("parameter must be the name of a Activity.");
                return Activity;
            }
        }

		public override bool Equals(object obj)
		{
			var other = obj as Activity;
	 
			if (other == null)
				return false;
	 
			if (Actor != other.Actor || Title != other.Title)
				return false;
	 
			return true;
		}

		public static bool operator ==(Activity x, Activity y)
		{ 
			return x.Equals(y);
		}
	 
		public static bool operator !=(Activity x, Activity y)
		{
			return !(x == y);
		}

		public override int GetHashCode()
		{
			int hashActor = Actor == null ? 0 : Actor.GetHashCode();
			int hashTitle = Title == null ? 0 : Title.GetHashCode();
	 
			return hashActor ^ hashTitle;
		}
	
        public static readonly Collection<Activity> Activities = new Collection<Activity>
        {
            new Activity
			{ 
				Actor = "God",
				Title = "Creation",
				Interval = new TimeSpan(6, 0, 0),
				ScriptureReference = "Genesis 1"
			}
        };

		public string Actor { get; set; }
		public TimeSpan Interval { get; set; }
		public string ScriptureReference { get; set; }
		public string Title { get; set; }
                
    }
}
