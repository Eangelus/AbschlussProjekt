using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace VitescoNetzwerk._4._8
{

    /// <summary>
    /// Diese Klasse dient zum Logs erstellen. Sie erstellt automatisch eine Log.txt und schreib dort jede Exeption hinein
    /// 
    /// </summary>
    internal class Logger
    {
        private bool addTo = true;
        /// <summary>
        /// Konstruktor mit Prüfung ob die Datei Existiert und dessen erstellung
        /// </summary>
        public Logger()
        {
            if (File.Exists("./log.txt") == false) {  
                StreamWriter sw = new StreamWriter("./log.txt");
                sw.WriteLine("Diese Logs werden automatisch erzeugt.");
                sw.WriteLine("Bernecker Thomas");
                sw.WriteLine("***************************************");
                sw.Close();
             }

        }

        /// <summary>
        /// Funktion zum befüllen der Text-Datei mit empfangenen Exeptions
        /// </summary>
        /// <param name="bereicht"></param>
        /// <param name="text"></param>
        public void logWrite( string bereicht, string text)
        {
            StreamWriter sw = new StreamWriter("./log.txt", true);
            text = DateTime.Now.ToString() +"    "+ bereicht +"    " + text;
            sw.WriteLine(text, addTo);
            sw.Close();
        }

    }
}
