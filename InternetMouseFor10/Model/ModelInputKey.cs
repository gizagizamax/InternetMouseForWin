using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace InternetMouse.Model
{
    public class ModelInputKey : ModelInput
    {
        byte bVk;
        int dwFlags;

        public ModelInputKey(byte bVk, int dwFlags)
        {
            this.bVk = bVk;
            this.dwFlags = dwFlags;
        }

        public override void Input()
        {
            keybd_event(this.bVk, 0, this.dwFlags, this.MessageExtraInfo);
        }

        int ExtendedKeyFlagW()
        {
            switch (this.bVk)
            {
                case 0x03:// BREAK(Control+Pause) key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x21:// PAGE UP key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x22:// PAGE DOWN key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x23:// END key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x24:// HOME key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x25:// ← key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x26:// ↑ key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x27:// → key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x28:// ↓ key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x2C:// PRINT SCREEN key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x2D:// INS key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x2E:// DEL key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x6F:// / key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0x90:// NUM LOCK key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0xA1:// Right SHIFT key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0xA3:// Right CONTROL key(ExtendedKey)
                    return this.dwFlags + 1;
                case 0xA5:// Right MENU key(ExtendedKey)
                    return this.dwFlags + 1;
                default:
                    return this.dwFlags;
            }
        }
    }
}
