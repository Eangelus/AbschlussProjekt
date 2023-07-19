using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// klasse als model für die datenbank 

namespace Vitesco_Netzwerk.src
{
    /// <summary>
    /// Die Model Klasse für die Netzwerkcliente
    /// sie wird zum auffüllen der Daten verwendet und zum übergeben in die Datenbank
    /// </summary>
    public class NetwerkclientsModel
    {

        public string MAC_Adresse { get; set; }
        public string IP_Adresse { get; set; }
        public string Device_Name { get; set; }
        public string Device_Loaction { get; set; }
        public string Nummer { get; set; }
        public string Switch_Name { get; set; }
        public string Switch_Port { get; set; }
        public string Hersteller { get; set; }
        public string Type { get; set; }
        public string Geraetetype { get; set; }
        public string Datum { get; set; }
        public string Uhrzeit { get; set; }
        public string Name { get; set; }
        public string[] atribute = new string[12] { "MAC_Adresse", "IP_Adresse", "Device_Name",  "Device_Loaction", "Nummer", 
                                                    "Switch_Name" ,  "Switch_Port",  
                                                    "Hersteller", "Type", "Geraetetype","Name", "Datum"};
        /// <summary>
        /// Funktion die mir alle Eigenschaften als String in der Console ausgibt
        /// </summary>
        public void showall()
        {
            Console.WriteLine(


                        this.MAC_Adresse + ", " + this.IP_Adresse + ", " + this.Device_Name + ", " +
                        this.Device_Loaction + ", " + this.Nummer + ", " + this.Switch_Name + ", " +
                        this.Switch_Port + ", " + this.Hersteller + ", " +
                        this.Type + ", " + this.Geraetetype + ", " + this.Datum + ", " + this.Name + " << End of model"

                );
        }
    }
}
