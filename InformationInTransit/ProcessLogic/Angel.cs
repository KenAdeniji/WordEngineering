using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// 2015-09-03 Created.
    /// </summary>
    class Angel : Creature
    {
        public static Angel Gabriel = new Angel
        {
            Gender = "Male",
            FirstMention = "Daniel 8:16",
            LastMention = "Luke 1:26",
            Name = "Gabriel",
            Role = "Messianic prophecy (Luke 1:19, Luke 1:26).",
            ScriptureReference = "Daniel 8:16, Daniel 9:21, Luke 1:19, Luke 1:26"
        };

        public static Angel Michael = new Angel
        {
            Gender = "Male",
            FirstMention = "Daniel 10:13",
            LastMention = "Revelation 12:7",
            Name = "Michael",
            Role = "One of the chief princes (Daniel 10:13).",
            ScriptureReference = "Daniel 10:13, Daniel 10:21, Daniel 12:1, Jude 1:9, Revelation 12:7"
        };
    }
}
