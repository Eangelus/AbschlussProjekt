using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vitesco_Netzwerk.src;
using VitescoNetzwerk._4._8;

namespace Vitesco_Netzwerk
{
    public partial class MainWindow : Form
    {
        public static bool gefüllt = false;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottumRect,
            int nWidthEllipse,
            int nHeightEllipse
            );


        /// <summary>
        /// Das ist das Hauptfenster
        /// </summary>
        public MainWindow()
        {
            
            // Lade settings aus der Json
            Settings settings = new Settings(); 
            settings = settings.readSettings();

            // inizialisieren der Obj
            Logic logic = new Logic();

            InitializeComponent();

            // view panle einstellungen
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            frmSuche frmSuche = new frmSuche() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            viewPanel1.Height = frmSuche.Height;
            viewPanel1.Top = frmSuche.Top;
            viewPanel1.Left = frmSuche.Left;
            viewPanel1.BackColor = Color.FromArgb(248, 242, 127);
            lblTitle1.Text = "Übersicht";
            this.viewPanel1.Controls.Clear();
            frmSuche.FormBorderStyle = FormBorderStyle.None;
            this.viewPanel1.Controls.Add(frmSuche);
            frmSuche.Show();
            // Funkltionsaufruf für das füllen der Datenbank
            if (settings.pruefenbeiStart == "1")
            {
                fillDb();
            }

            this.lb_gesamtAnzahl.Text = logic.countAllInDb().ToString(); 





        }

        // asyncrone funktions die in einen Extra Task geschoben wird
        // Gui und Füllen der Datenbank soll unabhändig sein
        /// <summary>
        /// Hier ist eine Funktion die, die Logik klasse aufruf und in einen Neuen Task ausführt
        /// </summary>
        public async void fillDb()
        {
            try
            {
                // hier wird meine Logicklasse erzeug und in den neuen task übergeben
                Logic logic = new Logic();
                await Task.Run(() => logic.isDbOk());
                
            }
            catch ( Exception e) { Logger logger = new Logger(); logger.logWrite("Form1 / FillDb()", "Beim Versucht den Task zum füllen der Datanbank ist was schiefgelaufen."); }


        }



        /// <summary>
        /// Automatisch generierte Funktion beim verlassen des Buttons 
        /// Farbänderung beim verlassen der maus des Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStandort1_Leave(object sender, EventArgs e)
        {
            // rgb einstellungeen
            btnStandort.BackColor = Color.FromArgb(242, 229, 0);
        }

        /// <summary>
        /// 
        /// Automatisch generierte Funktion beim verlassen des Buttons 
        /// Farbänderung beim verlassen der maus des Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Leave(object sender, EventArgs e)
        {
            // rgb einstelungen 
            btnInfo.BackColor = Color.FromArgb(242, 229, 0);
        }

        
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Klick funktion mit Farbänderung und aufrufen des Warungen-Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWarnung1_Click_1(object sender, EventArgs e)
        {
            // rgb einstellungen
            viewPanel1.Height = btnWarnung1.Height;
            viewPanel1.Top = btnWarnung1.Top;
            viewPanel1.Left = btnWarnung1.Left;
            btnWarnung1.BackColor = Color.FromArgb(248, 242, 127);

            lblTitle1.Text = "Warnungen";
            this.viewPanel1.Controls.Clear();
            frmWarnungen frmWarnungen = new frmWarnungen() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmWarnungen.FormBorderStyle = FormBorderStyle.None;
            this.viewPanel1.Controls.Add(frmWarnungen);
            frmWarnungen.Show();
        }

        /// <summary>
        /// Klick funktion mit Farbänderung und aufrufen des Uebersichts-Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUebersicht1_Click_1(object sender, EventArgs e)
        {
            //  Farbeinstellungen und veränderungen 
            viewPanel1.Height = btnUebersicht1.Height;
            viewPanel1.Top = btnUebersicht1.Top;
            viewPanel1.Left = btnUebersicht1.Left;
            btnUebersicht1.BackColor = Color.FromArgb(248, 242, 127);
            lblTitle1.Text = "Übersicht";
            this.viewPanel1.Controls.Clear();
            frmSuche frmSuche = new frmSuche() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmSuche.FormBorderStyle = FormBorderStyle.None;
            this.viewPanel1.Controls.Add(frmSuche);
            frmSuche.Show();

        }

        private void btnUebersicht1_Leave_1(object sender, EventArgs e)
        {
            // farbeinstelunge bei verlassen des knopfes
            btnUebersicht1.BackColor = Color.FromArgb(242, 229, 0);
        }

        private void btnWarnung1_Leave_1(object sender, EventArgs e)
        {
            // rgb einstellungen
            btnWarnung1.BackColor = Color.FromArgb(242, 229, 0);
        }

        /// <summary>
        /// Klick funktion mit Farbänderung und aufrufen des Einstellungs-Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo1_Click(object sender, EventArgs e)
        {
            viewPanel1.Height = btnInfo1.Height;
            viewPanel1.Top = btnInfo1.Top;
            viewPanel1.Left = btnInfo1.Left;
            btnInfo1.BackColor = Color.FromArgb(248, 242, 127);

            // rgb einstellungen 
            lblTitle1.Text = "Settings";
            this.viewPanel1.Controls.Clear();
            frmSettings frmSettings = new frmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmSettings.FormBorderStyle = FormBorderStyle.None;
            this.viewPanel1.Controls.Add(frmSettings);
            frmSettings.Show();
        }



 



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}