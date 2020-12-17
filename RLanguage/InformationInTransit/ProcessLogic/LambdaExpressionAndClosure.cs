#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region LambdaExpressionAndClosure definition
    public static partial class LambdaExpressionAndClosure
    {
        #region Methods
        public static void Main(string[] argv)
        {
            Step1();
            Step2();
        }

        public static void Step1()
        {
            var manipulation = Enumerable.Range(0, 10).Select(n =>
                {
                    int temp = n + 5;
                    temp = temp * temp;
                    return temp;
                }
            );

            foreach (var value in manipulation)
            {
                System.Console.WriteLine(value);
            }
        }

        public static void Step2()
        {
            int previousAnswer = 0;
            var manipulation = Enumerable.Range(0, 10).Select(n =>
                {
                    int temp = n + previousAnswer;
                    previousAnswer = temp;
                    return temp;
                }
            );

            foreach (var value in manipulation)
            {
                System.Console.WriteLine(value);
            }
        }
        #endregion
    }
    #endregion
}

