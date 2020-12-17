using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_Assignment_5___WCF_Host
{
    class DateService : IDateService
    {
        public string Today()
        {
            return DateTime.Today.ToShortDateString();
        }
    }
}

