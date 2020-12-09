using System.Diagnostics.Contracts;
namespace WordEngineering
{
    class CodeContract
    {
        static void Main(string[] args)
        {
            CalculatorPreCondition preCondition = new CalculatorPreCondition();
            preCondition.Add(7, 101);

            CalculatorPostCondition postCondition = new CalculatorPostCondition();
            postCondition.Add(20, 120);

            CalculatorInvariant invariant = new CalculatorInvariant();
            invariant.Value1 = 100;
            invariant.Value2 = 20;
            invariant.Sub();
        }
    }

    public class CalculatorPreCondition
    {
        public int Add(int value1, int value2)
        {
            //Check for the parameter validation using precondition
            Contract.Requires(value1 > 10, "Value 1 should be greater than 10");
            Contract.Requires(value2 > 100, "Value 2 should be less than 100");

            return value1 + value2;
        }
    }

    public class CalculatorPostCondition
    {
        int value3 = 0;
        public int Add(int value1, int value2)
        {
            //Check for the return value using post condition
            //Post-condition would work even though the ensures statement is
            //placed above the line where the actual value for Value3 is set.
            Contract.Ensures(value3 < 110, "Value 3 should be less than 110");

            return value3 = value1 + value2;
        }
    }

    public class CalculatorInvariant
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Sub()
        {
            return Value1 - Value2;
        }

        [ContractInvariantMethod]
        private void ContractInvariant()
        {
            Contract.Invariant(this.Value1 > this.Value2, "Value 1 should always be greater than Value 2");
        }
    }
}
