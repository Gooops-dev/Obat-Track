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
    public partial class FormMenuUtama : Form
    {
        public static string username;
        public static string password;

        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void getNama()
        {
            using(var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT nama,role FROM user WHERE username=@username AND password=@password";
                    using(var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        using(SQLiteDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                string nama = rd["nama"].ToString();
                                string role = rd["role"].ToString();
                                tsNama.Text = $"Selamat Datang, {nama}";
                                if (role == "Superuser")
                                {
                                    userToolStripMenuItem.Enabled = true;
                                }
                                else
                                {
                                    userToolStripMenuItem.Enabled = false;
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FormMenuUtama_Load(object sender, EventArgs e)
        {
            getNama();
        }

        private void FormMenuUtama_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            FormLogin frm = new FormLogin();
            frm.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tsJam.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUser frm = new FormUser();
            frm.ShowDialog();
        }

        private void golonganObatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGolonganObat frm = new FormGolonganObat();
            frm.ShowDialog();
        }

        private void bentukSediaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBentukSediaan frm = new FormBentukSediaan();
            frm.ShowDialog();
        }

        private void jenisObatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJenisObat frm = new FormJenisObat();
            frm.ShowDialog();
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputObat frm = new FormInputObat();
            frm.ShowDialog();
        }

        private void cekStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCekStok frm = new FormCekStok();
            frm.ShowDialog();
        }
    }
}
