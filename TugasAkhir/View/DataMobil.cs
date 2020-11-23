using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using TugasAkhir.Controller;
using TugasAkhir.Model;

namespace TugasAkhir.View
{
    public partial class DataMobil : Form
    {
        
        public DataMobil()
        {
            InitializeComponent();
        }
        MobilDAO UD = new MobilDAO();
        string id_mobil;
        void TampilSemua()
        {
            DataSet mobil = UD.Getall();
            DataGridMobil.DataSource = mobil;
            DataGridMobil.DataMember = "mobil";
        }

        private void DataMobil_Load(object sender, EventArgs e)
        {
            TampilSemua();

            //AMBIL TIPE MOBIL
            MySqlConnection conn = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string QueryTipeMobil = "SELECT * FROM tipemobil";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(QueryTipeMobil, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListTipeMobil.Items.Add(read.GetString("tipe"));
            }
            conn.Close();

            //AMBIL STATUS MOBIL
            MySqlConnection konn = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string QueryStatusMobil = "SELECT * FROM statusmobil";
            konn.Open();

            MySqlCommand kmd = new MySqlCommand(QueryStatusMobil, konn);
            MySqlDataReader baca = kmd.ExecuteReader();
            while (baca.Read())
            {
                StatusMobil.Items.Add(baca.GetString("nm_status"));
            }
            konn.Close();

            //FORMAT GRID
            DataGridMobil.Columns[0].HeaderText = "ID Mobil";
            DataGridMobil.Columns[1].HeaderText = "Tipe Mobil";
            DataGridMobil.Columns[2].HeaderText = "Merek Mobil";
            DataGridMobil.Columns[3].HeaderText = "Plat Nomor";
            DataGridMobil.Columns[4].HeaderText = "Tahun";
            DataGridMobil.Columns[5].HeaderText = "Status";
            DataGridMobil.Columns[6].HeaderText = "Harga Sewa";
            DataGridMobil.Columns[6].DefaultCellStyle.Format = "Rp " + " #,###0.00;($#,###0.00);0";  
        }

        private void TombolReset_Click(object sender, EventArgs e)
        {
            MerekMobil.Text = "";
            PlatNomor.Text = "";
            TahunPembuatan.Text = "";
            HargaMobil.Text = "";
        }

        private void TombolTambah_Click(object sender, EventArgs e)
        {
            Mobil baru = new Mobil();
            baru.Tipe = ListTipeMobil.Text;
            baru.Merek = MerekMobil.Text;
            baru.No_plat = PlatNomor.Text;
            baru.Thn_pembuatan = TahunPembuatan.Text;
            baru.Status = StatusMobil.Text;
            baru.Harga = HargaMobil.Text;

            UD.InsertData(baru);
            MerekMobil.Text = "";
            PlatNomor.Text = "";
            TahunPembuatan.Text = "";
            HargaMobil.Text = "";
            TampilSemua();
        }

        private void TombolHapus_Click(object sender, EventArgs e)
        {
            DialogResult tampilpesan = MessageBox.Show("Yakin mau hapus data ini?", "Delete Mobil", MessageBoxButtons.YesNo);
            if (tampilpesan == DialogResult.Yes)
            {
                //hapus data
                UD.DeleteData(id_mobil);
                TampilSemua();
            }
            else if (tampilpesan == DialogResult.No)
            {
                //do something
            }
        }

        private void DataGridMobil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SALAH PEMILIHAN
        }

        private void TombolEdit_Click(object sender, EventArgs e)
        {
            Mobil baru = new Mobil();
            baru.Tipe = ListTipeMobil.Text;
            baru.Merek = MerekMobil.Text;
            baru.No_plat = PlatNomor.Text;
            baru.Thn_pembuatan = TahunPembuatan.Text;
            baru.Status = StatusMobil.Text;
            baru.Harga = HargaMobil.Text;
            UD.UpdateData(baru, id_mobil);
            TampilSemua();
        }

        private void DataGridMobil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ListTipeMobil.Text = DataGridMobil.Rows[e.RowIndex].Cells[1].Value.ToString();
            MerekMobil.Text = DataGridMobil.Rows[e.RowIndex].Cells[2].Value.ToString();
            PlatNomor.Text = DataGridMobil.Rows[e.RowIndex].Cells[3].Value.ToString();
            TahunPembuatan.Text = DataGridMobil.Rows[e.RowIndex].Cells[4].Value.ToString();
            StatusMobil.Text = DataGridMobil.Rows[e.RowIndex].Cells[5].Value.ToString();
            HargaMobil.Text = DataGridMobil.Rows[e.RowIndex].Cells[6].Value.ToString();

            id_mobil = DataGridMobil.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
