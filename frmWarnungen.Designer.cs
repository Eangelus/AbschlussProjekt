using System.Windows.Forms;

namespace Vitesco_Netzwerk
{
    partial class frmWarnungen
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rb_heute = new System.Windows.Forms.RadioButton();
            this.dataGridViewWarung = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarung)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1196, 78);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.rb_heute);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 52);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(111, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(91, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Gesamt";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rb_heute
            // 
            this.rb_heute.AutoSize = true;
            this.rb_heute.Checked = true;
            this.rb_heute.Location = new System.Drawing.Point(15, 17);
            this.rb_heute.Name = "rb_heute";
            this.rb_heute.Size = new System.Drawing.Size(78, 24);
            this.rb_heute.TabIndex = 0;
            this.rb_heute.TabStop = true;
            this.rb_heute.Text = "Heute";
            this.rb_heute.UseVisualStyleBackColor = true;
            this.rb_heute.CheckedChanged += new System.EventHandler(this.rb_heute_CheckedChanged);
            // 
            // dataGridViewWarung
            // 
            this.dataGridViewWarung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarung.Location = new System.Drawing.Point(9, 86);
            this.dataGridViewWarung.Margin = new System.Windows.Forms.Padding(100, 4, 4, 4);
            this.dataGridViewWarung.Name = "dataGridViewWarung";
            this.dataGridViewWarung.RowHeadersWidth = 62;
            this.dataGridViewWarung.RowTemplate.Height = 25;
            this.dataGridViewWarung.Size = new System.Drawing.Size(1196, 380);
            this.dataGridViewWarung.TabIndex = 0;
            this.dataGridViewWarung.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWarung_CellContentClick);
            // 
            // frmWarnungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(229)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1214, 474);
            this.Controls.Add(this.dataGridViewWarung);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmWarnungen";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Text = "frmWarnungen";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridViewTextBoxColumn adresseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn netzworkIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dynamischDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn betriebssystemDataGridViewTextBoxColumn;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton rb_heute;
        private DataGridView dataGridViewWarung;
    }
}