using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Vitesco_Netzwerk.src;
using VitescoNetzwerk._4._8;
// Klasse zum Handln der Datenbank

namespace Vitesco_Netzwerk
{
    /// <summary>
    /// Diese Klasse dient als Schnitstelle zur Datenbank 
    /// </summary>
    internal class ClientsRepository 
    {
        // lade die Settings durch die Settings.json
        static Settings s = new Settings();
        Settings settings = s.readSettings();
        
        Logger logger = new Logger();
        /// <summary>
        /// Funktion zum testen der Connection zu der Datenbank
        /// </summary>
        public void testeCon()
        {
            try
            {
                // funktion zum testen der Datenbank verbindung
                SQLiteConnection sqlCon;
                sqlCon = new SQLiteConnection($"Data Source={settings.qDatenbank};Version = 3;New = True;Compress = True;");
                sqlCon.Open();
                sqlCon.Close();
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - testeCon()", e.ToString()); }

        }
        #region Funktion zum erstellen einer Verbindung zur Datenbank
        /// <summary>
        /// Erstellt eine Conncection zu der SQLite Datenbank und gibt diese zurück 
        /// </summary>
        /// <returns>SQLiteConnection</returns>
        public SQLiteConnection createConnection()
        {
            try
            {
                Settings s = new Settings();
                Settings settings = s.readSettings();
                string datenbankOrt = settings.qDatenbank;
                int anzahl = datenbankOrt.IndexOf("vt");
                if (anzahl < 4)
                {
                    int fehlendeAnzahl = 4 - anzahl;
                    for (int i = 0; i < fehlendeAnzahl; i++)
                    {
                        datenbankOrt = '\\' + datenbankOrt;
                    }

                }
                Console.WriteLine("CC datenbankort:");
                Console.WriteLine(datenbankOrt);

                // TO DO SETTINGS prüfen ob genug \\\ vorhanden sind
                string constring = "Data Source=" + datenbankOrt + "; Version = 3; New = True; Compress = True; ";
                Console.WriteLine("Constring:");
                Console.WriteLine(constring);
                Console.WriteLine("\nDatenbankort:");
                Console.WriteLine(datenbankOrt);


                SQLiteConnection sqlite_conn;
                // Create a new database connection:
                sqlite_conn = new SQLiteConnection(constring);
                // Open the connection:
                try
                {
                    sqlite_conn.Open();
                    Console.WriteLine("cc hat geklapt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("cc hat nicht geklappt");
                    Console.WriteLine(ex.Message);
                }
                return sqlite_conn;
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - CreateConnextion()", e.ToString()); }
            return null;
        }
        #endregion


        #region Funktion prüfen ob table in der Datenbank vorhanden ist, wen nicht erstellen
        /// <summary>
        /// Funktion zum Prüfen ob die Table in der Datenbank vorhanden ist, fals nicht wird sie erstellt
        /// </summary>
        public void checkTable()
        {
            try
            {
                // funkton zum prüfen und erstellen des Tables in der Datenbank
                NetwerkclientsModel model = new NetwerkclientsModel();

                using (IDbConnection db = createConnection())
                {
                    // genau typen definieren
                    db.Execute($"CREATE TABLE IF NOT EXISTS 'Clients' ( {model.atribute[0]} TEXT, " +
                    $"{model.atribute[1]} TEXT, {model.atribute[2]} TEXT, {model.atribute[3]} TEXT, {model.atribute[4]} TEXT," +
                    $"{model.atribute[5]} TEXT, {model.atribute[6]} TEXT , {model.atribute[7]} TEXT, {model.atribute[8]} TEXT," +
                    $"{model.atribute[9]} TEXT, {model.atribute[10]} TEXT , {model.atribute[11]} TEXT );");

                }
                //Console.WriteLine("checkTable funktioniert");
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - checkTable()", e.ToString()); }

        }
        #endregion
        #region Funktion zum prüfen ob die Datenbank vorhanden ist und automatischen erstellen dieser
        /// <summary>
        /// Hier wird geprüft ob die Datenbank vorhanden ist, wen nicht erstellt sie diese
        /// </summary>
        /// <returns>bool if exist</returns>
        public bool testExsi()
        {
            // funktion zum testen ob die datenbank vorhanden ist und automatisches erstellen dieser
            try
            {
                if (File.Exists(settings.qDatenbank) != true)
                {

                    Console.WriteLine("Keine Datenbank gefunden! --- Erstelle Datanbank ---");
                    SQLiteConnection.CreateFile($"{settings.qDatenbank}");
                    Console.WriteLine("Datenbank erstellt!");

                    return false;



                }
                //Console.WriteLine("testExsi funktioniert");
                return true;
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - testExist()", e.ToString()); }
            return false;
        }

        #endregion

        #region Delete Funktion mit bestimmen datum wird zur kontrolle gebrauch
        /// <summary>
        /// Funktion zum löschen der daten auf der Datenbank mit  bestimmten zeitstempel
        /// </summary>
        /// <param name="datum"></param>
        public void deleteOfDate(string datum)
        {
            try
            {
                // Delete funktion mit bestimmten Datum
                // dient als kontrollfunktion auf vollständigkeit der Datenbank
                // wen die datenbank nicht vollständig ist werden die vorhandenen gelösche und ersetzt
                // evtl bessere löstung
                using (IDbConnection db = createConnection())
                {
                    //MAC_Adresse, Datum,
                    string deleteAllWhreDate = $"DELETE FROM Clients WHERE Datum='{datum}';";
                    db.Execute(deleteAllWhreDate);


                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - DeleteOfDate()", e.ToString()); }
            

        }
        #endregion

        #region Funktion zum aufruf des SQL mit doppelter Macadresse
        /// <summary>
        /// Hier wird ein SQL befehl abgegeben der mit die Doppelten Macadressen zurück gibt
        /// </summary>
        /// <returnsNetzwerkclientsModel></returns>
        public List<NetwerkclientsModel> checkDoubleMac()
        {
            try
            {
                // hier werden alle doppelten einträge von macadressen am gleichen tag
                using (IDbConnection db = createConnection())
                {
                    //MAC_Adresse, Datum,
                    string selectAll = "SELECT *, COUNT(*) FROM Clients GROUP BY MAC_Adresse, Datum HAVING COUNT(*) > 1 ORDER BY MAC_Adresse;";
                    return db.Query<NetwerkclientsModel>(selectAll).ToList();

                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - checkDoubleMac()", e.ToString()); }
            return null;
        }
        #endregion
        #region Fuinktion SELECT all von der Datenbank
        /// <summary>
        /// Funktion die eine SQL anweisung übergibt und die kompletten Daten wieder gibt
        /// SELECT * FROM Clients
        /// </summary>
        /// <returns>List of NetzwerkclientsModel</returns>
        public List<NetwerkclientsModel>  getClients()
        {
            // eine funktion die mir alle einträge gibt 
            // prüfung 
            try
            {
                testExsi();
                checkTable();

                using (IDbConnection db = createConnection())
                {
                    string selectAll = "SELECT * FROM Clients;";
                    return db.Query<NetwerkclientsModel>(selectAll).ToList();

                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - GetClients()", e.ToString()); }
            return null;
        }
        #endregion

        #region Funktion für die Suche von der gui gegebenen Parameter 
        /// <summary>
        /// Sql suche mit Paramter von der GUI 
        /// </summary>
        /// <param name="paramter"></param>
        /// <param name="was"></param>
        /// <param name="orderBy"></param>
        /// <returns>List of Netzwerkclients</returns>
        public List<NetwerkclientsModel> search(string paramter, string was, string orderBy)
        {
            // funktion zum druchsuchen der Datenbank auf bestimmte parameter die in der gui gewählt würden
            try
            {
                using (IDbConnection db = createConnection())
                {
                    if (orderBy == null)
                    {
                        orderBy = "Datum";
                    }
                    if (paramter == null)
                    {
                        paramter = "MAC_Adresse";
                    }
                    if(paramter == "Hostname")
                    {
                        paramter = "Name";
                    }
                    if(paramter == "VLAN")
                    {
                        paramter = "Nummer";
                    }


                        // sicherstellung wen parameter leer sind 

                        was = "'%" + was + "%'";

                        // zusammen bau des SQl strings
                        string selectLike = $"SELECT * FROM Clients Where {paramter} Like {was} ORDER BY {orderBy};";



                        return db.Query<NetwerkclientsModel>(selectLike).ToList();

                    


                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - SucheNachParameter()", e.ToString()); }
            return null;
        }
        #endregion

        #region Funktion zum sotieren 
        //public List<NetwerkclientsModel> UserSC(string userSelect)
        //{
        //    try
        //    {
        //        using (IDbConnection db = CreateConnection())
        //        {
        //            // eine sotierfunktion
        //            string selectAll = $"SELECT * FROM Clients GROUP BY {userSelect};";
        //            return db.Query<NetwerkclientsModel>(selectAll).ToList();

        //        }
        //    }
        //    catch (Exception e) { logger.LogWrite("ClientsRepository - UserSC()", e.ToString()); }
        //    return null;
        //}
        #endregion

        #region Funktion zum übergeben der Model in die Datenbank
        /// <summary>
        /// Hier wird das Model mit einen instert befehl in sql in die datenbank gespeichter
        /// </summary>
        /// <param name="model"></param>
        public void insert(NetwerkclientsModel model)
        {
            try
            {
                // insert in die datenbank  
                // todo  evtl gleich die ganze liste?

                using (IDbConnection db = createConnection())
                {
                    /*"MAC_Adresse", "IP_Adresse", "Device_Name", "Adresse", "Device_Loaction", "Nummer", 
                                "Netzwork_ID","Switch_Name" , "Dynamisch", "Switch_Port", "Betriebssystem", 
                                "Hersteller", "Type", "Geraetetype","Name", "Datum"
                    */
                    string insertQuery = "";
                    insertQuery = String.Format($"INSERT INTO Clients({model.atribute[0]}, {model.atribute[1]}, {model.atribute[2]}, {model.atribute[3]}," +
                                                                                                        $" {model.atribute[4]}, {model.atribute[5]}, {model.atribute[6]}, " +
                                                                                            $"{model.atribute[7]}, {model.atribute[8]}, {model.atribute[9]}, {model.atribute[10]}, {model.atribute[11]}) " +
                    $"values('{model.MAC_Adresse}','{model.IP_Adresse}','{model.Device_Name}','{model.Device_Loaction}','{model.Nummer}'," +
                              $"'{model.Switch_Name}' ,'{model.Switch_Port}','{model.Hersteller}','{model.Type}','{model.Geraetetype}','{model.Name}','{model.Datum}'); ");

                    db.Execute(insertQuery, model);

                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - Insert()", e.ToString()); }

        }

        #endregion





        #region Funktion um die Struktur des Tables zu bekommen
        /// <summary>
        /// Funktion die mit die headers aus der datenbank als dynamische liste wieder gibt
        /// </summary>
        /// <returns>dynamic List of headers from database</returns>
        public List<dynamic> getDesc()
        {
            try
            {
                using (IDbConnection db = createConnection())
                {
                    var a = db.Query("pragma table_info('Clients');");
                    return a.ToList();

                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - getDesc()", e.ToString()); }
            return null;
        }
        #endregion


        //#region Funktion zum bekommen alles Macadressen 
        //public List<dynamic> getallMac()
        //{
        //    try
        //    {
        //        // funktion zum bekommen alles macadresen
        //        using (IDbConnection db = CreateConnection())
        //        {
        //            string selectMac = $"SELECT MAC_Adresse FROM Clients Where MAC_Adresse ;";
        //            var a = db.Query(selectMac);
        //            return a.ToList();

        //        }
        //    }
        //    catch (Exception e) { logger.LogWrite("ClientsRepository - getallMac()", e.ToString()); }
        //    return null;
        //}
        //#endregion



        #region Funktion zum finden aller mac adressen zu einen gewinnsen zeitpunkt
        /// <summary>
        /// ein sql aufruf der mit alle macadresse des heutigen tages wieder gibt
        /// wird zum prüfen auf vollständige übertragen verwendet
        /// </summary>
        /// <param name="datum"></param>
        /// <returns>int of macs today</returns>
        public int findMacsToDay(string datum)
        {
            try
            {
                using (IDbConnection db = createConnection())
                {
                    // alle macadressen am heutigen tag und zeitpunkt
                    // wird zum prüfen benutzt
                    // direkt zählen 
                    string selectMac = $"SELECT COUNT(*) FROM Clients Where Datum='{datum}';";

                    int a = db.ExecuteScalar<int>(selectMac);
                    return a;

                }
            }            catch (Exception e) { logger.logWrite("ClientsRepository - findMacsToDay()", e.ToString()); }
            return 0;
        }
        #endregion

        #region Funktion zum zählen alle daten sätze anhand der Macadresse
        /// <summary>
        /// Diese Funktion Schickt einen SQL bfehle an die Datenbank zum zählen der Mac-Adressen in der Datenbank-Tabelle
        /// </summary>
        /// <returns>Int sum menge an Macadressen in der Datenbanktabelle</returns>
        public int countValueofDb()
        {
            try
            {
                // funktion zum zählen aller einträge
                using (IDbConnection db =createConnection())
                {
                    string countDb = $"SELECT COUNT(MAC_Adresse) FROM Clients;";
                    int sum = db.ExecuteScalar<int>(countDb);
                    return sum;

                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - coutValueofDb()", e.ToString()); }
            return 0;
        }
        #endregion
        /////    <-------- 
        #region Funktion zum zählen aller einträge am heutigen tag
        /// <summary>
        /// Diese Funtkion übergibt einen SQl befehl an die Datenbank der die Doppelten MacAdressen des heutigen Tag liefert 
        /// </summary>
        /// <param name="datum"></param>
        /// <returns>List of Netwerkclients </returns>
        public List<NetwerkclientsModel> countDoubleMacInDbToday(string datum)
        {
            try
            {
                // funktion zum zählen aller einträge
                using (IDbConnection db = createConnection())
                {
                    string doppleMac = $"SELECT *, COUNT(*) FROM Clients WHERE Datum like '{datum}%' GROUP BY MAC_Adresse, Datum HAVING COUNT(*) > 1 ORDER BY MAC_Adresse;";
                    List<NetwerkclientsModel> doppelmacs = db.Query<NetwerkclientsModel>(doppleMac).ToList();
                    return doppelmacs;

                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - countDoubleMacInDbToday()", e.ToString()); }
            return null;
        }
        #endregion


        #region Funktions alles aus der Db heute 
        /// <summary>
        /// Diese Funktion gibt alle Netzwerkclienten des heutigen Tages zurück über einen SQL befehl
        /// </summary>
        /// <param name="datum"></param>
        /// <returns>List of Netzwerkclients today</returns>
        public List<NetwerkclientsModel> getAllToDay(string datum)
        {
            try
            {
                using (IDbConnection db = createConnection())
                {
                    // alle macadressen am heutigen tag und zeitpunkt
                    // wird zum prüfen benutzt
                    // direkt zählen 
                    string selectMac = $"SELECT * FROM Clients Where Datum like'{datum}%';";

                    List<NetwerkclientsModel> a = db.Query<NetwerkclientsModel>(selectMac).ToList(); ;
                    return a;

                }
            }
            catch (Exception e) { logger.logWrite("ClientsRepository - findMacsToDay()", e.ToString()); }
            return null;
        }
        #endregion

    }
}
