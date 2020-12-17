#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region DelegateHelper definition
    public class DelegateHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            MethodType();
        }

        public static void MethodType()
        {
            //Declaration of a delegate variable
            Notifier greetings;

            greetings = new Notifier(SayHello);
            greetings += new Notifier(SayGoodBye);

            //Calling a delegate variable
            greetings("John");// invokes SayHello("John") => "Hello from John"
        }
        #endregion

        static void SayGoodBye(string sender)
        {
            Console.WriteLine("Good bye from " + sender);
        }

        //Assigning a method to a delegate variable
        static void SayHello(string sender)
        {
            Console.WriteLine("Hello from " + sender);
        }

        //Declaration of a delegate type
        delegate void Notifier(string sender);// ordinary method signature
        //with the keyword delegate
    }
    #endregion
}
