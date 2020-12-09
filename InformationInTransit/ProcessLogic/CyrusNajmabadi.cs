#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

using InformationInTransit.ProcessLogic;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region CyrusNajmabadi definition
    public static partial class CyrusNajmabadi
    {
        #region Methods
        public static void Main(string[] argv)
        {
            Collection<AdventureWorksPersonContact> adventureWorksPersonContacts = AdventureWorksPersonContact.Select();

            var suffixJrsNames = adventureWorksPersonContacts.Where(c => c.Suffix == "Jr.").Select(c => c.LastName);
            System.Console.WriteLine(suffixJrsNames.Count());
        }
        #endregion
    }
    #endregion
}
