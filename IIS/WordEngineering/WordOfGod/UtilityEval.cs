using System;
using System.Collections.Generic;
using System.Text;

namespace WordEngineering
{
    public class UtilityEval
    {
        /// <summary>The entry point for the application.</summary>
        /// <param name="argv">A list of command line arguments</param>
        public static void Main(string[] argv)
        {
            Console.WriteLine(Eval("2*3+4"));
        }

        /// <summary>http://devdistrict.com/codedetails.aspx?A=402</summary>
        public static string Eval(string expression)
        {
            return Convert.ToString(Microsoft.JScript.Eval.JScriptEvaluate(expression, Microsoft.JScript.Vsa.VsaEngine.CreateEngine()));
        }
    }
}