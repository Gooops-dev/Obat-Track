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

namespace TrackingObat
{
    public partial class FormInputObat : Form
    {
        private int flag = 1;
        private int id;
        private int currentPage = 1;
        private int totalPages = 1;

        public FormInputObat()
        {
            InitializeComponent();
            cmbEntry.Text = "10";
            cmbEntry.SelectedIndexChanged += CmbEntry_SelectedIndexChanged;
            txtCari.TextChanged += TxtCari_TextChanged;
        }

        private void kosong()
        {
            txtNamaObat.Clear();
            txtJumlah.Clear();
            cmbGolongan.SelectedIndex = -1;
            cmbSediaan.SelectedIndex = -1;
            cmbJenisObat.SelectedIndex = -1;
            txtHargaPBF.Clear();
            txtNamaPBF.Clear();
            btnSimpan.Text = "SIMPAN";
            flag = 1;
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
                        query += "WHERE tr.nama_obat LIKE @filter ";
                        parameters.Add(new SQLiteParameter("@filter", $"%{filter}%"));
                    }
                    int offset = (page - 1) * size;
                    query += " ORDER BY tr.id_trans DESC LIMIT @pageSize OFFSET @offset";
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

        private void tampilData()
        {
            dgvData.Columns.Clear();
            dgvData.DataSource = null;
            string cari = "";
            int pageSize = int.Parse(cmbEntry.Text);
            if (txtCari.Text != string.Empty)
            {
                cari = txtCari.Text;
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
            if (dgvData.Columns[e.ColumnIndex].Name == "LinkUpdate")
            {
                id = kode;
                txtNamaObat.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtJumlah.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbGolongan.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbSediaan.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbJenisObat.Text = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtHargaPBF.Text = dgvData.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtNamaPBF.Text = dgvData.Rows[e.RowIndex].Cells[7].Value.ToString();
                flag = 2;
                btnSimpan.Text = "UPDATE";
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
            cmbGolongan.DataSource = null;
            cmbJenisObat.DataSource = null;
            cmbSediaan.DataSource = null;
            cmbGolongan.DataSource = dataGolonganObat();
            cmbSediaan.DataSource = dataBentukSediaan();
            cmbJenisObat.DataSource = dataJenisObat();
            cmbGolongan.SelectedIndex = -1;
            cmbSediaan.SelectedIndex = -1;
            cmbJenisObat.SelectedIndex = -1;
        }

        private void TxtCari_TextChanged(object sender, EventArgs e)
        {
            tampilData();
        }

        private void CmbEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilData();
        }

        private void FormInputObat_Load(object sender, EventArgs e)
        {
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
            kosong();
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

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            string text = txtJumlah.Text.Replace(".", "").Replace(",", ""); // Remove both separators for safety
            decimal number = 0;
            if (decimal.TryParse(text, out number))
            {
                // Create a custom number format info
                var numberFormat = new NumberFormatInfo
                {
                    NumberGroupSeparator = ".", // Set period as the thousand separator
                    NumberDecimalSeparator = "," // Optional: Use comma as decimal separator
                };

                // Apply formatting with the custom format
                txtJumlah.Text = number.ToString("N0", numberFormat);

                // Set caret position at the end
                txtJumlah.SelectionStart = txtJumlah.Text.Length;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                // Clear invalid input
                txtJumlah.Text = "";
            }
        }

        private void txtHargaPBF_TextChanged(object sender, EventArgs e)
        {
            string text = txtHargaPBF.Text.Replace(".", "").Replace(",", ""); // Remove both separators for safety
            decimal number = 0;
            if (decimal.TryParse(text, out number))
            {
                // Create a custom number format info
                var numberFormat = new NumberFormatInfo
                {
                    NumberGroupSeparator = ".", // Set period as the thousand separator
                    NumberDecimalSeparator = "," // Optional: Use comma as decimal separator
                };

                // Apply formatting with the custom format
                txtHargaPBF.Text = number.ToString("N0", numberFormat);

                // Set caret position at the end
                txtHargaPBF.SelectionStart = txtHargaPBF.Text.Length;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                // Clear invalid input
                txtHargaPBF.Text = "";
            }


        }

        private void tambahData(string nama_obat,int jumlah,string golongan_obat,string bentuk_sediaan,
            string jenis_obat,decimal harga_pbf,string nama_pbf)
        {
            using(var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO transaksi_input_obat(nama_obat,jumlah,golongan_obat,
                                     bentuk_sediaan,jenis_obat,harga_pbf,nama_pbf,operator,created_at) 
                                     VALUES(@nama_obat,@jumlah,@golongan_obat,@bentuk_sediaan,@jenis_obat,
                                     @harga,@nama_pbf,@user,@tanggal)";
                    using(var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama_obat", nama_obat);
                        cmd.Parameters.AddWithValue("@jumlah", jumlah);
                        cmd.Parameters.AddWithValue("@golongan_obat", golongan_obat);
                        cmd.Parameters.AddWithValue("@bentuk_sediaan", bentuk_sediaan);
                        cmd.Parameters.AddWithValue("@jenis_obat", jenis_obat);
                        cmd.Parameters.AddWithValue("@harga", harga_pbf);
                        cmd.Parameters.AddWithValue("@nama_pbf", nama_pbf);
                        cmd.Parameters.AddWithValue("@user", FormMenuUtama.username);
                        cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Ditambah", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kosong();
                        tampilData();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editData(int id, string nama_obat, int jumlah, string golongan_obat, string bentuk_sediaan,
            string jenis_obat, decimal harga_pbf, string nama_pbf)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE transaksi_input_obat SET nama_obat=@nama_obat,jumlah=@jumlah,
                                     golongan_obat=@golongan_obat,bentuk_sediaan=@bentuk_sediaan,
                                     jenis_obat=@jenis_obat,harga_pbf=@harga,nama_pbf=@nama_pbf,
                                     updated_at=@tanggal,updated_by=@user WHERE id_trans=@id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama_obat", nama_obat);
                        cmd.Parameters.AddWithValue("@jumlah", jumlah);
                        cmd.Parameters.AddWithValue("@golongan_obat", golongan_obat);
                        cmd.Parameters.AddWithValue("@bentuk_sediaan", bentuk_sediaan);
                        cmd.Parameters.AddWithValue("@jenis_obat", jenis_obat);
                        cmd.Parameters.AddWithValue("@harga", harga_pbf);
                        cmd.Parameters.AddWithValue("@nama_pbf", nama_pbf);
                        cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@user", FormMenuUtama.username);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Diedit", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kosong();
                        tampilData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tambahEditData()
        {
            int kode = id;
            string nama_obat = txtNamaObat.Text;
            int jumlah = int.Parse(txtJumlah.Text.Replace(".","").Replace(",",""));
            string golongan_obat = cmbGolongan.Text;
            string bentuk_sediaan = cmbSediaan.Text;
            string jenis_obat = cmbJenisObat.Text;
            decimal harga = decimal.Parse(txtHargaPBF.Text.Replace(".", "").Replace(",", ""));
            string nama_pbf = txtNamaPBF.Text;
            if (flag == 1)
            {
                tambahData(nama_obat,jumlah,golongan_obat,bentuk_sediaan,jenis_obat,harga,nama_pbf);
            }
            else if (flag == 2)
            {
                editData(kode, nama_obat, jumlah, golongan_obat, bentuk_sediaan, jenis_obat, harga, nama_pbf);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaObat.Text))
            {
                MessageBox.Show("Nama Obat Tidak Boleh Kosong", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNamaObat.Focus();
            }
            else if (string.IsNullOrEmpty(txtJumlah.Text) || txtJumlah.Text=="0")
            {
                MessageBox.Show("Jumlah Tidak Boleh Kosong", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtJumlah.Focus();
            }
            else if (string.IsNullOrEmpty(cmbGolongan.Text))
            {
                MessageBox.Show("Golongan Obat Tidak Boleh Kosong", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbGolongan.Focus();
            }
            else if (string.IsNullOrEmpty(cmbJenisObat.Text))
            {
                MessageBox.Show("Jenis Obat Tidak Boleh Kosong", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbJenisObat.Focus();
            }
            else if (string.IsNullOrEmpty(cmbSediaan.Text))
            {
                MessageBox.Show("Bentuk Sediaan Tidak Boleh Kosong", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbSediaan.Focus();
            }
            else if (string.IsNullOrEmpty(txtHargaPBF.Text) || txtHargaPBF.Text == "0")
            {
                MessageBox.Show("Harga PBF Tidak Boleh Kosong", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtHargaPBF.Focus();
            }
            else if (string.IsNullOrEmpty(txtNamaPBF.Text))
            {
                MessageBox.Show("Nama PBF Tidak Boleh Kosong", "Input Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNamaPBF.Focus();
            }
            else
            {
                tambahEditData();
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
    }
}
