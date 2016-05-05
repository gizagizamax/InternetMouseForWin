using System.Threading;

namespace InternetMouse.Model
{
    public class ModelInputMouse : ModelInput
    {
        /// <summary>
        /// MOUSEEVENTF_MOVE            0x0001 mouse move
        /// MOUSEEVENTF_LEFTDOWN        0x0002 left button down
        /// MOUSEEVENTF_LEFTUP          0x0004 left button up
        /// MOUSEEVENTF_RIGHTDOWN       0x0008 right button down
        /// MOUSEEVENTF_RIGHTUP         0x0010 right button up
        /// MOUSEEVENTF_MIDDLEDOWN      0x0020 middle button down
        /// MOUSEEVENTF_MIDDLEUP        0x0040 middle button up
        /// MOUSEEVENTF_XDOWN           0x0080 x button down
        /// MOUSEEVENTF_XUP             0x0100 x button down
        /// MOUSEEVENTF_WHEEL           0x0800 wheel button rolled
        /// MOUSEEVENTF_HWHEEL          0x1000 hwheel button rolled
        /// MOUSEEVENTF_MOVE_NOCOALESCE 0x2000 do not coalesce mouse moves
        /// MOUSEEVENTF_VIRTUALDESK     0x4000 map to entire virtual desktop
        /// MOUSEEVENTF_ABSOLUTE        0x8000 absolute move
        /// </summary>
        int dwFlags;
        int dx;
        int dy;
        /// <summary>
        /// スクロール値
        /// </summary>
        int cButtons;

        public ModelInputMouse(int dwFlags, int dx, int dy, int cButtons)
        {
            this.dwFlags = dwFlags;
            this.dx = dx;
            this.dy = dy;
            this.cButtons = cButtons;
        }

        public override void Input()
        {
            if (this.dx > 0 || this.dy > 0)
            {
                for(var i = 1; i <= 10; i++)
                {
                    new Thread(() =>
                    {
                        Thread.Sleep(i * 100);
                        var x = (this.dx * i / 10) - (this.dx * (i - 1) / 10);
                        var y = (this.dy * i / 10) - (this.dy * (i - 1) / 10);
                        mouse_event(this.dwFlags, x, y, this.cButtons, this.MessageExtraInfo);
                    }).Start();
                }
                return;
            }
            mouse_event(this.dwFlags, this.dx, this.dy, this.cButtons, this.MessageExtraInfo);
        }
    }
}
