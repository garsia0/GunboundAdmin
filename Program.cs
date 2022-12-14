using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static Main MainV;
#if Debug
        public static LogForm LogFormV;
#endif
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainV = new Main();
#if Debug
            LogFormV = new LogForm();
            new Thread(LogFStart).Start();
#endif
            Application.Run(MainV);
        }
#if Debug
        static void LogFStart()
        {
            Application.Run(LogFormV);
        }
#endif
    }
}
