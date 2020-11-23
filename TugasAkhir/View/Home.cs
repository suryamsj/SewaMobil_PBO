using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasAkhir.Controller;
using TugasAkhir.Model;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TugasAkhir.View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //AMBIL BANYAK DATA MOBIL
            MySqlConnection conn = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string QueryTipeMobil = "SELECT count(*)AS Nomor FROM mobil";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(QueryTipeMobil, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                label2.Text = read.GetString("nomor") + " Mobil";
            }
            conn.Close();

            //AMBIL BANYAK DATA MOBIL READY
            MySqlConnection konn = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string QueryStatusMobil = "SELECT count(status_mobil) AS status FROM mobil WHERE status_mobil='Ready'";
            konn.Open();

            MySqlCommand kmd = new MySqlCommand(QueryStatusMobil, konn);
            MySqlDataReader baca = kmd.ExecuteReader();
            while (baca.Read())
            {
                label5.Text=baca.GetString("status") + " Mobil Ready";
            }
            konn.Close();

            //AMBIL BANYAK DATA MOBIL DIPINJAMKAN
            MySqlConnection kon = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string QueryStatusMobil1 = "SELECT count(status_mobil) AS status FROM mobil WHERE status_mobil='Dipinjamkan'";
            konn.Open();

            MySqlCommand trm = new MySqlCommand(QueryStatusMobil1, konn);
            MySqlDataReader see = trm.ExecuteReader();
            while (see.Read())
            {
                label7.Text = see.GetString("status") + " Mobil Dipinjamkan";
            }
            kon.Close();

            //AMBIL BANYAK DATA TARANSAKSI
            MySqlConnection tran = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string QueryTransaksi = "SELECT count(*)AS Transaksi FROM transaksi";
            tran.Open();

            MySqlCommand trn = new MySqlCommand(QueryTransaksi, tran);
            MySqlDataReader lorem = trn.ExecuteReader();
            while (lorem.Read())
            {
                label3.Text = lorem.GetString("transaksi") + " Total Transaksi";
            }
            tran.Close();

            //AMBIL BANYAK DATA Pelanggan
            MySqlConnection pel = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string KueriPelanggan = "SELECT count(*)AS Pelanggan FROM pelanggan";
            pel.Open();

            MySqlCommand rexus = new MySqlCommand(KueriPelanggan, pel);
            MySqlDataReader ipsum = rexus.ExecuteReader();
            while (ipsum.Read())
            {
                label9.Text = ipsum.GetString("pelanggan") + " Total Pelanggan";
            }
            pel.Close();
        }
    }
}
