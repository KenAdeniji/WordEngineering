using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static class Primes
    {
        // Find all prime factors.
        public static IEnumerable<int> PrimeFactors(long number)
        {
            // Start by removing the lowest prime (2)
            return MorePrimeFactors(number, 2);
        }
        // This recursive method finds all prime factors.
        private static IEnumerable<int> MorePrimeFactors(long number, int factor)
        {
            // Find the next prime factor
            while (number % factor != 0)
                factor++;
            // Return it.
            yield return factor;

            // look again...
            if (number > factor)
                // recursively look for this factor again, using Num/factor
                // as the new big number
                foreach (int factors in MorePrimeFactors(number / factor, factor))
                    yield return factors;
        }
    }
}
