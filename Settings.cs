using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace VitescoNetzwerk._4._8
{
    /// <summary>
    /// Die Settings-Klasse Sie wird verwendet um Einstellungen wie Pfad, Datenbank-Name, Qip Verzeichnis/Name, MacLog Verzeichnis/Name zu verändern und diese in eine Json zu Expotieren
    /// 
    /// </summary>
    internal class Settings
    {

        public string pfad = "Settings.json";
        public string qDatenbank { get; set; }

        public string qDatenbankVerzeichnis { get; set; }
        public string qQip { get; set; }

        public string didShareVerzeichnis { get; set; }
        public string qMacLog { get; set; }

        public string qHerstellerListe { get; set; }

        public  string herstellerlisteVerzeichnis { get; set; }

        public string pruefenbeiStart { get; set; }
        /// <summary>
        /// Hier wir die vorhandene Settings.Json aus den gleichen verzeichnis eingelessen
        /// </summary>
        /// <returns></returns>
        public Settings readSettings()
        {

                                                    
            if (File.Exists(pfad))
            {
                string json = File.ReadAllText(this.pfad);
                return JsonConvert.DeserializeObject<Settings>(json);
            }
            else
            {
                Dictionary<string, string> settings = new Dictionary<string, string>();
                settings.Add("UserApiRequest", "");
                settings.Add("PasswordAPIreQuest", "");
                settings.Add("apiURL", "");
                settings.Add("didShareVerzeichnis", "");
                settings.Add("qDatenbank", "");
                settings.Add("qDatenbankVerzeichnis", "");
                settings.Add("herstellerlisteVerzeichnis", "");
                settings.Add("qQip", "");
                settings.Add("qMacLog", "");
                settings.Add("qHerstellerListe", "https://standards-oui.ieee.org/oui/oui.txt");
                
                settings.Add("pruefenbeiStart", "0");
                File.WriteAllText(this.pfad, JsonConvert.SerializeObject(settings ));
           
                string json = File.ReadAllText(this.pfad);
                
                return JsonConvert.DeserializeObject<Settings>(json);
            }
            
        }
        /// <summary>
        /// Mit dieser Funtkion wird die Settings-Klasse in Settings.json geschrieben
        /// </summary>
        /// <param name="obejct"></param>
        public void setToJson(Object obejct)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obejct, Formatting.Indented);
            File.WriteAllText(this.pfad, json);


        }

    }
}
