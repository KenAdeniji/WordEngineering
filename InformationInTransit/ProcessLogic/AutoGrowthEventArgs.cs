using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public partial class AutoGrowthEventArgs : EventArgs
    {
        public static void Main(string[] argv)
        {
            System.Console.WriteLine(DefaultData);
            System.Console.WriteLine(DefaultLog);
        }

        public static AutoGrowthEventArgs Parse(string autoGrowthContent)
        {
            AutoGrowthEventArgs autoGrowthEventArgs = new AutoGrowthEventArgs();

            int noneIndexOf = autoGrowthContent.IndexOf("None", StringComparison.InvariantCultureIgnoreCase);
            if (noneIndexOf > -1)
            {
                autoGrowthEventArgs.EnableAutogrowth = false;
                return autoGrowthEventArgs;
            }

            autoGrowthEventArgs.EnableAutogrowth = true;

            int commaIndexOf = autoGrowthContent.IndexOf(",", StringComparison.InvariantCultureIgnoreCase);
            string by = autoGrowthContent.Substring(0, commaIndexOf);

            int spaceIndexOf = autoGrowthContent.IndexOf(" ", 3, StringComparison.InvariantCultureIgnoreCase);
            string byText = autoGrowthContent.Substring(3, spaceIndexOf - 3);
            Int64 byValue = -1;
            bool parse = Int64.TryParse(byText, out byValue);
            string byUnit = by.Substring(spaceIndexOf + 1);

            if (byUnit.Equals("MB", StringComparison.InvariantCultureIgnoreCase))
            {
                autoGrowthEventArgs.FileGrowth = FileGrowthInPercentInMegabytes.InMegabytes;
            }
            else
            {
                autoGrowthEventArgs.FileGrowth = FileGrowthInPercentInMegabytes.InPercent;
            }

            autoGrowthEventArgs.FileGrowthInPercentSize = byValue;

            int unrestrictedGrowthIndexOf = autoGrowthContent.IndexOf("unrestricted Growth", StringComparison.InvariantCultureIgnoreCase);

            if (unrestrictedGrowthIndexOf == -1)
            {
                int restrictedGrowthToIndexOf = autoGrowthContent.LastIndexOf(" ", StringComparison.InvariantCultureIgnoreCase);
                string restrictedGrowthText = autoGrowthContent.Substring(restrictedGrowthToIndexOf + 1);
                Int64 restrictedGrowthValue = -1;
                parse = Int64.TryParse(restrictedGrowthText, out restrictedGrowthValue);
                autoGrowthEventArgs.MaximumFileSize = MaximumFileSizeRestrictedUnrestrictedFileGrowth.RestrictedFileGrowth;
                autoGrowthEventArgs.MaximumFileSizeRestrictedFileGrowth = restrictedGrowthValue;
            }
            else
            {
                autoGrowthEventArgs.MaximumFileSize = MaximumFileSizeRestrictedUnrestrictedFileGrowth.UnrestrictedFileGrowth;
            }

            return autoGrowthEventArgs;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!EnableAutogrowth) { return "None"; }
            if (FileGrowth == FileGrowthInPercentInMegabytes.InPercent)
            {
                sb.AppendFormat("By {0} percent, ", FileGrowthInPercentSize);
            }
            else
            {
                sb.AppendFormat("By {0} MB, ", FileGrowthInMegaBytesSize);
            }
            if (MaximumFileSize == MaximumFileSizeRestrictedUnrestrictedFileGrowth.RestrictedFileGrowth)
            {
                sb.AppendFormat
                (
                    "restricted growth to {0}",
                    MaximumFileSizeRestrictedFileGrowth
                );
            }
            else
            {
                sb.Append("unrestricted growth");
            }
            return sb.ToString();
        }

        public AutoGrowthEventArgs() { }

        public AutoGrowthEventArgs
        (
            bool enableAutogrowth,
            FileGrowthInPercentInMegabytes fileGrowth,
            long? fileGrowthInMegaBytesSize,
            long? fileGrowthInPercentSize,
            MaximumFileSizeRestrictedUnrestrictedFileGrowth maximumFileSize,
            long? maximumFileSizeRestrictedFileGrowth 
        )
        {
            EnableAutogrowth = enableAutogrowth;
            FileGrowth = fileGrowth;
            FileGrowthInMegaBytesSize = fileGrowthInMegaBytesSize;
            FileGrowthInPercentSize = fileGrowthInPercentSize;
            MaximumFileSize = maximumFileSize;
            MaximumFileSizeRestrictedFileGrowth = maximumFileSizeRestrictedFileGrowth;
        }

        //By 1 MB, unrestricted growth
        public static readonly AutoGrowthEventArgs DefaultData = new AutoGrowthEventArgs
        {
            EnableAutogrowth = true,
            FileGrowth = FileGrowthInPercentInMegabytes.InMegabytes,
            FileGrowthInMegaBytesSize = 1,
            FileGrowthInPercentSize = 10,
            MaximumFileSize = MaximumFileSizeRestrictedUnrestrictedFileGrowth.UnrestrictedFileGrowth,
            MaximumFileSizeRestrictedFileGrowth = 100
        };

        //By 10 percent, unrestricted growth
        public static readonly AutoGrowthEventArgs DefaultLog = new AutoGrowthEventArgs
        {
            EnableAutogrowth = true,
            FileGrowth = FileGrowthInPercentInMegabytes.InPercent,
            FileGrowthInMegaBytesSize = 1,
            FileGrowthInPercentSize = 10,
            MaximumFileSize = MaximumFileSizeRestrictedUnrestrictedFileGrowth.UnrestrictedFileGrowth,
            MaximumFileSizeRestrictedFileGrowth = 100
        };

        public bool EnableAutogrowth { get; set; }
        public FileGrowthInPercentInMegabytes FileGrowth { get; set; }
        public long? FileGrowthInMegaBytesSize { get; set; }
        public long? FileGrowthInPercentSize { get; set; }
        public MaximumFileSizeRestrictedUnrestrictedFileGrowth MaximumFileSize { get; set; }
        public long? MaximumFileSizeRestrictedFileGrowth { get; set; }
    }

    public enum FileGrowthInPercentInMegabytes
    {
        InPercent,
        InMegabytes
    }

    public enum MaximumFileSizeRestrictedUnrestrictedFileGrowth
    {
        RestrictedFileGrowth,
        UnrestrictedFileGrowth
    }

    public delegate void AutoGrowthEventHandler(object sender, AutoGrowthEventArgs a);
}
