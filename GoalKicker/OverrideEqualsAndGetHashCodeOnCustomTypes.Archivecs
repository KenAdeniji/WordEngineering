using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

/*
	2018-08-13	https://goalkicker.com/CSharpBook/CSharpNotesForProfessionals.pdf
*/
namespace InformationInTransit.GoalKicker
{
	public static partial class OverrideEqualsAndGetHashCodeOnCustomTypes
	{
		public static void Main(string[] argv)
		{
			var nonEssentialComparison1 = new NonEssentialComparison { Name = "Jon", Age = 20, Clothes = "some clothes" };
			var nonEssentialComparison2 = new NonEssentialComparison { Name = "Jon", Age = 20, Clothes = "some other clothes" };
			bool result = nonEssentialComparison1.Equals(nonEssentialComparison2); // result is true
			//Also using LINQ to make diﬀerent queries on nonEssentialComparisons will check both Equals and GetHashCode:
			var nonEssentialComparisons = new List<NonEssentialComparison>
			{
				new NonEssentialComparison{ Name = "Jon", Age = 20, Clothes = "some clothes"},
				new NonEssentialComparison{ Name = "Dave", Age = 20, Clothes = "some other clothes"},
				new NonEssentialComparison{ Name = "Jon", Age = 20, Clothes = ""} 
			};
			var distinctNonEssentialComparisons = nonEssentialComparisons.Distinct().ToList();//distinctNonEssentialComparisons has Count 	
		}
    }
	
	public class NonEssentialComparison
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Clothes { get; set; }
		public override bool Equals(object obj)
		{
			var nonEssentialComparison = obj as NonEssentialComparison;
			if (nonEssentialComparison == null) return false;
			return Name == nonEssentialComparison.Name && Age == nonEssentialComparison.Age; //the clothes are not important when comparing two nonEssentialComparisons    
		}
		public override int GetHashCode()
		{ 
			return Name.GetHashCode()*Age;    
		} 
	}
}
