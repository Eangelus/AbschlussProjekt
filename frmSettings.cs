
using System;

using System.Windows.Forms;

using VitescoNetzwerk._4._8;

namespace Vitesco_Netzwerk
{
    public partial class frmSettings : Form
    {
        Settings s = new Settings();

        public frmSettings()
        {
            InitializeComponent();

            s = s.readSettings();

            lb_databankVerzeichnis_aktiv.Text = s.qDatenbank;
            lb_MacLogs_Verzeichnis.Text = s.qMacLog;
            lb_qip_Verzeichnis.Text = s.qQip;
            lb_url_Hersteller.Text = s.qHerstellerListe;
            if( s.pruefenbeiStart == "1")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            s.readSettings();
            //openFileDialog1.ShowDialog();
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK) { 
                string filename = openFileDialog1.FileName;

                    s.qDatenbank = filename;
                    s.setToJson(s);
            }

        }

        private void btn_od_QipVer_Click(object sender, EventArgs e)
        {

            s.readSettings();
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                s.qQip = filename;
                s.setToJson(s);
            }
        }

        private void btn_od_MacLogVer_Click(object sender, EventArgs e)
        {
            s.readSettings();
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                s.qMacLog = filename;
                s.setToJson(s);
            }
        }

        private void btn_save_url_Click(object sender, EventArgs e)
        {
            s.readSettings();
            s.qHerstellerListe = tb_url.Text;

            s.setToJson(s);
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                s.pruefenbeiStart = "1";
            }
            else
            {
                s.pruefenbeiStart = "0";
            }
        }
    }
}
