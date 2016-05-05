using System;
using System.Runtime.InteropServices;

namespace InternetMouse.Model
{
    public class ModelInput
    {
        [DllImport("user32.dll")]
        //public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);
        public static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, IntPtr dwExtraInfo);

        [DllImport("USER32.dll", CallingConvention = CallingConvention.StdCall)]
        //public static extern uint mouse_event(uint dwFlags, uint dx, uint dy, int cButtons, IntPtr dwExtraInfo);
        public static extern uint mouse_event(int dwFlags, int dx, int dy, int cButtons, IntPtr dwExtraInfo);

        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetMessageExtraInfo();

        static IntPtr? _MessageExtraInfo;
        public IntPtr MessageExtraInfo
        {
            get
            {
                return _MessageExtraInfo ?? (_MessageExtraInfo = GetMessageExtraInfo()).Value;
            }
        }

        public virtual void Input()
        {
        }
    }
}
