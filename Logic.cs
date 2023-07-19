using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using VitescoNetzwerk._4._8;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace Vitesco_Netzwerk.src
{
    /// <summary>
    /// Das ist die Hauptklasse Logic hier befinden sich Datenverarbeitung, Weiterleitung und dessen Prüfung.  
    /// </summary>
    public class Logic
    {
        // Variablen und Objekte block
        #region Variablen und Objekte
        static Settings s = new Settings();
        Settings settings = s.readSettings();
        Logger logger = new Logger();
        //public static List<NetwerkclientsModel> auffälige = new List<NetwerkclientsModel>();
        //public List<NetwerkclientsModel> listOfModels = new List<NetwerkclientsModel>();
        public Dictionary<string, string> dictQIP = new Dictionary<string, string>();
        public Dictionary<string, string> dicHersteller = new Dictionary<string, string>();
        ClientsRepository clientsRepository = new ClientsRepository();
        //public string qIp =  "\\\\vt1.vitesco.com\\smt\\didr0742\\005_Scan_Reports\\Network_Assets_Reports\\QIPexport.csv";
        //public string macLogs = "\\\\vt1.vitesco.com\\smt\\didr0742\\005_Scan_Reports\\Network_Assets_Reports\\mac-output.csv"; //"Z:\\005_Scan_Reports\\Network_Assets_Reports\\macs.log";  <<<<<<<<<<<<<<<<
        public int counterOfModels = 0;
        public int sum = 0;
        
        #endregion

        //// null referencs? brach ich die XD?
        //public void hinzufügen(string deviceName, string deviceLoaction,
        //                        string adress, string networkID,
        //                        string ipadresse, string nummer,
        //                        string macadresse, string switch_name, string dynamisch, string switch_Port,
        //                        string betriebssystem, string hersteller, string name,
        //                        string type, string geraetetype, string datum)
        //{

        //    listOfModels.Add(new NetwerkclientsModel
        //    {
        //        Device_Name = deviceName,
        //        Device_Loaction = deviceLoaction,
        //        IP_Adresse = ipadresse,
        //        Nummer = nummer,
        //        MAC_Adresse = macadresse,
        //        Switch_Name = switch_name,
        //        Switch_Port = switch_Port,
        //        Hersteller = hersteller,
        //        Type = type,
        //        Geraetetype = geraetetype,
        //        Name = name,
        //        Datum = datum
        //    });


        //}
        #region CheckOdner()  überprüfung und erstellung des verzeichnis wo die Datenbank liegen soll

        //public void CheckOdner()
        //{
        //    string odner = s.qDatenbankVerzeichnis;


        //    if (!Directory.Exists(odner))
        //    {
        //        System.IO.Directory.CreateDirectory(odner);

        //    }
        //    else
        //    {

        //        // Ordner existiert

        //    }
        //}
        #endregion

        #region CheckDateofSource() in dieser Funktion wird die Datei info mit der von der Datanbank verglichen
        //public bool CheckDateofSource()
        //{

        //    // diese funktion erstellte sich als nicht ausreichend aus, diese aufgabe übernimmt jetzt
        //    // IsDbOk()
        //    // Zeitliche Prüfung  !!!!   <<<<<<<<<<<<<<<<<<<<<<

        //    FileInfo datenbankInfo = new FileInfo(settings.qDatenbank);
        //    FileInfo DateiInfo = new FileInfo(settings.qMacLog);



        //    Console.WriteLine(datenbankInfo.LastWriteTime);
        //    Console.WriteLine(DateiInfo.LastWriteTime);
        //    Console.WriteLine("Test--------------------------------------------");
        //    Console.WriteLine("Prüfe Daten");


        //    if (datenbankInfo.LastWriteTime.CompareTo(DateiInfo.LastWriteTime) == -1)
        //    {

        //        Console.WriteLine("Update erkannt...\rBeginne Datenbank aufzufüllen..");
                

        //        return true;
        //    }
        //    else
        //    {
        //        var inhalt = clientsRepository.GetClients();
        //        if( inhalt == null)
        //        {
        //            Console.WriteLine("Datenbank Leer...");
        //            return true;
        //        }
        //        if(inhalt.Count < 1)
        //        {
        //            Console.WriteLine("Datenbank Leer...");
        //            return true;
        //        }

        //        Console.WriteLine("Kein Update der Datenbank nötig.");
        //        return false;
        //    }
          
        //}
        #endregion

        #region IsDbOk() Die Maclogs-liste wird auf datum in der Datenbank überprüft 
        // hier nehme ich den ersten und den letzen eintrag in der Maclogs.
        // zähle wieviele einträge mit beiden Datums in der Db liegen
        // wen sie nicht übereinstimmen lösche ich vorhandene und Fülle die datenbank neu

        /// <summary>
        /// Diese Funktion Prüft auf vollständige übertragen in die Datenbank anhand der Maclog und den heutigen einträgen in der Datenbank
        /// 
        /// </summary>
        public void isDbOk()
        {

                // zeitmessung 
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();

                List<NetwerkclientsModel> maclogs = loadMacTable();
                
                string datum = maclogs[0].Datum;

                // eine prüfung auf die länge und vollständigkeit der übertragung in die datenbank


                // so ist der zeitpunkt in der db 31.01.2023_14:15:03
                Console.WriteLine("Beginne Prüfung");
                int anzahlInMaclog = 0;


                // zähle die maclogs ab nach datum 
                for (int i = 0; i < maclogs.Count; i++)
                {
                    if (maclogs[i].Datum == datum)
                    {
                        anzahlInMaclog = anzahlInMaclog + 1;
                    }

                }


                Console.WriteLine("Anzahl der macs im maclog");
                Console.WriteLine(anzahlInMaclog);
                Console.WriteLine(datum);
                // anzahl der neuen Macadressen in der datenbank heute
                int anzahlInDB = clientsRepository.findMacsToDay(datum);


                Console.WriteLine("Anzahle der macs in der Datenbank vom datum der Maclog");
                Console.WriteLine(anzahlInDB);
                // hier vergleiche ich die anzahl der macadressen in der Maclog mit der aus der Datenbank
                while (anzahlInMaclog > anzahlInDB)
                {
                    // wen die maclog anzahl gröser ist fehlt was in der Datenbank 
                    Console.WriteLine("Unterschied festgestellt!");
                    Console.WriteLine("Räume Datenbank einträge auf");
                    // lösche die vorhandenen einträge und 
                    clientsRepository.deleteOfDate(datum);

                    // fülle die datenbank neu
                    fillDb();
                    anzahlInDB = clientsRepository.findMacsToDay(datum);
                }

                    // hier sind alle macaddressen in der datenbank
                    Console.WriteLine("Keine Differenz in der Datenbank festgestellt!");

   

                // durch den selbst aufruf übergebe ich 2 uhrzeiten, die maclogs besteht aus
                // 2 identischen einträgen mit einer zeit differenz von 1 sekunde
                // natürlich prüfe ich beide auf vollständigkeit


                stopwatch.Stop();
                Console.WriteLine("Zeit in der IsDbOk()-Funktion " + stopwatch.Elapsed);

        }
        #endregion



        #region FillDB() zusammen führen der listen und füllen der datenbank 
        /// <summary>
        /// Diese Funktion fürt die anderen funktionen zum zusammen führen der Daten aus und erstellt eine Liste aus NetzwerkclientsModel und übergibt diese der Datenbank
        /// </summary>
        public void fillDb()
            {

                // hier wird eine zeitmessung gestartet
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();

                Console.WriteLine("Fülle Datenbank");
                // erstelle die macliste 
                List<NetwerkclientsModel> Mac = loadMacTable();
                // füge beide listen zusammen ( qip und mac ) 
                List<NetwerkclientsModel> ErsteListe = smelting(Mac);

                // jetzt werden die hersteller raus gesucht und in die liste übertragen
                List<NetwerkclientsModel> ListeNachAbgleich = addProducer(ErsteListe);

                this.sum = ListeNachAbgleich.Count;

                // da die liste nur zur Db übergeben werden kann
                // für jedes model in meiner liste
                foreach (NetwerkclientsModel model in ListeNachAbgleich)
                {
                    try
                    {
                        // verusche ich einen Inster in die datenbank    
                        // frage an mich selbst.. nicht gleich die ganze liste?
                        clientsRepository.insert(model);
                        // kontrollzähler um zu sehen das das programm nicht hängt
                        this.counterOfModels = this.counterOfModels + 1;
                        Console.WriteLine(counterOfModels);
                    }
                    // das hier ist klar fals fehler kommt
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }
                Console.WriteLine("Füllung beendet..");
                // ende der zeitmessung und ausgabe 
                stopwatch.Stop();
                Console.WriteLine("Zeit in der fillDB-Funktion " + stopwatch.Elapsed);
                Console.WriteLine("Prüfe Ob Datenbank vollständig");
        }

        #endregion

        #region Schmelzen()  fügt Mac und QIP listen zusammen zu einer über die macadresse
        /// <summary>
        /// Diese Funktion bekommt die Liste aus der Maclog und überprüft jedes Model anhand der Macadresse in der QIP.csv füllt dan die entsprechenden Daten auf
        /// </summary>
        /// <param name="maclog"></param>
        /// <returns>Liste NetwerkclientsModel></returns>
        public List<NetwerkclientsModel> smelting(List<NetwerkclientsModel> maclog)
        {
                // zeitmessung
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();
                // hier wir die QIP eingelessen
                string[] zeilen = File.ReadAllLines(settings.qQip);
                // für jede mac addresse in meiner Maclogliste
                foreach (NetwerkclientsModel m in maclog)
                {
                    foreach (string zeile in zeilen)
                    {
                        string[] words = zeile.Split(',');
                        if (words.Length < 2)
                        {
                            words = zeile.Split(';');
                        }
                        if (words.Length < 2)
                        {
                            Console.WriteLine("Die QIP wurde Verändert ( Name der Datei? )! Trennung nur durch , und ; gestattet. Quelldateien mussen steht der vorgegebenen Norm entsprechen!");
                        }
                        //ObjIpAddr,MacAddr,Name,ObjectType,ObjectClass,ObjectDesc,
                        //WEn nicht in qip gefunden in warhun
                        if (words[0] == "ObjIpAddr")
                        {
                            continue;
                        }
                        // wen die mac gefunden würde werden die daten aufgefüllt
                        if (words[1] == m.MAC_Adresse)
                        {
                            
                            m.IP_Adresse = words[0];
                            m.Name = words[2];
                            m.Type = words[3];
                            m.Geraetetype = words[4];
                            m.Device_Name = words[5];


                        }
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("Zeit in der Schmelzen-Funktion " + stopwatch.Elapsed);

                return maclog;

        }
        #endregion

        #region loadMACTabelle() hier wird die Mac csv eingelessen und in das NetwerkClientModel gepresst
        /// <summary>
        /// Diese Funktion wir zum einlessen der MacLog.csv verwendet und verarbeitet diese zu NetzwerkclientsModel
        /// </summary>
        /// <returns>Liste NetwerkclientsMode</returns>
        public List<NetwerkclientsModel> loadMacTable()
        {
                // zeitmessung
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();
                // Lesse die macLogs ein 
                string[] zeilen = File.ReadAllLines(settings.qMacLog);


                List<NetwerkclientsModel> list = new List<NetwerkclientsModel>();

                // variablen angelegt
                string NameDesSwitches = "";
                string nummer = "";
                string mac = "";
                string port = "";

                foreach (string zeile in zeilen)
                {
                    // zeiteile die Zeile anhand der Kommatars
                    string[] zeileA = zeile.Split(',');
                    // 1 datum  2 switch ( name ) 3 nummer 4 mac 5. port 
                    // lösche die sonderzeichen aus der Macadresse 
                    // verhindert fehler bei der übergabe in die datenbank
                    mac = zeileA[3];
                    mac = mac.Replace(":", "");
                    mac = mac.Replace(".", "");
                    mac = mac.Replace("-", "");

                    port = zeileA[4];
                    nummer = zeileA[2];
                    NameDesSwitches = zeileA[1];
                    string datum = zeileA[0];
                    // jede Model  nach der aufbereitung in Liste hinzugefügt
                    list.Add(new NetwerkclientsModel
                    {
                        Nummer = nummer,
                        MAC_Adresse = mac,
                        Switch_Port = port,
                        Datum = datum,
                        Switch_Name = NameDesSwitches
                    });

                }
                // zeitmessungs ende
                stopwatch.Stop();
                Console.WriteLine("Zeit in der LoadMac-Funktion" + stopwatch.Elapsed);
                return list;

        }
        #endregion


        #region herstellerListeCovertieren() downloadet und erste Dictornary die ersteller liste
        // MacAdresse = Key

        /// <summary>
        /// In dieser Funktion wird ein Webclient-Objekt verwendet um die Hersteller Liste zu downloaden.
        /// Nach dem Download wird Sie zu einen Dictionary verarbeitet
        /// </summary>
        public void producerListCovert()
        {
                // zeitmessung
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();
                // varis
                string HerstellerListe = settings.herstellerlisteVerzeichnis;
                string str;

                // hersteller liste gedownloadet?
                bool herstellerListeDa = File.Exists(HerstellerListe);
                if (herstellerListeDa == false)
                {
                    // wen nicht lade wir sie
                    WebClient mywebClient = new WebClient();
                    mywebClient.DownloadFile(settings.qHerstellerListe, HerstellerListe);

                }
                // lesse die herstelller liste ein
                str = File.ReadAllText(HerstellerListe);

                // ersten 4 zeilen auf den string löschen
                int indexOfFirstMac = str.IndexOf("00");

                // hier schneide ich den string zu um den such bereich zu verkleiner und fehler auszuschliesen
                str = str.Substring(indexOfFirstMac);
                str = str.Replace("\n", string.Empty);
                str = str.Replace("\r", ",");
                str = str.Replace("\t", ",");
                str = str.Replace(".", string.Empty);
                str = str.Replace("'", string.Empty);

                string[] ListeHersteller = str.Split(',');
                ListeHersteller = ListeHersteller.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                // hier nehme ich die macadresse 
                for (int a = 0; a < ListeHersteller.Length; a++)
                {
                    if (ListeHersteller[a].Contains("(base 16)"))
                    {
                        if (dicHersteller.ContainsKey(ListeHersteller[a].Substring(0, 6)))
                        {
                            // hier überspringe ich den Header
                            dicHersteller[ListeHersteller[a].Substring(0, 6)] = " MEHR EINTRAEGE " + dicHersteller[ListeHersteller[a].Substring(0, 6)];
                            continue;

                        }
                        else
                        {
                            // und erstelle die disct
                            dicHersteller.Add(ListeHersteller[a].Substring(0, 6), ListeHersteller[a + 1]);
                        }
                    }
                }
                str = null;
                ListeHersteller = null;
                // ende der zeit messung
                stopwatch.Stop();
                Console.WriteLine("Zeit in der herstellerListeCovertieren-Funktion " + stopwatch.Elapsed);

        }
        #endregion

        #region herstellerAbgleich() hier wird der hersteller aus der Aufbereiteten liste raus gesucht
        /// <summary>
        /// In dieser Funktion werden die Mac-Adressen mit der Dictionary der Herstellerliste verglichen und die NetzwerkclientsModel aufgefüllt 
        /// </summary>
        /// <param name="gesamt"></param>
        /// <returns>Liste NetwerkclientsModel</returns>
        public List<NetwerkclientsModel> addProducer(List<NetwerkclientsModel> gesamt)
        {
                // zeitmessung
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();

                string str;
            // hier wird die Hersteller Disctory erstellt
            producerListCovert();
            
                // nun wird jedes model an hand der macadresse in der hersteller disc durch sucht 
                foreach (NetwerkclientsModel m in gesamt)
                {
                if (m.MAC_Adresse == "")
                {
                    m.showall();
                    logger.logWrite("KIRTISCH Einträge ohne MACADRESSE gefunden ->", $"{m.Uhrzeit}, " + $"{m.IP_Adresse}," + $"{m.Switch_Port}, " +
                                                $"{m.Switch_Name}," + $"{m.Nummer}, " + $"{m.Geraetetype}," + $"{m.Device_Name}, " + $"{m.Hersteller}," + $"{m.Type}, ");
                    continue;
                }
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

                // ende der zeitmessung
                stopwatch.Stop();
                Console.WriteLine("Zeit in der HerstellerAbgleich-Funktion " + stopwatch.Elapsed);
                return gesamt;

        }
        #endregion


        #region datumsAnderungVorDerGui() hier verändere ich die daten bevor sie zur gui kommen
        // da ich die struktur nicht verändern will verändere ich die zeit bevor sie angezeigt wird


        /// <summary>
        /// Diese Funktion Nimmt den Zeitstempel aus der Datenbank und Splitet die Uhrzeit und das Datum auf.
        /// Wird verwendet für die Korekte darstellung auf der Gui von Uhrzeit und Datum
        /// </summary>
        /// <param name="liste"></param>
        /// <returns>Liste NetwerkclientsModel</returns>
        public List<NetwerkclientsModel> changeDataForGui(List<NetwerkclientsModel> liste)
        {

                List<NetwerkclientsModel> newList = new List<NetwerkclientsModel>();

                foreach (NetwerkclientsModel m in liste)
                {

                    string DatumPlusUhrzeit = m.Datum;
                    string[] words = DatumPlusUhrzeit.Split('_');

                    // einfache neuzuordnung
                    m.Datum = words[0];
                    m.Uhrzeit = words[1];
                    newList.Add(m);


                }


                return newList.ToList();
 
        }

        #endregion


        #region SucheInDatenBank() hier wird die such anfrage von der gui in die datenbank weiter gereicht
        /// <summary>
        /// Hier wird das ClientsRepository Objekt verwendet und einen Such aufruf zu der Datenbank zu schicken
        /// Das ganze mit 3 Paramtern
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="was"></param>
        /// <param name="orderBy"></param>
        /// <returns>Liste NetwerkclientsModel</returns>
        public List<NetwerkclientsModel> searchInDb(string parameter, string was , string orderBy)
        {

                // einfache funktions zur weitergabe der such anfrage mit 3 parameter 
                List<NetwerkclientsModel> models = new List<NetwerkclientsModel>();
                //
                models = clientsRepository.search(parameter, was, orderBy);
                models = changeDataForGui(models);

                return models;

        }

        // hier eine funktion die allesw aus der Datenbank zurück gibt
        /// <summary>
        /// Mit der ClientsRepository Objekt wird eine suche anfrage zur Datenbank geschickt die alle Netwekclients zurück gibt
        /// </summary>
        /// <returns>List NetwerkclientsModel</returns>
        public List<NetwerkclientsModel> getAllClients()
        {

                List<NetwerkclientsModel> models = new List<NetwerkclientsModel>();
                models = clientsRepository.getClients();
                models = changeDataForGui(models);

                return models;
      
        }
        // diese funktion holt die Header beschriftungen aus der Datenbank
        /// <summary>
        /// Funktion die mir die Headers der Datenbank zurück gibt unter verwendungen der ClientsRepository Objekts
        /// </summary>
        /// <returns>dynamic List</returns>
        public List<dynamic> getHeaders()
        {
            List<dynamic> headers = new List<dynamic>();
            headers = clientsRepository.getDesc();
            return headers;

        }
        // funktion das die datenbank nach den heutigen datum durchsucht und zurück gibt
        /// <summary>
        /// Gibt mit hilfe des ClientsRepository Obejkt all NetzwerkClients des Tages zurück
        /// </summary>
        /// <returns>List NetwerkclientsModel</returns>
        public List<NetwerkclientsModel> getClientsToday()
        {
            List<NetwerkclientsModel> models = new List<NetwerkclientsModel>();
            string datum = DateTime.Today.ToString("d");
            models = clientsRepository.getAllToDay(datum);
            models = changeDataForGui(models);
            return models;
        }

        #endregion

        /// <summary>
        /// Die Heutigen Warnungen werden aus der Datenbank mit hilfe der ClientsRepository - Objekts geholt
        /// Alle Mac-Adressen die mehr als 2 mal zur gleichen zeit vermerkt sind
        /// </summary>
        /// <returns></returns>
        public List<NetwerkclientsModel> getWarningsToday()
        {
            ClientsRepository cr = new ClientsRepository();
            List<NetwerkclientsModel> modelListe = new List<NetwerkclientsModel>();
            modelListe = cr.countDoubleMacInDbToday(DateTime.Today.ToString("dd/MM/yyyy"));
            modelListe = changeDataForGui(modelListe);
            return modelListe;
        }

        /// <summary>
        /// Mit dieser Funktion werden alle mehrfach Einträge der Mac-Adressen wieder gegeben
        /// </summary>
        /// <returns>Liste NetwerkclientsModel</returns>
        public List<NetwerkclientsModel> getWarningsAll()
        {
            ClientsRepository cr = new ClientsRepository();
            List<NetwerkclientsModel> modelListe = new List<NetwerkclientsModel>();
            modelListe = cr.checkDoubleMac();
            modelListe = changeDataForGui(modelListe);
            return modelListe;

        }

        /// <summary>
        /// Hier wird einfach nur alle Datensätze gezählt 
        /// </summary>
        /// <returns>int wieviel</returns>
        public int countAllInDb()
        {
            ClientsRepository cr = new ClientsRepository();
            int wieviel = cr.countValueofDb();
            return wieviel;
        }

    }
}

    //





