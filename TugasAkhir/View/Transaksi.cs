using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasAkhir.Controller;
using TugasAkhir.Model;

namespace TugasAkhir.View
{
    public partial class Transaksi : Form
    {
        public Transaksi()
        {
            InitializeComponent();
        }
        TransaksiDAO UD = new TransaksiDAO();
        string id_transaksi;
        public void TampilSemua()
        {
            DataSet transaksi = UD.Getall();
            DataGridTransaksi.DataSource = transaksi;
            DataGridTransaksi.DataMember = "transaksi";

            //FORMAT GRID
            DataGridTransaksi.Columns[0].HeaderText = "ID Transaksi";
            DataGridTransaksi.Columns[1].HeaderText = "ID Pelanggan";
            DataGridTransaksi.Columns[2].HeaderText = "ID Mobil";

            DataGridTransaksi.Columns[3].HeaderText = "Tanggal Sewa";
            DataGridTransaksi.Columns[3].DefaultCellStyle.Format = "dddd, MMM dd, yyyy";

            DataGridTransaksi.Columns[4].HeaderText = "Tanggal Kembali";
            DataGridTransaksi.Columns[4].DefaultCellStyle.Format = "dddd, MMM dd, yyyy";

            DataGridTransaksi.Columns[5].HeaderText = "Harga Sewa";
            DataGridTransaksi.Columns[5].DefaultCellStyle.Format = "Rp " + " #,###0.00;($#,###0.00);0";

            DataGridTransaksi.Columns[6].HeaderText = "Status";
        }
        private void Transaksi_Load(object sender, EventArgs e)
        {
            TampilSemua();

            //AMBIL Pelanggan
            MySqlConnection conn = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string KueriPelanggan = "SELECT id_pelanggan FROM pelanggan";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(KueriPelanggan, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                IDPelanggan.Items.Add(read.GetString("id_pelanggan"));
            }
            conn.Close();

            //AMBIL Pelanggan
            MySqlConnection kon = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string KueriMobil = "SELECT id_mobil FROM mobil";
            kon.Open();

            MySqlCommand terminal = new MySqlCommand(KueriMobil, kon);
            MySqlDataReader baca = terminal.ExecuteReader();
            while (baca.Read())
            {
                MerekMobil.Items.Add(baca.GetString("id_mobil"));
            }
            kon.Close();
        }
        private void DataGridTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Status.Enabled = true;
            IDPelanggan.Text = DataGridTransaksi.Rows[e.RowIndex].Cells[1].Value.ToString();
            MerekMobil.Text = DataGridTransaksi.Rows[e.RowIndex].Cells[2].Value.ToString();
            TanggalSewa.Text = DataGridTransaksi.Rows[e.RowIndex].Cells[3].Value.ToString();
            TanggalKembali.Text = DataGridTransaksi.Rows[e.RowIndex].Cells[4].Value.ToString();
            HargaMobil.Text = DataGridTransaksi.Rows[e.RowIndex].Cells[5].Value.ToString();
            Status.Text = DataGridTransaksi.Rows[e.RowIndex].Cells[6].Value.ToString();

            id_transaksi = IDPelanggan.Text = DataGridTransaksi.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void TombolTambah_Click(object sender, EventArgs e)
        {
            Model.Transaksi baru = new Model.Transaksi();

            //AMBIL NILAI HARGA
            MySqlConnection Server = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string KueriHarga = "SELECT harga FROM mobil WHERE id_mobil='" + MerekMobil.Text + "'";
            Server.Open();

            MySqlCommand termux = new MySqlCommand(KueriHarga, Server);
            MySqlDataReader eja = termux.ExecuteReader();
            while (eja.Read())
            {
                HargaMobil.Text = eja.GetString("harga");
            }
            Server.Close();

            //MASUK DB
            baru.Id_pelanggan = IDPelanggan.Text;
            baru.Mobil = MerekMobil.Text;
            baru.Tgl_sewa = TanggalSewa.Value.ToString("yyyy/MM/dd");
            baru.Tgl_kembali = TanggalKembali.Value.ToString("yyyy/MM/dd");
            baru.Harga = Convert.ToString((TanggalKembali.Value - TanggalSewa.Value).TotalDays * Double.Parse(HargaMobil.Text));
            baru.Status = "Sewa";

            UD.InsertData(baru);
            IDPelanggan.Text = null;
            MerekMobil.Text = null;
            HargaMobil.Text = "";
            Status.Text = "";
            TampilSemua();
        }
        private void TombolEdit_Click(object sender, EventArgs e)
        {
            Model.Transaksi baru = new Model.Transaksi();

            //AMBIL NILAI HARGA
            MySqlConnection Server = new MySqlConnection("server=localhost;database=geekrental;uid=root;pwd='';");
            string KueriHarga = "SELECT harga FROM mobil WHERE id_mobil='" + MerekMobil.Text + "'";
            Server.Open();

            MySqlCommand termux = new MySqlCommand(KueriHarga, Server);
            MySqlDataReader eja = termux.ExecuteReader();
            while (eja.Read())
            {
                HargaMobil.Text = eja.GetString("harga");
            }
            Server.Close();

            baru.Id_pelanggan = IDPelanggan.Text;
            baru.Mobil = MerekMobil.Text;
            baru.Tgl_sewa = TanggalSewa.Value.ToString("yyyy/MM/dd");
            baru.Tgl_kembali = TanggalKembali.Value.ToString("yyyy/MM/dd");
            baru.Harga = Convert.ToString((TanggalKembali.Value - TanggalSewa.Value).TotalDays * Double.Parse(HargaMobil.Text));
            baru.Status = Status.Text;

            UD.UpdateData(baru, id_transaksi);
            TampilSemua();
        }
        private void TombolHapus_Click(object sender, EventArgs e)
        {
            DialogResult tampilpesan = MessageBox.Show("Yakin mau hapus data ini?", "Delete Mobil", MessageBoxButtons.YesNo);
            if (tampilpesan == DialogResult.Yes)
            {
                //hapus data
                UD.DeleteData(id_transaksi);
                TampilSemua();
            }
            else if (tampilpesan == DialogResult.No)
            {
                //do something
            }
        }
        private void TombolReset_Click(object sender, EventArgs e)
        {
            IDPelanggan.Text = "";
            MerekMobil.Text = "";
            HargaMobil.Text = "";
        }

        private void DataMobil_Click(object sender, EventArgs e)
        {
            View.CumaDataMobil fd = new View.CumaDataMobil();
            fd.Show();
        }

        private void DataPelanggan_Click(object sender, EventArgs e)
        {
            View.CumaDataPelanggan df = new View.CumaDataPelanggan();
            df.Show();
        }
    }
}
