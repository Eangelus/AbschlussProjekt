using System.Windows.Forms;

namespace Vitesco_Netzwerk
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lSettingServer = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_databankVerzeichnis_aktiv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_od_QipVer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save_url = new System.Windows.Forms.Button();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_od_MacLogVer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_qip_Verzeichnis = new System.Windows.Forms.Label();
            this.lb_MacLogs_Verzeichnis = new System.Windows.Forms.Label();
            this.lb_url_Hersteller = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lSettingServer
            // 
            this.lSettingServer.AutoSize = true;
            this.lSettingServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lSettingServer.Location = new System.Drawing.Point(0, 0);
            this.lSettingServer.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lSettingServer.Name = "lSettingServer";
            this.lSettingServer.Padding = new System.Windows.Forms.Padding(10, 9, 0, 0);
            this.lSettingServer.Size = new System.Drawing.Size(188, 29);
            this.lSettingServer.TabIndex = 0;
            this.lSettingServer.Text = "Datenbank Verzeichnis:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "NetzwerkTable.db";
            this.openFileDialog1.Title = "Datenbank wählen";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Öffnen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_databankVerzeichnis_aktiv
            // 
            this.lb_databankVerzeichnis_aktiv.AutoSize = true;
            this.lb_databankVerzeichnis_aktiv.Location = new System.Drawing.Point(214, 9);
            this.lb_databankVerzeichnis_aktiv.Name = "lb_databankVerzeichnis_aktiv";
            this.lb_databankVerzeichnis_aktiv.Size = new System.Drawing.Size(196, 20);
            this.lb_databankVerzeichnis_aktiv.TabIndex = 2;
            this.lb_databankVerzeichnis_aktiv.Text = "TextZumFindenDesLabels";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "QIP-Report Verzeichnis:";
            // 
            // btn_od_QipVer
            // 
            this.btn_od_QipVer.Location = new System.Drawing.Point(12, 135);
            this.btn_od_QipVer.Name = "btn_od_QipVer";
            this.btn_od_QipVer.Size = new System.Drawing.Size(80, 40);
            this.btn_od_QipVer.TabIndex = 4;
            this.btn_od_QipVer.Text = "Öffnen";
            this.btn_od_QipVer.UseVisualStyleBackColor = true;
            this.btn_od_QipVer.Click += new System.EventHandler(this.btn_od_QipVer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_save_url);
            this.panel1.Controls.Add(this.tb_url);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_od_MacLogVer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lSettingServer);
            this.panel1.Controls.Add(this.btn_od_QipVer);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 415);
            this.panel1.TabIndex = 5;
            // 
            // btn_save_url
            // 
            this.btn_save_url.Location = new System.Drawing.Point(12, 368);
            this.btn_save_url.Name = "btn_save_url";
            this.btn_save_url.Size = new System.Drawing.Size(98, 35);
            this.btn_save_url.TabIndex = 9;
            this.btn_save_url.Text = "Speichern";
            this.btn_save_url.UseVisualStyleBackColor = true;
            this.btn_save_url.Click += new System.EventHandler(this.btn_save_url_Click);
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(12, 328);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(175, 26);
            this.tb_url.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hersteller URL:";
            // 
            // btn_od_MacLogVer
            // 
            this.btn_od_MacLogVer.Location = new System.Drawing.Point(12, 229);
            this.btn_od_MacLogVer.Name = "btn_od_MacLogVer";
            this.btn_od_MacLogVer.Size = new System.Drawing.Size(80, 40);
            this.btn_od_MacLogVer.TabIndex = 6;
            this.btn_od_MacLogVer.Text = "Öffnen";
            this.btn_od_MacLogVer.UseVisualStyleBackColor = true;
            this.btn_od_MacLogVer.Click += new System.EventHandler(this.btn_od_MacLogVer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "MacLogs Verzeichnis:";
            // 
            // lb_qip_Verzeichnis
            // 
            this.lb_qip_Verzeichnis.AutoSize = true;
            this.lb_qip_Verzeichnis.Location = new System.Drawing.Point(214, 102);
            this.lb_qip_Verzeichnis.Name = "lb_qip_Verzeichnis";
            this.lb_qip_Verzeichnis.Size = new System.Drawing.Size(196, 20);
            this.lb_qip_Verzeichnis.TabIndex = 6;
            this.lb_qip_Verzeichnis.Text = "TextZumFindenDesLabels";
            // 
            // lb_MacLogs_Verzeichnis
            // 
            this.lb_MacLogs_Verzeichnis.AutoSize = true;
            this.lb_MacLogs_Verzeichnis.Location = new System.Drawing.Point(214, 192);
            this.lb_MacLogs_Verzeichnis.Name = "lb_MacLogs_Verzeichnis";
            this.lb_MacLogs_Verzeichnis.Size = new System.Drawing.Size(196, 20);
            this.lb_MacLogs_Verzeichnis.TabIndex = 7;
            this.lb_MacLogs_Verzeichnis.Text = "TextZumFindenDesLabels";
            // 
            // lb_url_Hersteller
            // 
            this.lb_url_Hersteller.AutoSize = true;
            this.lb_url_Hersteller.Location = new System.Drawing.Point(214, 288);
            this.lb_url_Hersteller.Name = "lb_url_Hersteller";
            this.lb_url_Hersteller.Size = new System.Drawing.Size(196, 20);
            this.lb_url_Hersteller.TabIndex = 8;
            this.lb_url_Hersteller.Text = "TextZumFindenDesLabels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Prüfung bei Programstart?";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(452, 342);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 24);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "ja/nein";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(639, 415);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_url_Hersteller);
            this.Controls.Add(this.lb_MacLogs_Verzeichnis);
            this.Controls.Add(this.lb_qip_Verzeichnis);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_databankVerzeichnis_aktiv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lSettingServer;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Label lb_databankVerzeichnis_aktiv;
        private Label label1;
        private Button btn_od_QipVer;
        private Panel panel1;
        private Button btn_od_MacLogVer;
        private Label label2;
        private Label lb_qip_Verzeichnis;
        private Label lb_MacLogs_Verzeichnis;
        private TextBox tb_url;
        private Label label3;
        private Label lb_url_Hersteller;
        private Button btn_save_url;
        private Label label4;
        private CheckBox checkBox1;
    }
}