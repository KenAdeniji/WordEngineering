#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region TestHelp definition
    public static partial class TestHelp
    {
        #region Methods
        public static void Main()
        {
            ShowHelp(typeof(Widget));
            ShowHelp(typeof(Widget).GetMethod("Display"));
        }

        public static void ShowHelp(MemberInfo memberInfo)
        {
            Attribute attribute = Attribute.GetCustomAttribute
            (
                memberInfo,
                typeof(HelpAttribute)
            );
            HelpAttribute helpAttribute = attribute as HelpAttribute;
            if (helpAttribute == null)
            {
                System.Console.WriteLine("No help for {0}", memberInfo);
            }
            else
            {
                System.Console.WriteLine("Help for {0}", memberInfo);
                System.Console.WriteLine
                (
                    "  Url={0}, Topic={1}",
                    helpAttribute.Url,
                    helpAttribute.Topic
                );
            }
        }
        #endregion
    }
    #endregion
}
