using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TrackingObat
{
    class DGVProperties
    {
        public static void dgvProperties(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.LightGray;

            // Set the column header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Arial Rounded MT", 8);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calisto MT", 9, FontStyle.Bold);

            // Set the row style
            dgv.DefaultCellStyle.BackColor = Color.Beige;
            dgv.DefaultCellStyle.ForeColor = Color.Black;

            // Set alternating row style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // Set selection style
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set the grid color
            dgv.GridColor = Color.Black;

            // Set the row header style
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgv.RowHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
