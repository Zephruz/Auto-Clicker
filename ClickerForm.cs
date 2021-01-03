using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Clicker
{
    public partial class ClickerForm : Form
    {
        private KeyHandler ghk;
        private ClickerTimer clickerTimer;

        private const Keys DEFAULT_KEY = Keys.C;
        private const int DEFAULT_INTERVAL = 1000;
        private const int DEFAULT_DEVIATIONINTERVAL = 100;

        public ClickerForm()
        {
            InitializeComponent();

            TopMost = true;

            // Setup timer
            clickerTimer = new ClickerTimer(DEFAULT_INTERVAL, MousePosition.X, MousePosition.Y, MouseButton.LEFT);

            // Setup UI fields
            nsClickInterval.Value = DEFAULT_INTERVAL;
            nsIntDeviation.Value = DEFAULT_DEVIATIONINTERVAL;

            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                cbKeySelection.Items.Add(key);

                if (key == DEFAULT_KEY)
                {
                    cbKeySelection.SelectedIndex = cbKeySelection.Items.IndexOf(key);
                }
            }
        }

        private void HandleHotkey()
        {
            if (clickerTimer == null) return;

            clickerTimer.action.xPos = MousePosition.X;
            clickerTimer.action.yPos = MousePosition.Y;

            if (clickerTimer.running)
            {
                clickerTimer.Stop();
                tsIsRunning.Text = "Not Running";
            }
            else
            {
                clickerTimer.Start();
                tsIsRunning.Text = "Running";
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                HandleHotkey();
            }

            base.WndProc(ref m);
        }

        private void nsClickInterval_ValueChanged(object sender, EventArgs e)
        {
            if (clickerTimer == null) return;

            clickerTimer.interval = (double)nsClickInterval.Value;
        }

        private void nsIntDeviation_ValueChanged(object sender, EventArgs e)
        {
            if (clickerTimer == null) return;

            clickerTimer.maxIntervalDeviation = (double)nsIntDeviation.Value;
        }

        private void cbKeySelection_SelectedValueChanged(object sender, EventArgs e)
        {
            Keys key;
            //string val = cbKeySelection.GetItemText(cbKeySelection.SelectedItem);

            if (Enum.TryParse(cbKeySelection.SelectedItem.ToString(), out key))
            {
                if (ghk != null)
                {
                    ghk.Unregister();
                }

                ghk = new KeyHandler(key, this);
                ghk.Register();
            }
            else
            {

            }
        }
    }


    public static class Constants
    {
        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
        public const int MOD_ALT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
    }

    public class KeyHandler
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int key;
        private IntPtr hWnd;
        private int id;

        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, Constants.MOD_CONTROL, key);
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
