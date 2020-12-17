using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

namespace InformationInTransit.ProcessLogic
{
    public partial class Woman : Man
    {
        public Woman()
		{
			Gender = "Female";
		}

		public void Bare(Man child)
        {

        }

        public void Conceived(Man child)
        {

        }
		
        public God ImmaculateConception()
        {
			return God.JesusChrist;
        }
		
        static Woman()
		{
			WomanCollection = new Collection<Woman>
			{
				new Woman
				{
					FirstMention = "Genesis 3:20",
					LastMention = "1 Timothy 2:13",
					Name = "Eve",
					NameMeaning = "And Adam called his wife's name Eve; because she was the mother of all living (Genesis 3:20)."
				},
				new Woman
				{
					FirstMention = "Matthew 1:16",
					LastMention = "Acts 1:14",
					Name = "Mary"
				},
				new Woman
				{
					FirstMention = "Genesis 17:15",
					LastMention = "Romans 9:9",
					Name = "Sarah",
					YearsLived = 127 //Genesis 23:1
				}				
			};
		}
		
		public static Collection<Woman> WomanCollection = new Collection<Woman>();
    }
}
