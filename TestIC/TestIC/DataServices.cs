using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Dapper;
using System.Configuration;

namespace TestIC
{
    public static class DataServices
    {
        public static List<mahasiswa> GetAlltabel1()
        {
            string proc1 = "SELECT * FROM mahasiswa";
            using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["konek"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<mahasiswa>(proc1).ToList();
            }
        }
    }
}
