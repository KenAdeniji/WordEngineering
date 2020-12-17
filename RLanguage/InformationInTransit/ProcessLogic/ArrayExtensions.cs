using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ArrayExtensions
    {
        public static U[] ConvertAll<T,U>
        (
	        this T[] array,
	        Converter<T,U> converter
        )
        {
	        IEnumerable<T> enumerable = array;
            return enumerable.ConvertAll(converter).ToArray();
        }
    }
}
