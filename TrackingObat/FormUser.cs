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
    public partial class FormUser : Form
    {
        int flag = 1;
        int id_user;

        public FormUser()
        {
            InitializeComponent();
        }

        private void kosong()
        {
            txtNama.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            cmbLevel.SelectedIndex = -1;
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
                    string query = @"SELECT id_user,nama,username,password,role FROM user ORDER BY id_user ASC";
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
            dgvData.Columns[2].Width = 150;
            dgvData.Columns[4].Width = 100;

            dgvData.Columns[0].HeaderText = "ID";
            dgvData.Columns[1].HeaderText = "Nama";
            dgvData.Columns[2].HeaderText = "Username";
            dgvData.Columns[3].HeaderText = "Password";
            dgvData.Columns[4].HeaderText = "Role";
            dgvData.Columns[0].Visible = false;
            dgvData.Columns[3].Visible = false;

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
                id_user = kode;
                txtNama.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUsername.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPassword.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbLevel.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
                flag = 2;
                btnSimpan.Text = "UPDATE";
            }
            else if (dgvData.Columns[e.ColumnIndex].Name == "LinkDelete")
            {
                string message = "Apakah Anda Yakin Akan Menghapus Data Ini?";
                string title = "User";
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
                    string query = @"DELETE FROM user WHERE id_user=@id";
                    using(var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Dihapus", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void FormUser_Load(object sender, EventArgs e)
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

        private void tambahData(string nama,string username,string password,string role)
        {
            using(var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO user(nama,username,password,role) VALUES(@nama,@username,@password,
                                     @role)";
                    using(var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Disimpan", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void updateData(int id, string nama, string username, string password, string role)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE user SET nama=@nama,username=@username,password=@password,role=@role 
                                     WHERE id_user=@id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Disimpan", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int id = id_user;
            string nama = txtNama.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cmbLevel.Text;

            if (flag == 1)
            {
                tambahData(nama, username, password, role);
            }
            else if (flag == 2)
            {
                updateData(id, nama, username, password, role);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == string.Empty)
            {
                MessageBox.Show("Nama Tidak Boleh Kosong", "User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNama.Focus();
            }
            else if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Username Tidak Boleh Kosong", "User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsername.Focus();
            }
            else if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Password Tidak Boleh Kosong", "User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }
            else if (cmbLevel.Text == string.Empty)
            {
                MessageBox.Show("Role Tidak Boleh Kosong", "User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbLevel.Focus();
            }
            else
            {
                tambahEditData();
            }
        }
    }
}
