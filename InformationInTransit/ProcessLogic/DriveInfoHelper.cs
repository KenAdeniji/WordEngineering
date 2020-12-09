using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace InformationInTransit.ProcessLogic
{
    public static partial class DriveInfoHelper
    {
        public static void Main(string[] argv)
        {
            DriveInfoFixed();
        }

        public static List<System.IO.DriveInfo> DriveInfoFixed()
        {
            List<System.IO.DriveInfo> drives = 
                System.IO.DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Fixed).ToList();
            ObjectDumper.Write(drives);
            return drives;
        }
    }
}
