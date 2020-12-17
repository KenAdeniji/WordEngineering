using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class CollectionExtensions
    {
        public static IEnumerable<U> ConvertAll<T, U>
        (
            this IEnumerable<T> collection,
            Converter<T, U> converter
        )
        {
            foreach(T item in collection) 
            {
                yield return converter(item);
            } 
        }
    }
}
