using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace TrackingObat
{
    public partial class FormCekStok : Form
    {
        private int id;
        private int currentPage = 1;
        private int totalPages = 1;

        public FormCekStok()
        {
            InitializeComponent();
            cmbEntry.Text = "20";
            cmbEntry.SelectedIndexChanged += CmbEntry_SelectedIndexChanged;
        }

       
        private DataTable dataObat(int page, int size, string filter)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    DataTable dt = new DataTable();
                    conn.Open();
                    string query = @"SELECT tr.id_trans,tr.nama_obat,tr.jumlah,tr.golongan_obat,tr.bentuk_sediaan,
                             tr.jenis_obat,tr.harga_pbf,tr.nama_pbf,op1.nama AS 'operator_input',
                             tr.created_at,tr.updated_at, op2.nama AS 'operator_edit' 
                             FROM transaksi_input_obat tr 
                             LEFT JOIN user op1 ON tr.operator=op1.username 
                             LEFT JOIN user op2 ON tr.updated_by=op2.username ";
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        query += @"WHERE tr.golongan_obat = @filter OR 
                                   tr.bentuk_sediaan = @filter OR 
                                   tr.jenis_obat = @filter ";
                        parameters.Add(new SQLiteParameter("@filter", filter));
                    }
                    int offset = (page - 1) * size;
                    query += " ORDER BY tr.nama_obat ASC LIMIT @pageSize OFFSET @offset";
                    parameters.Add(new SQLiteParameter("@pageSize", size));
                    parameters.Add(new SQLiteParameter("@offset", offset));

                    using (var da = new SQLiteDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                        da.Fill(dt);
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    // Log error instead of showing directly
                    MessageBox.Show($"Error loading data: {ex.Message}");
                    return null;
                }
            }
        }

        public int getRecords(string filter)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    int totalRecords = 0;
                    DataTable dt = new DataTable();
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM transaksi_input_obat tr 
                                     LEFT JOIN user op1 ON tr.operator=op1.nama 
                                     LEFT JOIN user op2 ON tr.updated_by=op2.nama ";
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    if (filter != string.Empty)
                    {
                        query += @"WHERE tr.nama_obat LIKE @filter ";
                        parameters.Add(new SQLiteParameter("@filter", "%" + filter + "%"));
                    }
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        totalRecords = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    return totalRecords;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }

        public void tampilData()
        {
            dgvData.Columns.Clear();
            dgvData.DataSource = null;
            string cari = "";
            int pageSize = int.Parse(cmbEntry.Text);
            if (cmbFilter.Text != string.Empty)
            {
                cari = cmbFilter.Text;
            }
            int totalRecords = getRecords(cari);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            DataTable data = dataObat(currentPage, pageSize, cari);
            dgvData.DataSource = data;
            dataGrid();
            UpdatePaginationControls();
        }

        private void dataGrid()
        {
            DGVProperties.dgvProperties(dgvData);

            dgvData.Columns[1].Width = 150;
            dgvData.Columns[2].Width = 150;
            dgvData.Columns[3].Width = 150;
            dgvData.Columns[4].Width = 150;
            dgvData.Columns[5].Width = 150;
            dgvData.Columns[6].Width = 150;
            dgvData.Columns[7].Width = 150;
            dgvData.Columns[8].Width = 100;
            dgvData.Columns[9].Width = 100;
            dgvData.Columns[10].Width = 100;
            dgvData.Columns[11].Width = 100;
            dgvData.Columns[0].HeaderText = "ID";
            dgvData.Columns[1].HeaderText = "Nama Obat";
            dgvData.Columns[2].HeaderText = "Jumlah";
            dgvData.Columns[3].HeaderText = "Golongan Obat";
            dgvData.Columns[4].HeaderText = "Bentuk Sediaan";
            dgvData.Columns[5].HeaderText = "Jenis Obat";
            dgvData.Columns[6].HeaderText = "Harga PBF (Rp.)";
            dgvData.Columns[7].HeaderText = "Nama PBF";
            dgvData.Columns[8].HeaderText = "Petugas Input";
            dgvData.Columns[9].HeaderText = "Tanggal Input";
            dgvData.Columns[10].HeaderText = "Tanggal Diupdate";
            dgvData.Columns[11].HeaderText = "Petugas Update";
            dgvData.Columns[0].Visible = false;

            if (!dgvData.Columns.Contains("LinkUpdate"))
            {
                DataGridViewLinkColumn linkEdit = new DataGridViewLinkColumn
                {
                    Name = "LinkUpdate",
                    HeaderText = "",
                    Text = "Edit Data",
                    UseColumnTextForLinkValue = true,
                    LinkColor = Color.Blue,
                    ActiveLinkColor = Color.Red,
                    VisitedLinkColor = Color.Purple
                };
                dgvData.Columns.Add(linkEdit);
            }
            dgvData.CellContentClick -= DgvData_CellContentClick;
            dgvData.CellContentClick += DgvData_CellContentClick;
        }

        private void UpdatePaginationControls()
        {
            btnAwal.Enabled = currentPage > 1;
            btnSebelum.Enabled = currentPage > 1;
            btnSesudah.Enabled = currentPage < totalPages;
            btnAkhir.Enabled = currentPage < totalPages;
            lblPageInfo.Text = totalPages > 0
                ? $"Halaman {currentPage} dari {totalPages}"
                : "Tidak ada data";
        }

        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int kode = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[0].Value);
            string nama_obat = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            string jumlah = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            string golongan_obat = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
            string bentuk_sediaan = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
            string jenis_obat = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            string harga_pbf = dgvData.Rows[e.RowIndex].Cells[6].Value.ToString();
            string nama_pbf = dgvData.Rows[e.RowIndex].Cells[7].Value.ToString();
            if (dgvData.Columns[e.ColumnIndex].Name == "LinkUpdate")
            {
                FormEditObat frm = new FormEditObat();
                frm.setinputData(kode, nama_obat, jumlah, golongan_obat, bentuk_sediaan, jenis_obat, harga_pbf, nama_pbf);
                frm.ShowDialog();
            }
        }

        private List<string> dataGolonganObat()
        {
            using (var conn = new Koneksi().GetConnection())
            {
                List<string> datafill = new List<string>();
                conn.Open();
                string query = @"SELECT golongan_obat FROM master_golongan_obat";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            datafill.Add(rd["golongan_obat"].ToString());
                        }
                    }
                }
                return datafill;
            }
        }

        private List<string> dataBentukSediaan()
        {
            using (var conn = new Koneksi().GetConnection())
            {
                List<string> datafill = new List<string>();
                conn.Open();
                string query = @"SELECT bentuk_sediaan FROM master_bentuk_sediaan";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            datafill.Add(rd["bentuk_sediaan"].ToString());
                        }
                    }
                }
                return datafill;
            }
        }

        private List<string> dataJenisObat()
        {
            using (var conn = new Koneksi().GetConnection())
            {
                List<string> datafill = new List<string>();
                conn.Open();
                string query = @"SELECT jenis_obat FROM master_jenis_obat";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            datafill.Add(rd["jenis_obat"].ToString());
                        }
                    }
                }
                return datafill;
            }
        }

        private void comboBox()
        {
            string filter = cmbMaster.Text;
            switch (filter)
            {
                case "Golongan Obat":
                    cmbFilter.DataSource = dataGolonganObat();
                    break;
                case "Bentuk Sediaan":
                    cmbFilter.DataSource = dataBentukSediaan();
                    break;
                case "Jenis Obat":
                    cmbFilter.DataSource = dataJenisObat();
                    break;
                default:
                    break;
            }
            cmbFilter.SelectedIndex = -1;
        }

        private void TxtCari_TextChanged(object sender, EventArgs e)
        {
            tampilData();
        }

        private void CmbEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilData();
        }

        private void FormCekStok_Load(object sender, EventArgs e)
        {
            radioAll.Checked = true;
            tampilData();
            comboBox();
        }

        private void btnAwal_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                tampilData();
            }
        }

        private void btnSebelum_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                tampilData();
            }
        }

        private void btnSesudah_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                tampilData();
            }
        }

        private void btnAkhir_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage = totalPages;
                tampilData();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnBersih_Click(object sender, EventArgs e)
        {
           
        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

        private void txtHargaPBF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

      
        private void cmbEntry_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tampilData();
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Check if the cell is in a data row
            {
                if (dgvData.Columns[e.ColumnIndex].ValueType == typeof(int) ||
                    dgvData.Columns[e.ColumnIndex].ValueType == typeof(double) ||
                    dgvData.Columns[e.ColumnIndex].ValueType == typeof(decimal))
                {
                    if (e.Value != null)
                    {
                        // Format the numeric value with thousand separators
                        e.Value = string.Format("{0:N0}", e.Value);
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = -1;
            cmbMaster.SelectedIndex = -1;
            cmbMaster.Enabled = false;
            cmbFilter.Enabled = false;
        }

        private void radioFilter_CheckedChanged(object sender, EventArgs e)
        {
            cmbMaster.Enabled = true;
            cmbFilter.Enabled = true;
        }

        private void cmbMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbMaster.Text))
            {
                comboBox();
            }
        }

        private void btnBersih_Click_1(object sender, EventArgs e)
        {
            radioAll.Checked = true;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilData();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private DataTable exportData(string filter)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    DataTable dt = new DataTable();
                    conn.Open();
                    string query = @"SELECT tr.id_trans,tr.nama_obat,tr.jumlah,tr.golongan_obat,tr.bentuk_sediaan,
                             tr.jenis_obat,tr.harga_pbf,tr.nama_pbf,op1.nama AS 'operator_input',
                             tr.created_at, op2.nama AS 'operator_edit,tr.updated_at' 
                             FROM transaksi_input_obat tr 
                             LEFT JOIN user op1 ON tr.operator=op1.username 
                             LEFT JOIN user op2 ON tr.updated_by=op2.username ";
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        query += @"WHERE tr.golongan_obat = @filter OR 
                                   tr.bentuk_sediaan = @filter OR 
                                   tr.jenis_obat = @filter ";
                        parameters.Add(new SQLiteParameter("@filter", filter));
                    }
                    query += " ORDER BY tr.nama_obat ASC";

                    using (var da = new SQLiteDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                        da.Fill(dt);
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    // Log error instead of showing directly
                    MessageBox.Show($"Error loading data: {ex.Message}");
                    return null;
                }
            }
        }

        private void excelData(DataTable data)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[1];

            object[,] header = new object[1, 12]
            {
        {
            "No.", "Nama Obat", "Jumlah", "Golongan Obat", "Bentuk Sediaan", "Jenis Obat",
            "Harga PBF (Rp.)", "Nama PBF", "Petugas Input", "Tanggal Input",
            "Petugas Edit", "Update Terakhir"
        }
            };
            xlWorkSheet.Range["A4:L4"].Value = header;

            // Load data into a 2D array for bulk processing
            object[,] dataArray = new object[data.Rows.Count, 12];
            for (int r = 0; r < data.Rows.Count; r++)
            {
                dataArray[r, 0] = r + 1;
                for (int c = 1; c < data.Columns.Count; c++)
                {
                    dataArray[r, c] = data.Rows[r][c];
                }
            }

            // Write data array to the worksheet
            xlWorkSheet.Range["A5"].Resize[data.Rows.Count, 12].Value = dataArray;

            // Formatting
            xlWorkSheet.Range["J5:J" + (data.Rows.Count + 4)].NumberFormat = "dd-mmm-yyyy";
            xlWorkSheet.Range["L5:L" + (data.Rows.Count + 4)].NumberFormat = "dd-mmm-yyyy";
            xlWorkSheet.Range["C5:C" + (data.Rows.Count + 4)].NumberFormat = "#,##0";
            xlWorkSheet.Range["G5:G" + (data.Rows.Count + 4)].NumberFormat = "#,##0";

            // Header formatting
            xlWorkSheet.Range["A1:L1"].Merge();
            xlWorkSheet.Range["A2:L2"].Merge();
            xlWorkSheet.Cells[1, 1].Value = "LAPORAN STOK OBAT";
            xlWorkSheet.Range["A1:L2"].Font.Bold = true;
            xlWorkSheet.Range["A1:L2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Cells[1, 1].Font.Size = 16;

            // Column auto-fit and header styling
            xlWorkSheet.Columns.AutoFit();
            xlWorkSheet.Range["A4:L4"].Font.Bold = true;
            xlWorkSheet.Range["A4:L4"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Range["A4:L4"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            // Borders and wrap text for content
            var dataRange = xlWorkSheet.Range["A4:L" + (data.Rows.Count + 4)];
            dataRange.WrapText = true;
            dataRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            xlApp.Visible = true;

            // Release resources
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filter = cmbFilter.Text;
            DataTable dt = exportData(filter);
            excelData(dt);
        }
    }
}
