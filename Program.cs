using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace QuickLauncher
{
    static class Program
    {

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        private static string appGuid = "c4a76b1a-12ab-4455-39d9-5693faa6e3b9";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance already running");
                    Console.WriteLine("Instance is already running.\r\nExiting.");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new QuickLauncherForm());
            }
            
        }
    }
}
