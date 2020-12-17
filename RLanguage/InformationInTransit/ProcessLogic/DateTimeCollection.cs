#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region DateTimeCollection definition
    public static partial class DateTimeCollection
    {
        #region Fields
        public static readonly List<String> DayCollection;
        public static readonly List<String> MonthNameCollection;
        public static readonly List<String> YearCollection;
        #endregion

        #region Methods
        public static DateTime? Parse(string year, int month, int day)
        {
            DateTime? dateTime = null;
            if (month > 0 && day > 0 && year != "Year")
            {
                dateTime = new DateTime(Convert.ToInt32(year), month, day);
            }
            return dateTime;
        }

        static DateTimeCollection()
        {
            DayCollection = new List<string>();
            DayCollection.Add("Day");
            for (int day = 1; day <= 31; ++day)
            {
                DayCollection.Add(day.ToString());
            }

            MonthNameCollection = new List<string>();
            MonthNameCollection.Add("Month");
            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
            for(int month = 1; month <= 12; ++month)
            {
                MonthNameCollection.Add(dateTimeFormatInfo.GetMonthName(month));
            }

            YearCollection = new List<string>();
            YearCollection.Add("Year");
            for (int year = DateTime.Today.Year; year >= 1901; --year)
            {
                YearCollection.Add(year.ToString());
            }
        }
        #endregion
    }
    #endregion
}
