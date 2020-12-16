using System;
using System.Collections.Generic;

/*
Date created: 2020-09-15T20:47:00
https://dev.to/genichm/design-patterns-with-examples-in-c-2588
https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
The following example uses the observer design pattern to implement an airport
baggage claim information system. A BaggageInfo class provides information about
arriving flights and the carousels where baggage from each flight is available for pickup.
It is shown in the following example.
*/
namespace Microsoft.CSharp.DesignPattern.Observer
{
	public class BaggageInfo
	{
	   private int flightNo;
	   private string origin;
	   private int location;

	   internal BaggageInfo(int flight, string from, int carousel)
	   {
		  this.flightNo = flight;
		  this.origin = from;
		  this.location = carousel;
	   }

	   public int FlightNumber {
		  get { return this.flightNo; }
	   }

	   public string From {
		  get { return this.origin; }
	   }

	   public int Carousel {
		  get { return this.location; }
	   }
	}
}
