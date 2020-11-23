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

namespace TugasAkhir.View
{
    public partial class CumaDataPelanggan : Form
    {
        public CumaDataPelanggan()
        {
            InitializeComponent();
        }
        PelangganDAO UD = new PelangganDAO();
        void TampilSemua()
        {
            DataSet pelanggan = UD.Getall();
            DataGridPelanggan.DataSource = pelanggan;
            DataGridPelanggan.DataMember = "pelanggan";
        }
        private void CumaDataPelanggan_Load(object sender, EventArgs e)
        {
            TampilSemua();
            DataGridPelanggan.Columns[0].HeaderText = "ID Pelanggan";
            DataGridPelanggan.Columns[1].HeaderText = "Nama Pelanggan";
            DataGridPelanggan.Columns[2].HeaderText = "Alamat";
            DataGridPelanggan.Columns[3].HeaderText = "NO KTP";
            DataGridPelanggan.Columns[4].HeaderText = "NO HP";
        }
    }
}
