using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    internal class Logger
    {
        public static void Initialize()
        {
            Trace.AutoFlush = true;
            Trace.Listeners.Clear();

            TraceListener consoleListener = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleListener);

            TraceListener fileListener = new TextWriterTraceListener(TraceLogPath);
            Trace.Listeners.Add(fileListener);
        }

        public static void Log(string message)
        {
            Trace.WriteLine(
                String.Format("{0}, PID = {1}, TID = {2} : {3}",
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                Process.GetCurrentProcess().Id,
                                Thread.CurrentThread.ManagedThreadId,
                                message));
        }

        public static string TraceLogPath
        {
            get { return Path.Combine(Application.LocalUserAppDataPath, "trace.log");  }
        }
    }
}
