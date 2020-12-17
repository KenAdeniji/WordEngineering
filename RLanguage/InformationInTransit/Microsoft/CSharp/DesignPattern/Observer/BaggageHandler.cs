using System;
using System.Collections.Generic;

/*
Date created: 2020-09-15T20:53:00
https://dev.to/genichm/design-patterns-with-examples-in-c-2588
https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
A BaggageHandler class is responsible for receiving information about arriving flights and baggage claim carousels. Internally, it maintains two collections:

    observers - A collection of clients that will receive updated information.

    flights - A collection of flights and their assigned carousels.

Both collections are represented by generic List<T> objects that are instantiated in the BaggageHandler class constructor. The source code for the BaggageHandler class is shown in the following example.
*/
namespace Microsoft.CSharp.DesignPattern.Observer
{
	public class BaggageHandler : IObservable<BaggageInfo>
	{
	   private List<IObserver<BaggageInfo>> observers;
	   private List<BaggageInfo> flights;

	   public BaggageHandler()
	   {
		  observers = new List<IObserver<BaggageInfo>>();
		  flights = new List<BaggageInfo>();
	   }

	   public IDisposable Subscribe(IObserver<BaggageInfo> observer)
	   {
		  // Check whether observer is already registered. If not, add it
		  if (! observers.Contains(observer)) {
			 observers.Add(observer);
			 // Provide observer with existing data.
			 foreach (var item in flights)
				observer.OnNext(item);
		  }
		  return new Unsubscriber<BaggageInfo>(observers, observer);
	   }

	   // Called to indicate all baggage is now unloaded.
	   public void BaggageStatus(int flightNo)
	   {
		  BaggageStatus(flightNo, String.Empty, 0);
	   }

	   public void BaggageStatus(int flightNo, string from, int carousel)
	   {
		  var info = new BaggageInfo(flightNo, from, carousel);

		  // Carousel is assigned, so add new info object to list.
		  if (carousel > 0 && ! flights.Contains(info)) {
			 flights.Add(info);
			 foreach (var observer in observers)
				observer.OnNext(info);
		  }
		  else if (carousel == 0) {
			 // Baggage claim for flight is done
			 var flightsToRemove = new List<BaggageInfo>();
			 foreach (var flight in flights) {
				if (info.FlightNumber == flight.FlightNumber) {
				   flightsToRemove.Add(flight);
				   foreach (var observer in observers)
					  observer.OnNext(info);
				}
			 }
			 foreach (var flightToRemove in flightsToRemove)
				flights.Remove(flightToRemove);

			 flightsToRemove.Clear();
		  }
	   }

	   public void LastBaggageClaimed()
	   {
		  foreach (var observer in observers)
			 observer.OnCompleted();

		  observers.Clear();
	   }
	}
}
