namespace TrackingObat
{
    partial class FormInputObat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputObat));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamaObat = new System.Windows.Forms.TextBox();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGolongan = new System.Windows.Forms.ComboBox();
            this.cmbSediaan = new System.Windows.Forms.ComboBox();
            this.cmbJenisObat = new System.Windows.Forms.ComboBox();
            this.txtHargaPBF = new System.Windows.Forms.TextBox();
            this.txtNamaPBF = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Button4 = new System.Windows.Forms.Button();
            this.btnBersih = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEntry = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAkhir = new System.Windows.Forms.Button();
            this.btnAwal = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnSesudah = new System.Windows.Forms.Button();
            this.btnSebelum = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Button4);
            this.groupBox1.Controls.Add(this.btnBersih);
            this.groupBox1.Controls.Add(this.btnSimpan);
            this.groupBox1.Controls.Add(this.txtNamaPBF);
            this.groupBox1.Controls.Add(this.txtHargaPBF);
            this.groupBox1.Controls.Add(this.cmbJenisObat);
            this.groupBox1.Controls.Add(this.cmbSediaan);
            this.groupBox1.Controls.Add(this.cmbGolongan);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtJumlah);
            this.groupBox1.Controls.Add(this.txtNamaObat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 301);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Data";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 17);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Nama Obat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Jumlah";
            // 
            // txtNamaObat
            // 
            this.txtNamaObat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaObat.Location = new System.Drawing.Point(143, 19);
            this.txtNamaObat.Name = "txtNamaObat";
            this.txtNamaObat.Size = new System.Drawing.Size(546, 25);
            this.txtNamaObat.TabIndex = 1;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumlah.Location = new System.Drawing.Point(143, 50);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(92, 25);
            this.txtJumlah.TabIndex = 2;
            this.txtJumlah.TextChanged += new System.EventHandler(this.txtJumlah_TextChanged);
            this.txtJumlah.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJumlah_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bentuk Sediaan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Golongan Obat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Harga PBF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Jenis Obat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nama PBF";
            // 
            // cmbGolongan
            // 
            this.cmbGolongan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGolongan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGolongan.FormattingEnabled = true;
            this.cmbGolongan.Location = new System.Drawing.Point(143, 81);
            this.cmbGolongan.Name = "cmbGolongan";
            this.cmbGolongan.Size = new System.Drawing.Size(546, 25);
            this.cmbGolongan.TabIndex = 3;
            // 
            // cmbSediaan
            // 
            this.cmbSediaan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSediaan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSediaan.FormattingEnabled = true;
            this.cmbSediaan.Location = new System.Drawing.Point(143, 112);
            this.cmbSediaan.Name = "cmbSediaan";
            this.cmbSediaan.Size = new System.Drawing.Size(546, 25);
            this.cmbSediaan.TabIndex = 4;
            // 
            // cmbJenisObat
            // 
            this.cmbJenisObat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenisObat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJenisObat.FormattingEnabled = true;
            this.cmbJenisObat.Location = new System.Drawing.Point(143, 143);
            this.cmbJenisObat.Name = "cmbJenisObat";
            this.cmbJenisObat.Size = new System.Drawing.Size(546, 25);
            this.cmbJenisObat.TabIndex = 5;
            // 
            // txtHargaPBF
            // 
            this.txtHargaPBF.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHargaPBF.Location = new System.Drawing.Point(143, 174);
            this.txtHargaPBF.Name = "txtHargaPBF";
            this.txtHargaPBF.Size = new System.Drawing.Size(249, 25);
            this.txtHargaPBF.TabIndex = 6;
            this.txtHargaPBF.TextChanged += new System.EventHandler(this.txtHargaPBF_TextChanged);
            this.txtHargaPBF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaPBF_KeyPress);
            // 
            // txtNamaPBF
            // 
            this.txtNamaPBF.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaPBF.Location = new System.Drawing.Point(143, 205);
            this.txtNamaPBF.Name = "txtNamaPBF";
            this.txtNamaPBF.Size = new System.Drawing.Size(546, 25);
            this.txtNamaPBF.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAkhir);
            this.groupBox2.Controls.Add(this.btnAwal);
            this.groupBox2.Controls.Add(this.lblPageInfo);
            this.groupBox2.Controls.Add(this.btnSesudah);
            this.groupBox2.Controls.Add(this.btnSebelum);
            this.groupBox2.Controls.Add(this.txtCari);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbEntry);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dgvData);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1213, 369);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Obat";
            // 
            // Button4
            // 
            this.Button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button4.Location = new System.Drawing.Point(217, 252);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(97, 30);
            this.Button4.TabIndex = 17;
            this.Button4.Text = "KELUAR";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // btnBersih
            // 
            this.btnBersih.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBersih.Location = new System.Drawing.Point(114, 252);
            this.btnBersih.Name = "btnBersih";
            this.btnBersih.Size = new System.Drawing.Size(97, 30);
            this.btnBersih.TabIndex = 16;
            this.btnBersih.Text = "BATAL";
            this.btnBersih.UseVisualStyleBackColor = true;
            this.btnBersih.Click += new System.EventHandler(this.btnBersih_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(11, 252);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(97, 30);
            this.btnSimpan.TabIndex = 15;
            this.btnSimpan.Text = "SIMPAN";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(11, 58);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(1195, 256);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tampilkan :";
            // 
            // cmbEntry
            // 
            this.cmbEntry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntry.FormattingEnabled = true;
            this.cmbEntry.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25"});
            this.cmbEntry.Location = new System.Drawing.Point(91, 24);
            this.cmbEntry.Name = "cmbEntry";
            this.cmbEntry.Size = new System.Drawing.Size(51, 25);
            this.cmbEntry.TabIndex = 2;
            this.cmbEntry.SelectedIndexChanged += new System.EventHandler(this.cmbEntry_SelectedIndexChanged_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "data";
            // 
            // txtCari
            // 
            this.txtCari.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCari.Location = new System.Drawing.Point(380, 25);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(546, 25);
            this.txtCari.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(336, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Cari :";
            // 
            // btnAkhir
            // 
            this.btnAkhir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAkhir.Location = new System.Drawing.Point(278, 324);
            this.btnAkhir.Name = "btnAkhir";
            this.btnAkhir.Size = new System.Drawing.Size(83, 32);
            this.btnAkhir.TabIndex = 31;
            this.btnAkhir.Text = "Akhir";
            this.btnAkhir.UseVisualStyleBackColor = true;
            this.btnAkhir.Click += new System.EventHandler(this.btnAkhir_Click);
            // 
            // btnAwal
            // 
            this.btnAwal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAwal.Location = new System.Drawing.Point(11, 324);
            this.btnAwal.Name = "btnAwal";
            this.btnAwal.Size = new System.Drawing.Size(83, 32);
            this.btnAwal.TabIndex = 30;
            this.btnAwal.Text = "Awal";
            this.btnAwal.UseVisualStyleBackColor = true;
            this.btnAwal.Click += new System.EventHandler(this.btnAwal_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.ForeColor = System.Drawing.Color.Black;
            this.lblPageInfo.Location = new System.Drawing.Point(390, 333);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(0, 15);
            this.lblPageInfo.TabIndex = 29;
            // 
            // btnSesudah
            // 
            this.btnSesudah.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSesudah.Location = new System.Drawing.Point(189, 324);
            this.btnSesudah.Name = "btnSesudah";
            this.btnSesudah.Size = new System.Drawing.Size(83, 32);
            this.btnSesudah.TabIndex = 28;
            this.btnSesudah.Text = "Selanjutnya";
            this.btnSesudah.UseVisualStyleBackColor = true;
            this.btnSesudah.Click += new System.EventHandler(this.btnSesudah_Click);
            // 
            // btnSebelum
            // 
            this.btnSebelum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSebelum.Location = new System.Drawing.Point(100, 324);
            this.btnSebelum.Name = "btnSebelum";
            this.btnSebelum.Size = new System.Drawing.Size(83, 32);
            this.btnSebelum.TabIndex = 27;
            this.btnSebelum.Text = "Sebelum";
            this.btnSebelum.UseVisualStyleBackColor = true;
            this.btnSebelum.Click += new System.EventHandler(this.btnSebelum_Click);
            // 
            // FormInputObat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 711);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1253, 750);
            this.MinimumSize = new System.Drawing.Size(1253, 726);
            this.Name = "FormInputObat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Obat";
            this.Load += new System.EventHandler(this.FormInputObat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtNamaPBF;
        internal System.Windows.Forms.TextBox txtHargaPBF;
        private System.Windows.Forms.ComboBox cmbJenisObat;
        private System.Windows.Forms.ComboBox cmbSediaan;
        private System.Windows.Forms.ComboBox cmbGolongan;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtJumlah;
        internal System.Windows.Forms.TextBox txtNamaObat;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button btnBersih;
        internal System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbEntry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvData;
        internal System.Windows.Forms.TextBox txtCari;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAkhir;
        private System.Windows.Forms.Button btnAwal;
        internal System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnSesudah;
        private System.Windows.Forms.Button btnSebelum;
    }
}