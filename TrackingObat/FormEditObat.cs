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
    public partial class FormEditObat : Form
    {
        private int flag = 1;
        private int id;
        private int currentPage = 1;
        private int totalPages = 1;

        public FormEditObat()
        {
            InitializeComponent();
            comboBox();
        }

        public void setinputData(int id_trans,string nama_obat, string jumlah, string golongan_obat,
            string bentuk_sediaan,string jenis_obat, string harga_pbf, string nama_pbf)
        {
            id = id_trans;
            txtNamaObat.Text = nama_obat;
            txtJumlah.Text = jumlah;
            cmbGolongan.Text = golongan_obat;
            cmbSediaan.Text = bentuk_sediaan;
            cmbJenisObat.Text = jenis_obat;
            txtHargaPBF.Text = harga_pbf;
            txtNamaPBF.Text = nama_pbf;
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
                        FormCekStok frm = Application.OpenForms["FormCekStok"] as FormCekStok;
                        if (frm != null)
                        {
                            frm.tampilData();
                            Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                int kode = id;
                string nama_obat = txtNamaObat.Text;
                int jumlah = int.Parse(txtJumlah.Text.Replace(".", "").Replace(",", ""));
                string golongan_obat = cmbGolongan.Text;
                string bentuk_sediaan = cmbSediaan.Text;
                string jenis_obat = cmbJenisObat.Text;
                decimal harga = decimal.Parse(txtHargaPBF.Text.Replace(".", "").Replace(",", ""));
                string nama_pbf = txtNamaPBF.Text;
                editData(kode, nama_obat, jumlah, golongan_obat, bentuk_sediaan, jenis_obat, harga, nama_pbf);
            }
        }

        private void FormEditObat_Load(object sender, EventArgs e)
        {
            
        }
    }
}
