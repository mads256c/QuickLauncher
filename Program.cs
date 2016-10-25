using System;
using System.Threading;
using System.Windows.Forms;

namespace QuickLauncher
{
    static class Program
    {
        private static string appGuid = "c4a76b1a-12ab-4455-39d9-5693faa6e3b9";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance already running");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new QuickLauncherForm());
            }
            
        }
    }
}
