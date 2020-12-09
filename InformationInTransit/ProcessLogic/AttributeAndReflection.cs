#region Using directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region BugFixAttribute definition
    /// <summary>
    /// Create custom attribute to be assigned to class members
    /// </summary>
    [AttributeUsage
        (
            AttributeTargets.Class |
            AttributeTargets.Constructor |
            AttributeTargets.Field |
            AttributeTargets.Method |
            AttributeTargets.Property,
            AllowMultiple = true
        )
    ]
    public partial class BugFixAttribute : System.Attribute
    {
        #region Constructors
        /// <summary>
        /// Attribute constructor for positional parameters
        /// </summary>
        public BugFixAttribute
        (
            int bugID,
            string programmer,
            string date
        )
        {
            this.bugID = bugID;
            this.programmer = programmer;
            this.date = date;
        }
        #endregion

        #region Properties
        public int BugID
        {
            get
            {
                return bugID;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
        }

        public string Programmer
        {
            get
            {
                return programmer;
            }
        }
        #endregion

        #region Fields
        private int bugID;
        private string comment;
        private string date;
        private string programmer;
        #endregion
    }
    #endregion

    #region AttributeAndReflection definition
    [BugFixAttribute(121, "John Doe", "01/03/05")]
    [BugFixAttribute(107, "John Doe", "01/04/05", Comment = "Fixed off by one errors")]
    public partial class AttributeAndReflection
    {
        #region Methods
        public static void Main(string[] argv)
        {
            //FindingParticularMembers();
            //LateBindingDynamicallyInvokingAMethod();
            //ReflectingAnAssembly();
            //ReflectingOnAType();
            ReflectionSum reflectionSum = new ReflectionSum();
            reflectionSum.Sum(10);
            //ReflectingOnTheMembersOfAType();
            //RetrieveCustomAttributes();
        }

        public static void LateBindingDynamicallyInvokingAMethod()
        {
            Type type = Type.GetType("System.Math");
            Object math = Activator.CreateInstance(type);

            Type[] parameterTypes = new Type[1];
            parameterTypes[0] = Type.GetType("System.Double");

            MethodInfo methodInfoCosine = type.GetMethod("Cos", parameterTypes);

            Object[] parameters = new Object[1];
            parameters[0] = 45;
            Object returnValue = methodInfoCosine.Invoke(math, parameters);

            Console.WriteLine
            (
                "The cosine of 45 degrees angle {0}",
                returnValue
            );
        }
 
        public static void FindingParticularMembers()
        {
            Type type = Type.GetType("System.Reflection.Assembly");
            // just members which are methods beginning with Get
            MemberInfo[] memberInfos = type.FindMembers
            (
                MemberTypes.Method, //MemberTypes A MemberTypes object that indicates the type of the member to search for. These include All, Constructor, Custom, Event, Field, Method, Nestedtype, Property, and TypeInfo. You will also use the MemberTypes.Method to find a method.
                BindingFlags.Default, //BindingFlags An enumeration that controls the way searches are conducted by reflection. There are a great many BindingFlag values, including IgnoreCase, Instance, Public, Static, and so forth. The BindingFlags default member indicates no binding flag, which is what you want because you do not want to restrict the binding.
                Type.FilterName, //A delegate (see Chapter 12) that is used to filter the list of members in the MemberInfo array of objects. The filter you'll use is Type.FilterName, a field of the Type class used for filtering on a name.
                "Get*" //A string value that will be used by the filter. In this case you'll pass in "Get*" to match only those methods that begin with the letters Get.
            );
            
            foreach (MemberInfo memberInfo in memberInfos)
            {
                System.Console.WriteLine
                (
                    "{0} is a {1}",
                    memberInfo,
                    memberInfo.MemberType
                );
            }
        }

        public static void ReflectingAnAssembly()
        {
            Assembly assembly = Assembly.Load("Mscorlib.dll");
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("Type is {0}", type);
            }
            Console.WriteLine("{0} types found", types.Length);
        }

        public static void ReflectingOnAType()
        {
            Type type = Type.GetType("System.Reflection.Assembly");
            Console.WriteLine("\nSingle Type is {0}", type);
        }

        public static void ReflectingOnTheMembersOfAType()
        {
            Type type = Type.GetType("System.Reflection.Assembly");
            MemberInfo[] memberInfos = type.GetMembers(); //type.GetMethods();

            foreach (MemberInfo memberInfo in memberInfos)
            {
                System.Console.WriteLine
                (
                    "{0} is a {1}",
                    memberInfo,
                    memberInfo.MemberType
                );
            }
        }

        public static void RetrieveCustomAttributes()
        {
            // get the member information and use it to
            // retrieve the custom attributes
            System.Reflection.MemberInfo memberInfo = typeof(AttributeAndReflection);
            object[] attributes;
            attributes =
               memberInfo.GetCustomAttributes(
                    typeof(AttributeAndReflection), false);

            // iterate through the attributes, retrieving the 
            // properties
            foreach (Object attribute in attributes)
            {
                BugFixAttribute bugFixAttribute = (BugFixAttribute)attribute;
                Console.WriteLine("\nBugID: {0}", bugFixAttribute.BugID);
                Console.WriteLine("Programmer: {0}", bugFixAttribute.Programmer);
                Console.WriteLine("Date: {0}", bugFixAttribute.Date);
                Console.WriteLine("Comment: {0}", bugFixAttribute.Comment);
            }
        }
        #endregion
    }
    #endregion

    #region ReflectionSum definition
    public partial class ReflectionSum
    {
        #region Methods
        public long Sum(int upperBoundary)
        {
            if (type == null)
            {
                GenerateClass(upperBoundary);
            }
            object[] arguments = new object[0];
            object returnValue = type.InvokeMember
            (
                MethodName,
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                aClass,
                arguments
            );
            System.Console.WriteLine("Result: {0}", returnValue);
            return (long)returnValue;
        }

        public void GenerateClass(int upperBoundary)
        {
            string sourceFileName = Path.GetTempFileName();
            Stream stream = File.Open(sourceFileName, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(stream);
            StringBuilder sb = new StringBuilder();
            for (int index = 1; index <= upperBoundary; ++index)
            {
                sb.AppendFormat(" + {0}", index);
            }
            string classSyntax = String.Format
            (
                ClassConstruct,
                ClassName,
                MethodName,
                sb
            );                
            streamWriter.WriteLine(classSyntax);
            streamWriter.Close();
            stream.Close();

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";

            string compileCommand = String.Format
            (
                ClassCompileDynamicLinkLibraryDLL,
                sourceFileName
            );

            processStartInfo.Arguments = compileCommand;
            processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            Process process = Process.Start(processStartInfo);
            process.WaitForExit();

            string dynamicLinkLibraryFileName = Path.GetFileNameWithoutExtension(sourceFileName) + ".dll";
            //System.Console.WriteLine(dynamicLinkLibraryFileName);

            Assembly assembly = Assembly.LoadFrom(dynamicLinkLibraryFileName);
            aClass = assembly.CreateInstance(ClassName);
            type = assembly.GetType(ClassName);
        }
        #endregion

        #region Fields
        Type type = null;
        object aClass = null;
        #endregion

        #region Constants
        public const string ClassConstruct = "public partial class {0} {{ public long {1} () {{ return {2}; }} }}";
        public const string ClassCompileDynamicLinkLibraryDLL = "/c csc /optimize+ /target:library \"{0}\" > csc.out";
        public const string ClassName = "ComposeSum";
        public const string MethodName = "ComputeSum";
        #endregion
    }
    #endregion
}
