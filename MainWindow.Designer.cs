
using System.Windows.Forms;

namespace Vitesco_Netzwerk
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.navipanel = new System.Windows.Forms.Panel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnStandort = new System.Windows.Forms.Button();
            this.btnWarnung = new System.Windows.Forms.Button();
            this.btnUebersicht = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_programmname = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lMenge = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PnlFormLoader = new System.Windows.Forms.Panel();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUebersicht1 = new System.Windows.Forms.Button();
            this.btnInfo1 = new System.Windows.Forms.Button();
            this.btnWarnung1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_gesamtAnzahl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.viewPanel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlFormLoader.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.navipanel);
            this.panel1.Controls.Add(this.btnInfo);
            this.panel1.Controls.Add(this.btnStandort);
            this.panel1.Controls.Add(this.btnWarnung);
            this.panel1.Controls.Add(this.btnUebersicht);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 1020);
            this.panel1.TabIndex = 0;
            // 
            // navipanel
            // 
            this.navipanel.BackColor = System.Drawing.Color.Yellow;
            this.navipanel.Location = new System.Drawing.Point(0, 193);
            this.navipanel.Name = "navipanel";
            this.navipanel.Size = new System.Drawing.Size(3, 100);
            this.navipanel.TabIndex = 2;
            // 
            // btnInfo
            // 
            this.btnInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInfo.Location = new System.Drawing.Point(0, 978);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(186, 42);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "Settings";
            this.btnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // btnStandort
            // 
            this.btnStandort.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStandort.FlatAppearance.BorderSize = 0;
            this.btnStandort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStandort.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStandort.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStandort.Image = ((System.Drawing.Image)(resources.GetObject("btnStandort.Image")));
            this.btnStandort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStandort.Location = new System.Drawing.Point(0, 228);
            this.btnStandort.Name = "btnStandort";
            this.btnStandort.Size = new System.Drawing.Size(186, 42);
            this.btnStandort.TabIndex = 1;
            this.btnStandort.Text = "Standort";
            this.btnStandort.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStandort.UseVisualStyleBackColor = true;
            // 
            // btnWarnung
            // 
            this.btnWarnung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWarnung.FlatAppearance.BorderSize = 0;
            this.btnWarnung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarnung.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnWarnung.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWarnung.Image = ((System.Drawing.Image)(resources.GetObject("btnWarnung.Image")));
            this.btnWarnung.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWarnung.Location = new System.Drawing.Point(0, 186);
            this.btnWarnung.Name = "btnWarnung";
            this.btnWarnung.Size = new System.Drawing.Size(186, 42);
            this.btnWarnung.TabIndex = 1;
            this.btnWarnung.Text = "Warnungen";
            this.btnWarnung.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnWarnung.UseVisualStyleBackColor = true;
            // 
            // btnUebersicht
            // 
            this.btnUebersicht.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUebersicht.FlatAppearance.BorderSize = 0;
            this.btnUebersicht.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersicht.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUebersicht.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUebersicht.Image = ((System.Drawing.Image)(resources.GetObject("btnUebersicht.Image")));
            this.btnUebersicht.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUebersicht.Location = new System.Drawing.Point(0, 144);
            this.btnUebersicht.Name = "btnUebersicht";
            this.btnUebersicht.Size = new System.Drawing.Size(186, 42);
            this.btnUebersicht.TabIndex = 1;
            this.btnUebersicht.Text = "Übersicht";
            this.btnUebersicht.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUebersicht.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_programmname);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 144);
            this.panel2.TabIndex = 0;
            // 
            // label_programmname
            // 
            this.label_programmname.AutoSize = true;
            this.label_programmname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_programmname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_programmname.Location = new System.Drawing.Point(12, 109);
            this.label_programmname.Name = "label_programmname";
            this.label_programmname.Size = new System.Drawing.Size(156, 25);
            this.label_programmname.TabIndex = 1;
            this.label_programmname.Text = "NetzwerkScaner";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lMenge
            // 
            this.lMenge.AutoSize = true;
            this.lMenge.Location = new System.Drawing.Point(497, 7);
            this.lMenge.Name = "lMenge";
            this.lMenge.Size = new System.Drawing.Size(58, 20);
            this.lMenge.TabIndex = 1;
            this.lMenge.Text = "Menge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "synchronisiere:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1548, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anzahl an Datensätze:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(140, 8);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(167, 24);
            this.progressBar1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(202, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 48);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Übersicht";
            // 
            // PnlFormLoader
            // 
            this.PnlFormLoader.AutoSize = true;
            this.PnlFormLoader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlFormLoader.Controls.Add(this.viewPanel);
            this.PnlFormLoader.Controls.Add(this.lMenge);
            this.PnlFormLoader.Controls.Add(this.label2);
            this.PnlFormLoader.Controls.Add(this.progressBar1);
            this.PnlFormLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlFormLoader.Location = new System.Drawing.Point(186, 0);
            this.PnlFormLoader.Name = "PnlFormLoader";
            this.PnlFormLoader.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.PnlFormLoader.Size = new System.Drawing.Size(1708, 1020);
            this.PnlFormLoader.TabIndex = 4;
            // 
            // viewPanel
            // 
            this.viewPanel.AutoScrollMargin = new System.Drawing.Size(200, 100);
            this.viewPanel.AutoSize = true;
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 50);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(1706, 968);
            this.viewPanel.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(189, 1024);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(189, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnUebersicht1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInfo1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnWarnung1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.79452F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.20548F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(183, 350);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnUebersicht1
            // 
            this.btnUebersicht1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUebersicht1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersicht1.Location = new System.Drawing.Point(3, 7);
            this.btnUebersicht1.Name = "btnUebersicht1";
            this.btnUebersicht1.Size = new System.Drawing.Size(177, 42);
            this.btnUebersicht1.TabIndex = 0;
            this.btnUebersicht1.Text = "Uebersicht";
            this.btnUebersicht1.UseVisualStyleBackColor = true;
            this.btnUebersicht1.Click += new System.EventHandler(this.btnUebersicht1_Click_1);
            this.btnUebersicht1.Leave += new System.EventHandler(this.btnUebersicht1_Leave_1);
            // 
            // btnInfo1
            // 
            this.btnInfo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo1.Location = new System.Drawing.Point(3, 310);
            this.btnInfo1.Name = "btnInfo1";
            this.btnInfo1.Size = new System.Drawing.Size(177, 37);
            this.btnInfo1.TabIndex = 4;
            this.btnInfo1.Text = "Einstellungen";
            this.btnInfo1.UseVisualStyleBackColor = true;
            this.btnInfo1.Click += new System.EventHandler(this.btnInfo1_Click);
            // 
            // btnWarnung1
            // 
            this.btnWarnung1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarnung1.Location = new System.Drawing.Point(3, 59);
            this.btnWarnung1.Name = "btnWarnung1";
            this.btnWarnung1.Size = new System.Drawing.Size(177, 41);
            this.btnWarnung1.TabIndex = 1;
            this.btnWarnung1.Text = "Warnungen";
            this.btnWarnung1.UseVisualStyleBackColor = true;
            this.btnWarnung1.Click += new System.EventHandler(this.btnWarnung1_Click_1);
            this.btnWarnung1.Leave += new System.EventHandler(this.btnWarnung1_Leave_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.lb_gesamtAnzahl);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblTitle1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(189, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1709, 62);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lb_gesamtAnzahl
            // 
            this.lb_gesamtAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_gesamtAnzahl.AutoSize = true;
            this.lb_gesamtAnzahl.Location = new System.Drawing.Point(1079, 22);
            this.lb_gesamtAnzahl.Name = "lb_gesamtAnzahl";
            this.lb_gesamtAnzahl.Size = new System.Drawing.Size(58, 20);
            this.lb_gesamtAnzahl.TabIndex = 3;
            this.lb_gesamtAnzahl.Text = "Menge";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(892, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gesamte Datensätze:";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.Location = new System.Drawing.Point(6, 22);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(202, 37);
            this.lblTitle1.TabIndex = 1;
            this.lblTitle1.Text = "Willkommen";
            // 
            // viewPanel1
            // 
            this.viewPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.viewPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel1.Location = new System.Drawing.Point(189, 62);
            this.viewPanel1.Name = "viewPanel1";
            this.viewPanel1.Size = new System.Drawing.Size(1709, 962);
            this.viewPanel1.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.viewPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlFormLoader.ResumeLayout(false);
            this.PnlFormLoader.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel navipanel;
        private Button btnInfo;
        private Button btnStandort;
        private Button btnWarnung;
        private Button btnUebersicht;
        private Panel panel2;
        private Label label_programmname;
        private PictureBox pictureBox1;
        private Label lblTitle;
        private Panel PnlFormLoader;
        private Label lMenge;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private Panel viewPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox2;
        private Button btnUebersicht1;
        private Button btnWarnung1;
        private Button btnInfo1;
        private Panel panel3;
        private Panel viewPanel1;
        private Label lblTitle1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lb_gesamtAnzahl;
        private Label label3;
    }
}