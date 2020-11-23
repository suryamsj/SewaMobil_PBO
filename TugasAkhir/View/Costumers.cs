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
    public partial class Costumers : Form
    {
        public Costumers()
        {
            InitializeComponent();
        }
        PelangganDAO UD = new PelangganDAO();
        string id_pelanggan;
        void TampilSemua()
        {
            DataSet pelanggan = UD.Getall();
            DataGridPelanggan.DataSource = pelanggan;
            DataGridPelanggan.DataMember = "pelanggan";
        }

        private void Costumers_Load(object sender, EventArgs e)
        {
            TampilSemua();

            DataGridPelanggan.Columns[0].HeaderText = "ID Pelanggan";
            DataGridPelanggan.Columns[1].HeaderText = "Nama Pelanggan";
            DataGridPelanggan.Columns[2].HeaderText = "Alamat";
            DataGridPelanggan.Columns[3].HeaderText = "NO KTP";
            DataGridPelanggan.Columns[4].HeaderText = "NO HP";
        }

        private void TombolReset_Click(object sender, EventArgs e)
        {
            NamaPelanggan.Text = "";
            Alamat.Text = "";
            NomorKTP.Text = "";
            NomorHP.Text = "";
        }

        private void TombolTambah_Click(object sender, EventArgs e)
        {
            Pelanggan baru = new Pelanggan();
            baru.Nama = NamaPelanggan.Text;
            baru.Alamat = Alamat.Text;
            baru.No_ktp = NomorKTP.Text;
            baru.No_hp = NomorHP.Text;

            UD.InsertData(baru);
            NamaPelanggan.Text = "";
            Alamat.Text = "";
            NomorKTP.Text = "";
            NomorHP.Text = "";
            TampilSemua();
        }

        private void TombolHapus_Click(object sender, EventArgs e)
        {
            DialogResult tampilpesan = MessageBox.Show("Yakin mau hapus data ini?", "Delete Mobil", MessageBoxButtons.YesNo);
            if (tampilpesan == DialogResult.Yes)
            {
                //hapus data
                UD.DeleteData(id_pelanggan);
                TampilSemua();
            }
            else if (tampilpesan == DialogResult.No)
            {
                //do something
            }
        }

        private void TombolEdit_Click(object sender, EventArgs e)
        {
            Pelanggan baru = new Pelanggan();
            baru.Nama = NamaPelanggan.Text;
            baru.Alamat = Alamat.Text;
            baru.No_ktp = NomorKTP.Text;
            baru.No_hp = NomorHP.Text;

            UD.UpdateData(baru, id_pelanggan);
            TampilSemua();
        }

        private void DataGridPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NamaPelanggan.Text = DataGridPelanggan.Rows[e.RowIndex].Cells[1].Value.ToString();
            Alamat.Text = DataGridPelanggan.Rows[e.RowIndex].Cells[2].Value.ToString();
            NomorKTP.Text = DataGridPelanggan.Rows[e.RowIndex].Cells[3].Value.ToString();
            NomorHP.Text = DataGridPelanggan.Rows[e.RowIndex].Cells[4].Value.ToString();

            id_pelanggan = DataGridPelanggan.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
