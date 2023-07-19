
using System.Net;

using System.Diagnostics;


namespace Vitesco_Netzwerk.src
{
    public class Logic
    {


        public static List<NetwerkclientsModel> auffälige = new List<NetwerkclientsModel>();
        public List<NetwerkclientsModel> list = new List<NetwerkclientsModel>();
        public Dictionary<string, string> dictQIP = new Dictionary<string, string>();
        Dictionary<string, string> dicHersteller = new Dictionary<string, string>();
        ClientsRepository clientsRepository = new ClientsRepository();
        public string qIp = "\\\\vt1.vitesco.com\\smt\\didr0742\\005_Scan_Reports\\Network_Assets_Reports\\QIPexport.csv";
        public string macLogs = "\\\\vt1.vitesco.com\\smt\\didr0742\\005_Scan_Reports\\Network_Assets_Reports\\mac-output.csv"; //"Z:\\005_Scan_Reports\\Network_Assets_Reports\\macs.log";  <<<<<<<<<<<<<<<<
        public int zähler = 0;
        public int gesamtMenge = 0;
        public float prozent;
        public void hinzufügen(string deviceName, string deviceLoaction,
                                string adress, string networkID,
                                string ipadresse, string nummer,
                                string macadresse, string switch_name, string dynamisch, string switch_Port,
                                string betriebssystem, string hersteller, string name,
                                string type, string geraetetype, string datum)
        {

            list.Add(new NetwerkclientsModel
            {
                Device_Name = deviceName,
                Device_Loaction = deviceLoaction,

                IP_Adresse = ipadresse,
                Nummer = nummer,
                MAC_Adresse = macadresse,
                Switch_Name = switch_name,

                Switch_Port = switch_Port,

                Hersteller = hersteller,
                Type = type,
                Geraetetype = geraetetype,
                Name = name,
                Datum = datum
            });


        }


        public bool CheckDateofSource()
        {
            // Zeitliche Prüfung  !!!!   <<<<<<<<<<<<<<<<<<<<<<

            FileInfo datenbankInfo = new FileInfo(@".\database\NetzwerkTable.db");
            FileInfo DateiInfo = new FileInfo(macLogs);


            Console.WriteLine("Prüfe Daten");

            if (datenbankInfo.LastWriteTime.Date.CompareTo(DateiInfo.LastWriteTime.Date) == -1)
            {

                Console.WriteLine("Update erkannt...\rBeginne Datenbank aufzufüllen..");
                

                return true;
            }
            else
            {
                var inhalt = clientsRepository.GetClients();
                if( inhalt == null)
                {
                    Console.WriteLine("Datenbank Leer...");
                    return true;
                }
                if(inhalt.Count < 1)
                {
                    Console.WriteLine("Datenbank Leer...");
                    return true;
                }

                Console.WriteLine("Kein Update der Datenbank nötig.");
                return false;
            }
        }

            public void fillDb()
            {

                if (CheckDateofSource() == true )
                {

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    stopwatch.Start();
                    Console.WriteLine("Fülle Datenbank");


                    List<NetwerkclientsModel> Mac = loadMACTabelle();

                    List<NetwerkclientsModel> ErsteListe = Schmelzen(Mac);


                    List<NetwerkclientsModel> ListeNachAbgleich = herstellerAbgleich(ErsteListe);

                this.gesamtMenge = ListeNachAbgleich.Count;
                    foreach (NetwerkclientsModel model in ListeNachAbgleich)
                    {
    
                            try
                            {

                                clientsRepository.Insert(model);

                                this.zähler = this.zähler + 1;
                             


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                
                            }



                    }

                    Console.WriteLine("Füllung beendet..");
                    stopwatch.Stop();
                    Console.WriteLine("Zeit in der fillDB-Funktion" + stopwatch.Elapsed);
                }

                
            }


        public List<NetwerkclientsModel> Schmelzen(List<NetwerkclientsModel> maclog)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            string[] zeilen = File.ReadAllLines(this.qIp);


            foreach (NetwerkclientsModel m in maclog)
            {

                foreach (string zeile in zeilen)

                {
                    string[] words = zeile.Split(",");
                    //ObjIpAddr,MacAddr,Name,ObjectType,ObjectClass,ObjectDesc,
                    //WEn nicht in qip gefunden in warhun
                    if (words[0] == "ObjIpAddr")
                    {
                        continue;
                    }
                    if (words[1] == m.MAC_Adresse)
                    {
                        m.IP_Adresse = words[0];
                        m.Name = words[2];
                        m.Type = words[3];
                        m.Geraetetype = words[4];
                        m.Device_Name = words[5];


                    }

                }
                //if (m.IP_Adresse == null)
                //{

                //    auffälige.Add(m);
                //}


            }
            stopwatch.Stop();
            Console.WriteLine("Zeit in der Schmelzen-Funktion " + stopwatch.Elapsed);

            


            return maclog;

        }

     
        public List<NetwerkclientsModel> loadMACTabelle()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            string[] zeilen = File.ReadAllLines(this.macLogs);
            string NameDesSwitches = "";
            List<NetwerkclientsModel> list = new List<NetwerkclientsModel>();

            string nummer = "";
            string mac = "";

            string port = "";

            foreach (string zeile in zeilen)
            {

                string[] zeileA = zeile.Split(",");
                // 1 datum  2 switch ( name ) 3 nummer 4 mac 5. port 
        
                mac = zeileA[3];
                mac = mac.Replace(":", "");
                mac = mac.Replace(".", "");
                mac = mac.Replace("-", "");
    
                port = zeileA[4];
                nummer = zeileA[2];
                NameDesSwitches = zeileA[1];
                string datum = zeileA[0];
                            
                list.Add(new NetwerkclientsModel
                {

                    Nummer = nummer,
                    MAC_Adresse = mac,
                    Switch_Port = port,
                    Datum = datum,
                    Switch_Name = NameDesSwitches

                });




            }

            stopwatch.Stop();
            Console.WriteLine("Zeit in der LoadMac-Funktion" + stopwatch.Elapsed);
            return list;

        }


        public void herstellerListeCovertieren()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            string HerstellerListe = @".\database\HerstellerListe.txt";
            string str;


            // hersteller liste gedownloadet?
            bool herstellerListeDa = File.Exists(HerstellerListe);

            if (herstellerListeDa == false)
            {
                // wen nicht lade wir sie
                WebClient mywebClient = new WebClient();
                mywebClient.DownloadFile("https://standards-oui.ieee.org/oui/oui.txt", HerstellerListe);

            }
            // lesse die herstelller liste ein
            str = File.ReadAllText(HerstellerListe);

            // ersten 4 zeilen auf den string löschen
            int indexOfFirstMac = str.IndexOf("00");

            str = str.Substring(indexOfFirstMac);
            str = str.Replace("\n", string.Empty);
            str = str.Replace("\r", ",");
            str = str.Replace("\t", ",");
            str = str.Replace(".", string.Empty);
            str = str.Replace("'", string.Empty);

            string[] ListeHersteller = str.Split(",");
            ListeHersteller = ListeHersteller.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int a = 0; a < ListeHersteller.Length; a++)
            {
                if (ListeHersteller[a].Contains("(base 16)"))
                {
                    if (dicHersteller.ContainsKey(ListeHersteller[a].Substring(0, 6)))
                    {
                        dicHersteller[ListeHersteller[a].Substring(0, 6)] = " MEHR EINTRAEGE " + dicHersteller[ListeHersteller[a].Substring(0, 6)] ;
                        continue;

                    }
                    else
                    {

                        dicHersteller.Add(ListeHersteller[a].Substring(0, 6), ListeHersteller[a + 1]  );
                    }
                }
            }
            str = null;
            ListeHersteller = null;
            stopwatch.Stop();
            Console.WriteLine("Zeit in der herstellerListeCovertieren-Funktion " + stopwatch.Elapsed);


        }


        public List<NetwerkclientsModel> herstellerAbgleich(List<NetwerkclientsModel> gesamt)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            string str;
            herstellerListeCovertieren();

            foreach (NetwerkclientsModel m in gesamt)
            {
                string herstellerCode = m.MAC_Adresse.Substring(0, 6);
                if (dicHersteller.ContainsKey(herstellerCode.ToUpper()))
                {
                    m.Hersteller = dicHersteller[herstellerCode.ToUpper()];
                }
                else
                {
                    //m.Hersteller = " !! ACHTUNG !! MAC Nicht in der Hersteller Liste gefunden!";
                }
            }
            //foreach (NetwerkclientsModel m in auffälige)
            //{
            //    string herstellerCode = m.MAC_Adresse.Substring(0, 6);
            //    if (dicHersteller.ContainsKey(herstellerCode))
            //    {
            //        m.Hersteller = dicHersteller[herstellerCode];
            //    }
            //    else
            //    {
            //        //m.Hersteller = " !! ACHTUNG !! MAC Nicht in der Hersteller Liste gefunden!";
            //    }
            //}
            stopwatch.Stop();
            Console.WriteLine("Zeit in der HerstellerAbgleich-Funktion " + stopwatch.Elapsed);
            return gesamt;
        }


    }
}

    //





