using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace InformationInTransit.ProcessLogic
{
    public static partial class StayAwake
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(
        EXECUTION_STATE flags);

        [Flags]
        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_CONTINUOUS = 0x80000000
        }

        public static void Main(string[] argv)
        {
            SleeplessWait(1);
        }

        public static void SleeplessWait(int minutes)
        {
            SetThreadExecutionState
            (
                EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                EXECUTION_STATE.ES_CONTINUOUS
            );

            try
            {
                DateTime startTime = DateTime.Now;
                DateTime endTime;
                endTime = DateTime.Now + new TimeSpan(0, minutes, 0);
                Console.WriteLine("Staying awake until " + endTime);
                Thread.Sleep(minutes * 60000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
            }
        }
    }
}
