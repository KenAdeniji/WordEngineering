using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
	public static partial class User32Helper
	{
		public static void Main(string[] argv)
		{
			bool isCapsLock = (((ushort) GetKeyState(0x14 /*VK_CAPITAL*/)) & 0xffff) != 0;
			bool isNumLock = (((ushort) GetKeyState(0x90 /*VK_NUMLOCK*/)) & 0xffff) != 0;
			System.Console.WriteLine
			(
				"Caps Lock: {0} | Num Lock: {1}",
				isCapsLock,
				isNumLock
			);
		}
		
		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true, CallingConvention=CallingConvention.Winapi)]
		public static extern short GetKeyState(int keyCode);
	}
}
