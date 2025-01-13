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

namespace TrackingObat
{
    public partial class FormJenisObat : Form
    {
        int flag = 1;
        int id;

        public FormJenisObat()
        {
            InitializeComponent();
        }

        private void kosong()
        {
            txtJenisObat.Clear();
            btnSimpan.Text = "SIMPAN";
            flag = 1;
        }

        private DataTable tampilData()
        {
            DataTable dt = new DataTable();

            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT id_jenis,jenis_obat,created_at,created_by,edited_at,edited_by 
                                     FROM master_jenis_obat ORDER BY id_jenis ASC";
                    using (var da = new SQLiteDataAdapter(query, conn))
                    {
                        da.Fill(dt);
                    }
                    return dt;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
               
            }
        }


        private void dataGrid()
        {
            dgvData.Columns.Clear();
            dgvData.DataSource = null;
            dgvData.DataSource = tampilData();
            DGVProperties.dgvProperties(dgvData);

            dgvData.Columns[1].Width = 150;
            dgvData.Columns[2].Width = 100;
            dgvData.Columns[3].Width = 100;
            dgvData.Columns[4].Width = 100;
            dgvData.Columns[5].Width = 100;
            dgvData.Columns[0].HeaderText = "ID";
            dgvData.Columns[1].HeaderText = "Jenis Obat";
            dgvData.Columns[2].HeaderText = "Tanggal Diinput";
            dgvData.Columns[3].HeaderText = "Diinput Oleh";
            dgvData.Columns[4].HeaderText = "Tanggal Diupdate";
            dgvData.Columns[5].HeaderText = "Diupdate Oleh";
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
            if (!dgvData.Columns.Contains("LinkDelete"))
            {
                DataGridViewLinkColumn linkHapus = new DataGridViewLinkColumn
                {
                    Name = "LinkDelete",
                    HeaderText = "",
                    Text = "Hapus Data",
                    UseColumnTextForLinkValue = true,
                    LinkColor = Color.Blue,
                    ActiveLinkColor = Color.Red,
                    VisitedLinkColor = Color.Purple
                };
                dgvData.Columns.Add(linkHapus);
            }
            dgvData.CellContentClick -= DgvData_CellContentClick;
            dgvData.CellContentClick += DgvData_CellContentClick;
        }

        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int kode = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[0].Value);
            if (dgvData.Columns[e.ColumnIndex].Name == "LinkUpdate")
            {
                id = kode;
                txtJenisObat.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                flag = 2;
                btnSimpan.Text = "UPDATE";
            }
            else if (dgvData.Columns[e.ColumnIndex].Name == "LinkDelete")
            {
                string message = "Apakah Anda Yakin Akan Menghapus Data Ini?";
                string title = "Jenis Obat";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Exclamation;
                DialogResult result = MessageBox.Show(message, title, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    hapusData(kode);
                    
                }
            }
        }

        private void hapusData(int id)
        {
            using(var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"DELETE FROM master_jenis_obat WHERE id_jenis=@id";
                    using(var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Dihapus", "Jenis Obat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kosong();
                        dataGrid();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
           
                }
            }
        }
        private void FormJenisObat_Load(object sender, EventArgs e)
        {
            dataGrid();
        }

        private void btnBersih_Click(object sender, EventArgs e)
        {
            kosong();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tambahData(string jenis_obat)
        {
            using(var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO master_jenis_obat(jenis_obat,created_at,created_by) 
                                     VALUES(@jenis_obat,@tanggal,@user)";
                    using(var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jenis_obat", jenis_obat);
                        cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        cmd.Parameters.AddWithValue("@user", FormMenuUtama.username);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Disimpan", "Jenis Obat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kosong();
                        dataGrid();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updateData(int id, string jenis_obat)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE master_jenis_obat SET jenis_obat=@jenis_obat,edited_at=@tanggal,
                                     edited_by=@user WHERE id_jenis=@id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jenis_obat", jenis_obat);
                        cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        cmd.Parameters.AddWithValue("@user", FormMenuUtama.username);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Disimpan", "Jenis Obat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kosong();
                        dataGrid();
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
            string golongan = txtJenisObat.Text;
            if (flag == 1)
            {
                tambahData(golongan);
            }
            else if (flag == 2)
            {
                updateData(kode, golongan);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtJenisObat.Text == string.Empty)
            {
                MessageBox.Show("Jenis Obat Tidak Boleh Kosong", "Jenis Obat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtJenisObat.Focus();
            }
          
            else
            {
                tambahEditData();
            }
        }
    }
}
