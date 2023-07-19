using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vitesco_Netzwerk;
using Vitesco_Netzwerk.src;

namespace VitescoNetzwerk._4._8
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Logger lg = new Logger();
                // eine abfrage ob das programm mit paramter gestartet wurde
                if (args.Length == 0)
                {
                    lg.logWrite("ProgrammStart", "Normal gestartet!");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow());

                }
                foreach (string arg in args)
                {
                    // wen ja dan soll nur die logic ausgeführt werden
                    if (arg == "-Watcher")
                    {
                        lg.logWrite("ProgrammStart", "Mit -Watcher gestartet!");
                        Logic logic = new Logic();
                        logic.isDbOk();
                        System.Windows.Forms.Application.Exit();
                    }

                }
            }
            catch (Exception e) { Console.WriteLine(e); }

        }
    }
}
