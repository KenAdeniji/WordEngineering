using System;
using System.Collections.Generic;

/*
Date created: 2020-09-15T21:00:00
https://dev.to/genichm/design-patterns-with-examples-in-c-2588
https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
The source code for this Unsubscriber(Of BaggageInfo) class is shown in the following example. When the class is instantiated in the BaggageHandler.Subscribe method, it is passed a reference to the observers collection and a reference to the observer that is added to the collection. These references are assigned to local variables. When the object's Dispose method is called, it checks whether the observer still exists in the observers collection, and, if it does, removes the observer.
*/
namespace Microsoft.CSharp.DesignPattern.Observer
{
	internal class Unsubscriber<BaggageInfo> : IDisposable
	{
	   private List<IObserver<BaggageInfo>> _observers;
	   private IObserver<BaggageInfo> _observer;

	   internal Unsubscriber(List<IObserver<BaggageInfo>> observers, IObserver<BaggageInfo> observer)
	   {
		  this._observers = observers;
		  this._observer = observer;
	   }

	   public void Dispose()
	   {
		  if (_observers.Contains(_observer))
			 _observers.Remove(_observer);
	   }
	}
}
