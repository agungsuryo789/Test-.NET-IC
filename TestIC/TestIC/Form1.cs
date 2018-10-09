using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace TestIC
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataServices.GetAlltabel1();
        }
        public void clear()
        {
            txtNim.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
        }
        public void DataRefresh()
        {
            dataGridView1.DataSource = DataServices.GetAlltabel1();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNim.Text == "")
                    MessageBox.Show("Error", "Name field cant be empty", MessageBoxButtons.OK);
                using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["konek"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string olequery = "INSERT INTO mahasiswa (nim, nama, alamat )  VALUES ('" + txtNim.Text + "', '" + txtNama.Text + "', '" + txtAlamat.Text + "')";
                    db.Execute(olequery);
                    db.Close();
                }
                DataRefresh();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                clear();
                txtNim.Focus();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    
                    txtNim.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtNama.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtAlamat.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["konek"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    db.Execute("UPDATE mahasiswa SET nim = @nim,nama = @nama,alamat = @alamat WHERE nim = @nim" ,new { nim = txtNim.Text,nama = txtNama.Text,alamat = txtAlamat.Text });
                    db.Close();
                }
                DataRefresh();
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
            finally
            {
                clear();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["konek"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    db.Execute("DELETE * FROM mahasiswa WHERE nim = @nim", new { nim = txtNim.Text });
                    db.Close();
                }
                DataRefresh();
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
            finally
            {
                clear();
            }
        }

        private void btnCari1_Click(object sender, EventArgs e)
        {
            int nim = Convert.ToInt32(txtNim.Text);
            try
            {
                using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["konek"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    db.Execute("SELECT * FROM mahasiswa WHERE nim = @nim", new { nim = txtNim.Text });
                    dataGridView1.DataSource = db;
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                    db.Close();
                }
                DataRefresh();
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
            finally
            {
                clear();
                txtNim.Text = null;
            }
        }

        private void btnCari2_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["konek"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    db.Execute("SELECT * FROM mahasiswa WHERE nama = @nama", new { nama = txtNama.Text });
                    dataGridView1.DataSource = db;
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                    db.Close();
                }
                DataRefresh();
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
            finally
            {
                clear();
            }
        }
    }
}
