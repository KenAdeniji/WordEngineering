using System;
using System.Collections;
using System.Data;

namespace PeopleSoft.Security
{

    [Flags]
    public enum appSecurityRole
    {
          empty = 0
        , maintainSupportTable = 1
        , filler1 = 2
        , filler2 = 4
        , filler3 = 8
        , filler4 = 16       
        , filler5 = 32               
    }   

   	

}    