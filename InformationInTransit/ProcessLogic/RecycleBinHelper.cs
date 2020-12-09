using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
    enum RecycleFlags : int
    {
        // No confirmation dialog when emptying the recycle bin
        SHERB_NoConfirmation = 0x00000001,

        // No progress tracking window during the emptying of the recycle bin
        ShellRecycleBin_NoProgressUserInterface = 0x00000001,

        // No sound whent the emptying of the recycle bin is complete
        ShellRecycleBin_NoSound = 0x00000004
    }

    public static partial class RecycleBinHelper
    {
        // Shell32.dll is where SHEmptyRecycleBin is located
        [DllImport("Shell32.dll")]
        // The signature of SHEmptyRecycleBin (located in Shell32.dll)
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        public static void Main(string[] argv)
        {
            Empty();
        }

        public static void Empty()
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.ShellRecycleBin_NoSound | RecycleFlags.SHERB_NoConfirmation);
        }
    }
}
