using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Timers;

namespace Clicker
{
    public enum MouseButton
    {
        LEFT,
        RIGHT
    }

    public class ClickerAction
    {
        public int xPos;
        public int yPos;
        public MouseButton button;

        public ClickerAction(int xPos, int yPos, MouseButton button)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.button = button;
        }

        public void Invoke()
        {
            int mouseUp, mouseDown;

            INPUT input = new INPUT() { type = INPUT_MOUSE };

            input.mi.dx = xPos;
            input.mi.dy = yPos;
            input.mi.dwExtraInfo = IntPtr.Zero;
            input.mi.mouseData = 0;
            input.mi.time = 0;

            // Get click type(s)
            switch (button)
            {
                case MouseButton.RIGHT:
                    mouseDown = MOUSEEVENTF_RIGHTDOWN;
                    mouseUp = MOUSEEVENTF_RIGHTUP;
                    break;
                case MouseButton.LEFT:
                default:
                    mouseDown = MOUSEEVENTF_LEFTDOWN;
                    mouseUp = MOUSEEVENTF_LEFTUP;
                    break;
            }

            // Press mouse
            input.mi.dwFlags = mouseDown;
            SendInput(1, ref input, Marshal.SizeOf(input));

            // Release mouse
            input.mi.dwFlags = mouseUp;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }

        #region Mouse input

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendInput(int nInputs, ref INPUT pInputs,
                                   int cbSize);

        //mouse event constants
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //input type constant
        const int INPUT_MOUSE = 0;

        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        public struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        };

        #endregion
    }

    public class ClickerTimer
    {
        public Timer timer;
        public ClickerAction action;

        private double _interval;

        public double maxIntervalDeviation;

        public double interval
        {
            get => timer.Interval;
            set => timer.Interval = value;
        }

        public bool running { get; private set; }

        public ClickerTimer(double interval, int mouseX, int mouseY, MouseButton buttonPressed)
        {
            _interval = interval;

            action = new ClickerAction(mouseX, mouseY, buttonPressed);
            timer = new Timer(interval);
            timer.Elapsed += timer_OnTick;
        }

        #region Events

        public async void timer_OnTick(object source, ElapsedEventArgs e)
        {
            if (maxIntervalDeviation > 0)
            {
                // Generate a random interval to click at for the next iteration
                interval = _interval + new Random().Next((int)-maxIntervalDeviation, (int)maxIntervalDeviation);
            }

            //await Task.Run(() => action.Invoke());
            action.Invoke();
        }

        #endregion

        #region Methods


        public void Start()
        {
            if (!running)
            {
                timer.Start();
            }

            running = true;
        }

        public void Stop()
        {
            if (running)
            {
                timer.Stop();
            }

            running = false;
        }

        #endregion

    }
}
