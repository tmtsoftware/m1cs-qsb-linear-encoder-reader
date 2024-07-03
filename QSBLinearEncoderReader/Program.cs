using System;
using System.IO;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Initialize();

            // Set the default output directory setting.
            if (String.IsNullOrEmpty(Properties.Settings.Default.OutputDirectory))
            {
                Properties.Settings.Default.OutputDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%APPDATA%"), "QSBLinearEncoderReader");
                Properties.Settings.Default.Save();
            }

            // Start application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
