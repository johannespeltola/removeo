using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Removeo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Mutex mutex = new Mutex(false, "Global\\removeo"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Removeo instance is already running", "Removeo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Application.Run(new FormRemoveo());
            }
        }
    }
}
