using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
    public static partial class CompactDiscHelper
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);

        public static void Main(string[] argv)
        {
            Operation(argv[0], argv[1]);
        }

        /// <param name="operation">Open, closed.</param>
        public static void Operation(string driveLetter, string operation)
        {
            string driveAlias = String.Format(DriveAlias, driveLetter);
            mciSendString(driveAlias, null, 0, IntPtr.Zero);

            string driveOperation = String.Format(DriveOperation, driveLetter, operation);
            mciSendString(driveOperation, null, 0, IntPtr.Zero);
        }

        public const string DriveAlias = "open {0}: type CDAudio alias drive{0}";
        public const string DriveOperation = "set drive{0} door {1}";
    }
}
