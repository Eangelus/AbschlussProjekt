using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Vitesco_Netzwerk.src;

namespace Vitesco_Netzwerk
{
    public partial class frmWarnungen : Form
    {

        Logic logic = new Logic();
        public frmWarnungen()
        {
            InitializeComponent();

 
            dataGridViewWarung.DataSource = logic.getWarningsToday();

            // neu anordung des GridViews 

            dataGridViewWarung.Columns[12].HeaderText = "Hostname";
            dataGridViewWarung.Columns[4].HeaderText = "VLAN";

            dataGridViewWarung.Columns["Datum"].DisplayIndex = 0;
            dataGridViewWarung.Columns["Uhrzeit"].DisplayIndex = 1;
            dataGridViewWarung.Columns["Name"].DisplayIndex = 2;

            //if (Form1.gefüllt == true)
            //{
            //    //var wVonDataBase = cr.SucheNachParameter("IP_Adresse", "", "Datum");
            //    //dataGridViewWarung.DataSource = wVonDataBase;
            //    //dataGridViewWarung.DataSource = Tabelle.auffälige;

            //    dataGridViewWarung.DataSource = cr.checkDoubleMac();
            //}
            //else
            //{

            //}
        }

        private void dataGridViewWarung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_heute.Checked == true)
            {
                
                dataGridViewWarung.DataSource = logic.getWarningsToday();

            }
            if (radioButton2.Checked == true)
            {

                dataGridViewWarung.DataSource = logic.getWarningsAll();
            }
        }

        private void rb_heute_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_heute.Checked == true)
            {
                dataGridViewWarung.DataSource = logic.getWarningsToday(); 
            }
            if (radioButton2.Checked == true)
            {
                
                dataGridViewWarung.DataSource = logic.getWarningsAll();
            }
        }
    }
}
