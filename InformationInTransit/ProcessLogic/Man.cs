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
    public partial class Man : Creature, IFemale, IMale, IDominion
    {
        public Man()
		{
			Gender = "Male";
		}
		
		/*
		/// <summary>
        /// Genesis 7:1
        /// </summary>
        public bool Righteous { get; set; }

        /// <summary>
        /// Genesis 6:9
        /// </summary>
        public bool Just { get; set; }
		*/
		
        /// <summary>
        /// Genesis 4:1-2.
        /// </summary>
        /// <param name="man">For example, Adam.</param>
        /// <param name="woman">For example, Eve.</param>
        /// <param name="child">For example, Cain, or Abel, or Seth.</param>
        public void Knew(Man man, Woman woman, Man child)
        {
            if (child != null)
            {
                woman.Conceived(child);
                woman.Bare(child);
            }
        }

		/// <summary>
        /// Genesis 2:19-23
        /// </summary>
        public void Naming(Creature namer, Creature named, String name)
        {
            named.Name = name;
        }
		
		/*
		/// <summary>
        /// Genesis 4:23
        /// </summary>
        /// <param name="young">Victim is young.</param>
        /// <returns>Convict's status, condition.</returns>
        public string Slain(bool young)
        {
            string status = "Wounding";
            if (young)
            {
                status += ", hurt";
            }
            return status;
        }
		*/
		
        /// <summary>
        /// 2015-09-04  Gerald 	Schroeder. Genesis 2:7.
        /// http://geraldschroeder.com/wordpress/?page_id=102
        /// </summary>
        public bool Soul() { return true; }
		
		/*
        /// <summary>
        /// Genesis 6:5
        /// </summary>
        public string Wicked { get; set; }
		*/
		
        static Man()
		{
			ManCollection = new Collection<Man>
			{
				new Man
				{
					FirstMention = "Genesis 4:2",
					LastMention = "Hebrews 12:24",
					Name = "Abel",
					Role = "Abel was a keeper of sheep (Genesis 4:2). By faith Abel offered unto God a more excellent sacrifice than Cain, by which he obtained witness that he was righteous, God testifying of his gifts: and by it he being dead yet speaketh (Hebrews 11:4)." //Genesis 4:2, Genesis 4:4, Matthew 23:35, Luke 11:51, Hebrews 11:4, Hebrews 12:24
				},
				new Man
				{
					FirstMention = "Genesis 17:5",
					LastMention = "1 Peter 3:6",
					Name = "Abraham",
					NameMeaning = "Neither shall thy name any more be called Abram, but thy name shall be Abraham; for a father of many nations have I made thee.", //Genesis 17:5
					YearsLived = 175 //Genesis 25:7
				},
				new Man { 
					FirstMention = "Genesis 2:19",
					LastMention = "Jude 1:14",
					Name = "Adam", //Genesis 5:2
					Role = "First man.", //Luke 3:38, Romans 5:14, 1 Corinthians 15:45, 1 Timothy 2:13
					YearsLived = 930 //Genesis 5:5
				},
				new Man
				{
					FirstMention = "Genesis 4:1",
					LastMention = "Jude 1:11",
					Name = "Cain",
					NameMeaning = "I have gotten a man from the LORD." //Genesis 4:1
				},
				new Man
				{
					FirstMention = "Genesis 17:19",
					LastMention = "James 2:21",
					Name = "Isaac",
					Role = "Now we, brethren, as Isaac was, are the children of promise.", //Galatians 4:28
					YearsLived = 180 //Genesis 35:28
				},
				new Man
				{
					FirstMention = "Matthew 3:1",
					Name = "John the Baptist",
					Role = "Front runner."
				},		
				new Man
				{
					FirstMention = "Genesis 5:29",
					//Just = true,
					LastMention = "2 Peter 2:5",
					Name = "Noah",
					NameMeaning = "This same shall comfort us concerning our work and toil of our hands, because of the ground which the LORD hath cursed.",
					YearsLived = 950 //Genesis 9:29
				},
				new Man
				{
					FirstMention = "Genesis 4:25",
					LastMention = "Luke 3:38",
					Name = "Seth",
					NameMeaning = "For God, said she, hath appointed me another seed instead of Abel, whom Cain slew.", //Genesis 4:25
					YearsLived = 912 //Genesis 5:8
				}
			};	
        }
		public static Collection<Man> ManCollection = new Collection<Man>();
    }
}
