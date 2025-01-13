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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //cek data username untuk login apakah ada di database
        private int cekLogin(string username,string password)
        {
            using(var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT COUNT(1) FROM user WHERE username=@username AND password=@password";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        //login user
        private void login()
        {
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Username Tidak Boleh Kosong","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtUsername.Focus();
            }
            else if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Password Tidak Boleh Kosong", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }
            else
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                int cek_login = cekLogin(username, password);
                if (cek_login == 1)
                {
                    Hide();
                    FormMenuUtama.username = username;
                    FormMenuUtama.password = password;
                    FormMenuUtama frm = new FormMenuUtama();
                    frm.ShowDialog();
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                else if (cek_login == 0)
                {
                    MessageBox.Show("Username atau Password Salah", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender,KeyPressEventArgs e)
        {
          
        }

        private void txtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                login();
            }
        }
    }
}
