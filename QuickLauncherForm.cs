using System;
using System.Windows.Forms;
using QuickLauncher.Properties;

namespace QuickLauncher
{
    public partial class QuickLauncherForm : Form
    {

        private int oldHeight = 0;
        private int maxHeight = 0;
        
        internal bool hidden = false;
        public bool Hidden
        {
            get { return hidden; }

            set { if (hidden != value) {
                    hidden = value;
                    timer.Stop();
                    if (!value)
                        timer.Start();
                    Height = oldHeight;
                }
            }
        }

        #region key init
        Keys key1;
        Keys key2;
        Keys key3;
        Keys key4;
        Keys key5;
        Keys key6;
        Keys key7;
        Keys key8;
        Keys key9;
        Keys key10;

        Keys keyf1;
        Keys keyf2;
        Keys keyf3;
        Keys keyf4;
        Keys keyf5;
        Keys keyf6;
        Keys keyf7;
        Keys keyf8;
        Keys keyf9;
        Keys keyf10;

        Keys keys;
        #endregion

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public QuickLauncherForm()
        {
            InitializeComponent();

            keys = Settings.Default.EnableKey1 | Settings.Default.EnableKey2;
            int id = 0;     // The id of the hotkey. 
            RegisterHotKey(this.Handle, id, 0, keys.GetHashCode());
        }


        private void startProcess(string path, string args)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                process.StartInfo.FileName = path;
                process.StartInfo.Arguments = args;
                process.Start();
            }
            Hide();
            Hidden = true;
            
        }

        private void QuickLauncherForm_Load(object sender, EventArgs e)
        {
            
            BeginInvoke(new MethodInvoker(delegate
            {
                Hide();
                Hidden = true;
            }));

            notifyIcon.Icon = Icon = Resources.icon;

            oldHeight = Height;
            maxHeight = Height * 2;

            #region Set labelnames, position and size.
            label1.Text = Properties.Settings.Default.Name1;
            label2.Text = Properties.Settings.Default.Name2;
            label3.Text = Properties.Settings.Default.Name3;
            label4.Text = Properties.Settings.Default.Name4;
            label5.Text = Properties.Settings.Default.Name5;
            label6.Text = Properties.Settings.Default.Name6;
            label7.Text = Properties.Settings.Default.Name7;
            label8.Text = Properties.Settings.Default.Name8;
            label9.Text = Properties.Settings.Default.Name9;
            label10.Text = Properties.Settings.Default.Name10;


            label1.Left = (button1.Left + (button1.Width / 2)) - (label1.Width / 2);
            label2.Left = (button2.Left + (button2.Width / 2)) - (label2.Width / 2);
            label3.Left = (button3.Left + (button3.Width / 2)) - (label3.Width / 2);
            label4.Left = (button4.Left + (button4.Width / 2)) - (label4.Width / 2);
            label5.Left = (button5.Left + (button5.Width / 2)) - (label5.Width / 2);
            label6.Left = (button6.Left + (button6.Width / 2)) - (label6.Width / 2);
            label7.Left = (button7.Left + (button7.Width / 2)) - (label7.Width / 2);
            label8.Left = (button8.Left + (button8.Width / 2)) - (label8.Width / 2);
            label9.Left = (button9.Left + (button9.Width / 2)) - (label9.Width / 2);
            label10.Left = (button10.Left + (button10.Width / 2)) - (label10.Width / 2);


            labelf1.Text = Properties.Settings.Default.Namef1;
            labelf2.Text = Properties.Settings.Default.Namef2;
            labelf3.Text = Properties.Settings.Default.Namef3;
            labelf4.Text = Properties.Settings.Default.Namef4;
            labelf5.Text = Properties.Settings.Default.Namef5;
            labelf6.Text = Properties.Settings.Default.Namef6;
            labelf7.Text = Properties.Settings.Default.Namef7;
            labelf8.Text = Properties.Settings.Default.Namef8;
            labelf9.Text = Properties.Settings.Default.Namef9;
            labelf10.Text = Properties.Settings.Default.Namef10;


            labelf1.Left = (buttonf1.Left + (buttonf1.Width / 2)) - (label1.Width / 2);
            labelf2.Left = (buttonf2.Left + (buttonf2.Width / 2)) - (labelf2.Width / 2);
            labelf3.Left = (buttonf3.Left + (buttonf3.Width / 2)) - (labelf3.Width / 2);
            labelf4.Left = (buttonf4.Left + (buttonf4.Width / 2)) - (labelf4.Width / 2);
            labelf5.Left = (buttonf5.Left + (buttonf5.Width / 2)) - (labelf5.Width / 2);
            labelf6.Left = (buttonf6.Left + (buttonf6.Width / 2)) - (labelf6.Width / 2);
            labelf7.Left = (buttonf7.Left + (buttonf7.Width / 2)) - (labelf7.Width / 2);
            labelf8.Left = (buttonf8.Left + (buttonf8.Width / 2)) - (labelf8.Width / 2);
            labelf9.Left = (buttonf9.Left + (buttonf9.Width / 2)) - (labelf9.Width / 2);
            labelf10.Left = (buttonf10.Left + (buttonf10.Width / 2)) - (labelf10.Width / 2);
            #endregion

            #region Set Keys
            key1 = Settings.Default.Key1;
            key2 = Settings.Default.Key2;
            key3 = Settings.Default.Key3;
            key4 = Settings.Default.Key4;
            key5 = Settings.Default.Key5;
            key6 = Settings.Default.Key6;
            key7 = Settings.Default.Key7;
            key8 = Settings.Default.Key8;
            key9 = Settings.Default.Key9;
            key10 = Settings.Default.Key10;

            keyf1 = Settings.Default.Keyf1;
            keyf2 = Settings.Default.Keyf2;
            keyf3 = Settings.Default.Keyf3;
            keyf4 = Settings.Default.Keyf4;
            keyf5 = Settings.Default.Keyf5;
            keyf6 = Settings.Default.Keyf6;
            keyf7 = Settings.Default.Keyf7;
            keyf8 = Settings.Default.Keyf8;
            keyf9 = Settings.Default.Keyf9;
            keyf10 = Settings.Default.Keyf10;
            #endregion
        }

        private void QuickLauncherForm_Deactivate(object sender, EventArgs e)
        {
            Hide();
            Hidden = true;
        }

        private void QuickLauncherForm_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == key1)
                startProcess(Settings.Default.Path1, Settings.Default.Arg1);
            else if (e.KeyCode == key2)
                startProcess(Settings.Default.Path2, Settings.Default.Arg2);
            else if (e.KeyCode == key3)
                startProcess(Settings.Default.Path3, Settings.Default.Arg3);
            else if (e.KeyCode == key4)
                startProcess(Settings.Default.Path4, Settings.Default.Arg4);
            else if (e.KeyCode == key5)
                startProcess(Settings.Default.Path5, Settings.Default.Arg5);
            else if (e.KeyCode == key6)
                startProcess(Settings.Default.Path6, Settings.Default.Arg6);
            else if (e.KeyCode == key7)
                startProcess(Settings.Default.Path7, Settings.Default.Arg7);
            else if (e.KeyCode == key8)
                startProcess(Settings.Default.Path8, Settings.Default.Arg8);
            else if (e.KeyCode == key9)
                startProcess(Settings.Default.Path9, Settings.Default.Arg9);
            else if (e.KeyCode == key10)
                startProcess(Settings.Default.Path10, Settings.Default.Arg10);

            else if (e.KeyCode == keyf1)
                startProcess(Settings.Default.Pathf1, Settings.Default.Argf1);
            else if (e.KeyCode == keyf2)
                startProcess(Settings.Default.Pathf2, Settings.Default.Argf2);
            else if (e.KeyCode == keyf3)
                startProcess(Settings.Default.Pathf3, Settings.Default.Argf3);
            else if (e.KeyCode == keyf4)
                startProcess(Settings.Default.Pathf4, Settings.Default.Argf4);
            else if (e.KeyCode == keyf5)
                startProcess(Settings.Default.Pathf5, Settings.Default.Argf5);
            else if (e.KeyCode == keyf6)
                startProcess(Settings.Default.Pathf6, Settings.Default.Argf6);
            else if (e.KeyCode == keyf7)
                startProcess(Settings.Default.Pathf7, Settings.Default.Argf7);
            else if (e.KeyCode == keyf8)
                startProcess(Settings.Default.Pathf8, Settings.Default.Argf8);
            else if (e.KeyCode == keyf9)
                startProcess(Settings.Default.Pathf9, Settings.Default.Argf9);
            else if (e.KeyCode == keyf10)
                startProcess(Settings.Default.Pathf10, Settings.Default.Argf10);

            if (e.KeyCode == Keys.Space)
            {
                animTimer.Stop();
                animTimer.Start();

                timer.Stop();
                timer.Start();
            }
                
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys keypressed = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.


                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.


                if (keypressed == keys && !Hidden)
                {
                    Hide();
                    Hidden = true;
                }

                else if (keypressed == keys && Hidden)
                {
                    Show();
                    Hidden = false;
                }



                // do something
            }
        }

        private void QuickLauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            UnregisterHotKey(Handle, 0);
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            Show();
            Hidden = false;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Show();
                Hidden = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Hide();
            Hidden = true;
        }

        private void amimTimer_Tick(object sender, EventArgs e)
        {
            if (Height >= maxHeight)
                animTimer.Stop();
            else
                Height += 5;
        }
    }
}
