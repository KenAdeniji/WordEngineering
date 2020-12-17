#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region OrderByHelper definition
    public static partial class OrderByHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            //bool descending = (sortDirection = SortDirection.Descending);
            bool descending = true;
            Collection<AdventureWorksPersonContact> adventureWorksPersonContacts = AdventureWorksPersonContact.Select();
            var adventureWorksPersonContactsSorted = adventureWorksPersonContacts.OrderBy(descending, c => c.FirstName, c => c.EmailPromotion);
            ObjectDumper.Write(adventureWorksPersonContactsSorted);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> keySelector, bool descending)
        {
            if (enumerable == null)
            {
                return null;
            }

            if (descending)
            {
                return enumerable.OrderByDescending(keySelector);
            }

            return enumerable.OrderBy(keySelector);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, IComparable> keySelector1, Func<TSource, IComparable> keySelector2, params Func<TSource, IComparable>[] keySelectors)
        {
            if (enumerable == null)
            {
                return null;
            }

            IEnumerable<TSource> current = enumerable;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i]);
                }
            }

            current = current.OrderBy(keySelector2);

            return current.OrderBy(keySelector1);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, bool descending, Func<TSource, IComparable> keySelector, params Func<TSource, IComparable>[] keySelectors)
        {
            if (enumerable == null)
            {
                return null;
            }

            IEnumerable<TSource> current = enumerable;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i], descending);
                }
            }

            return current.OrderBy(keySelector, descending);
        }
        #endregion
    }
    #endregion
}
