namespace TrackingObat
{
    partial class FormCekStok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCekStok));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAkhir = new System.Windows.Forms.Button();
            this.btnAwal = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnSesudah = new System.Windows.Forms.Button();
            this.btnSebelum = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbEntry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioFilter = new System.Windows.Forms.RadioButton();
            this.cmbMaster = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnBersih = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAkhir);
            this.groupBox2.Controls.Add(this.btnAwal);
            this.groupBox2.Controls.Add(this.lblPageInfo);
            this.groupBox2.Controls.Add(this.btnSesudah);
            this.groupBox2.Controls.Add(this.btnSebelum);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbEntry);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dgvData);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1213, 559);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Obat";
            // 
            // btnAkhir
            // 
            this.btnAkhir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAkhir.Location = new System.Drawing.Point(278, 501);
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
            this.btnAwal.Location = new System.Drawing.Point(11, 501);
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
            this.lblPageInfo.Location = new System.Drawing.Point(410, 510);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(0, 15);
            this.lblPageInfo.TabIndex = 29;
            // 
            // btnSesudah
            // 
            this.btnSesudah.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSesudah.Location = new System.Drawing.Point(189, 501);
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
            this.btnSebelum.Location = new System.Drawing.Point(100, 501);
            this.btnSebelum.Name = "btnSebelum";
            this.btnSebelum.Size = new System.Drawing.Size(83, 32);
            this.btnSebelum.TabIndex = 27;
            this.btnSebelum.Text = "Sebelum";
            this.btnSebelum.UseVisualStyleBackColor = true;
            this.btnSebelum.Click += new System.EventHandler(this.btnSebelum_Click);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tampilkan :";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(11, 58);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(1195, 424);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBersih);
            this.groupBox1.Controls.Add(this.cmbFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbMaster);
            this.groupBox1.Controls.Add(this.radioFilter);
            this.groupBox1.Controls.Add(this.radioAll);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(11, 24);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(67, 21);
            this.radioAll.TabIndex = 0;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "Semua";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // radioFilter
            // 
            this.radioFilter.AutoSize = true;
            this.radioFilter.Location = new System.Drawing.Point(11, 51);
            this.radioFilter.Name = "radioFilter";
            this.radioFilter.Size = new System.Drawing.Size(56, 21);
            this.radioFilter.TabIndex = 1;
            this.radioFilter.TabStop = true;
            this.radioFilter.Text = "Filter";
            this.radioFilter.UseVisualStyleBackColor = true;
            this.radioFilter.CheckedChanged += new System.EventHandler(this.radioFilter_CheckedChanged);
            // 
            // cmbMaster
            // 
            this.cmbMaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaster.FormattingEnabled = true;
            this.cmbMaster.Items.AddRange(new object[] {
            "Golongan Obat",
            "Bentuk Sediaan",
            "Jenis Obat"});
            this.cmbMaster.Location = new System.Drawing.Point(250, 21);
            this.cmbMaster.Name = "cmbMaster";
            this.cmbMaster.Size = new System.Drawing.Size(304, 25);
            this.cmbMaster.TabIndex = 3;
            this.cmbMaster.SelectedIndexChanged += new System.EventHandler(this.cmbMaster_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter Berdasarkan :";
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Golongan Obat",
            "Bentuk Sediaan",
            "Jenis Obat"});
            this.cmbFilter.Location = new System.Drawing.Point(250, 51);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(304, 25);
            this.cmbFilter.TabIndex = 5;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // btnBersih
            // 
            this.btnBersih.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBersih.Location = new System.Drawing.Point(11, 85);
            this.btnBersih.Name = "btnBersih";
            this.btnBersih.Size = new System.Drawing.Size(97, 27);
            this.btnBersih.TabIndex = 17;
            this.btnBersih.Text = "BATAL";
            this.btnBersih.UseVisualStyleBackColor = true;
            this.btnBersih.Click += new System.EventHandler(this.btnBersih_Click_1);
            // 
            // Button4
            // 
            this.Button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button4.Location = new System.Drawing.Point(610, 77);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(140, 30);
            this.Button4.TabIndex = 18;
            this.Button4.Text = "KELUAR";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(610, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 19;
            this.button1.Text = "EXPORT KE EXCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCekStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 711);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1253, 750);
            this.MinimumSize = new System.Drawing.Size(1253, 726);
            this.Name = "FormCekStok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cek Stok";
            this.Load += new System.EventHandler(this.FormCekStok_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbEntry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnAkhir;
        private System.Windows.Forms.Button btnAwal;
        internal System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnSesudah;
        private System.Windows.Forms.Button btnSebelum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaster;
        private System.Windows.Forms.RadioButton radioFilter;
        private System.Windows.Forms.RadioButton radioAll;
        internal System.Windows.Forms.Button btnBersih;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button button1;
    }
}