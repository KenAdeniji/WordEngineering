using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /*
    Basically, if you want to add a feature to several files, but cannot use one base class for all, get each class to implement an interface (with no members). Then, write an extension method for the interface, i.e.

    public static DeepCopy(this IPrototype p) { ... }
    */ 
    public interface IInterfaceExtensionMethod{}

    public static partial class ExtensionMethod
    {
        public static void DeepCopy(this IInterfaceExtensionMethod p) {}
    }

    public partial class ExtensionMethodA : IInterfaceExtensionMethod { }

    public partial class ExtensionMethodB : IInterfaceExtensionMethod { }

    public static partial class ExtensionMethod1
    {
        public static void Main(string[] argv)
        {
            ExtensionMethodA extensionMethodA = new ExtensionMethodA();
            extensionMethodA.DeepCopy();

            ExtensionMethodB extensionMethodB = new ExtensionMethodB();
            extensionMethodB.DeepCopy();
        }
    }
}
