using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// klasse als model für die datenbank 

namespace Vitesco_Netzwerk.src
{
    public class NetwerkclientsModel
    {


        //public int _id { get; set; }
        public string MAC_Adresse { get; set; }
        public string IP_Adresse { get; set; }

        public string Device_Name { get; set; }

        //public string Adresse { get; set; }

        public string Device_Loaction { get; set; }
        public string Nummer { get; set; }

        //public string Netzwork_ID { get; set; }

        public string Switch_Name { get; set; }

        //public string Dynamisch { get; set; }

        public string Switch_Port { get; set; }



        //public string Betriebssystem { get; set; }
        public string Hersteller { get; set; }

        public string Type { get; set; }
        public string Geraetetype { get; set; }
        public string Datum { get; set; }
        public string Name { get; set; }

        //public string datum { get; set; }
        public string[] atribute = new string[12] { "MAC_Adresse", "IP_Adresse", "Device_Name",  "Device_Loaction", "Nummer", 
                                                    "Switch_Name" ,  "Switch_Port",  
                                                    "Hersteller", "Type", "Geraetetype","Name", "Datum"};
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
