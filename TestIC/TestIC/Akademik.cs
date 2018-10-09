using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;

namespace TestIC
{
    public class mahasiswa
    {
        public string nim { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
    }
}
