using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TrackingObat
{
    class Koneksi
    {
        private const string conn_string = @"Data Source=db_tracking_obat.db;Version=3;";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(conn_string);
        }
    }
}
