using Vitesco_Netzwerk.src;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Vitesco_Netzwerk
{
    public partial class frmSuche : Form
    {

        // Locale Variablen
        /// <summary>
        /// Klasse des Suchfensters
        /// </summary>
        string parameter;
        string was;
        string orderBy;
        int newSortColumn;
        Logic logic = new Logic();

 
        public frmSuche()
        {



            InitializeComponent();
            // erzeugen von meinen objekten

           
            List<dynamic> list;

            /// <summary>
            /// Es wied dir Logik Klasse verwendet um eine Liste der Headers aus der Datenbank zu bekomme
            /// </summary>
            list = logic.getHeaders();

            /// <summary>
            /// Hier eine Foreach schleife zum füllen der Combobox und ändern der Headers
            /// </summary>
            // füllen der Comboboxen
            foreach (var a in list)
            {

                // namens änderung für die gui
                if(a.name == "Name")
                {
                    a.name = "Hostname";
                }
                if(a.name == "Nummer")
                {
                    a.name = "VLAN";
                }
                comboBox1.Items.Add(a.name);
                cbsort.Items.Add(a.name);
            };

            dataGridView1.DataSource = logic.getClientsToday(); ;
            // des datagrid
            //if (rb_heute.Checked == true)
            //{
                
            //    dataGridView1.DataSource = modelsHeute;
            //}
            //else { dataGridView1.DataSource = models; }

            // Neu anodnung und Umbennenung von Spalten
            dataGridView1.Columns[12].HeaderText = "Hostname";
            dataGridView1.Columns[4].HeaderText = "VLAN";
            
            dataGridView1.Columns["Datum"].DisplayIndex = 0;
            dataGridView1.Columns["Uhrzeit"].DisplayIndex = 1;
            dataGridView1.Columns["Name"].DisplayIndex = 2;
            

        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            // änderung der such funktion
            //models = logic.SucheInDatenBank(this.parameter, textBox1.Text.ToString(), this.orderBy);

            //dataGridView1.DataSource = models;

        }
        // funktion zum namen ändern in der Gui
        /// <summary>
        /// Eine Funktion zum änder der Headers einige mussten umbenannt werden
        /// </summary>
        public void namensAenderung()
        {
            if (this.orderBy == null)
            {
                this.orderBy = "Datum";
            }
            if (this.parameter == "VLAN")
            {
                this.parameter = "Nummer";

            }
            if (this.parameter == "Hostname")
            {
                this.parameter = "Name";
            }
        }
        // combobox musste angepast werden wegen der namensänderung
        /// <summary>
        /// Hier die Funktion zur Combobox, die auswahl wählt und vorher wieder den namen umändern für die Datenbank abfrage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if((string)comboBox1.SelectedItem == "VLAN")
            {
                this.parameter = "Nummer";
            }
            if((string)comboBox1.SelectedItem == "Hostname")
            {
                this.parameter = "Name";
            }
            this.parameter = (string)comboBox1.SelectedItem;
        }

        /// <summary>
        /// Funktion für die Combobox zum sotieren der Anzeige im Gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbsort_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            List<NetwerkclientsModel> models = new List<NetwerkclientsModel>();

            this.orderBy = (string)cbsort.SelectedItem;
            namensAenderungInCbSort();
            models = logic.searchInDb(this.parameter, textBox1.Text.ToString(), this.orderBy);

            // des datagrid
            dataGridView1.DataSource = models;


        }

        // namensänderungsfunktion für das Datagrid
        /// <summary>
        /// Funktion zum Namensändern für die ComboBox sotierung
        /// </summary>
        public void namensAenderungInCbSort()
        {
            if (this.orderBy == "VLAN")
            {
                this.orderBy = "Nummer";
            }
            if (this.parameter == "VALN")
            {
                this.parameter = "Nummer";
            }
            if (this.orderBy == "Hostname")
            {
                this.orderBy = "Name";
            }
            if (this.parameter == "Hostname")
            {
                this.parameter = "Name";
            }
            if (this.orderBy == null)
            {
                this.orderBy = "Datum";
            }
        }


        // funktion zur abfrage der raido button
        /// <summary>
        /// Funktion für die Radion Button Heute und Gesamt 
        /// hier wird unterschieden ob die Gesamte Daten oder die heutigen Daten angezeigt werden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //List<NetwerkclientsModel> models = new List<NetwerkclientsModel>();
            //models = logic.AllesAusDerDatenBank();

            if (rb_heute.Checked == true)
            {
                //List<NetwerkclientsModel> modelsHeute = new List<NetwerkclientsModel>();
                //foreach (NetwerkclientsModel m in models)
                //{
                //    if (m.Datum == DateTime.Today.ToString("dd.MM.yyyy"))
                //    {
                //        modelsHeute.Add(m);
                //    }
                //}
                dataGridView1.DataSource = logic.getClientsToday();
            }
            else { dataGridView1.DataSource = logic.getAllClients(); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Funktion für die Suche, Wenn in der TextBox enter gerdückt wird startet die suche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.parameter = comboBox1.Text;

                List<NetwerkclientsModel> models = new List<NetwerkclientsModel>();
                models = logic.searchInDb(this.parameter, textBox1.Text.ToString(), this.orderBy);

                dataGridView1.DataSource = models;
            }
        }
    }
}
