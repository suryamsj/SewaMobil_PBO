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
    public partial class CumaDataMobil : Form
    {
        public CumaDataMobil()
        {
            InitializeComponent();
        }
        MobilDAO UD = new MobilDAO();
        void TampilSemua()
        {
            DataSet mobil = UD.JustReady();
            DataGridMobil.DataSource = mobil;
            DataGridMobil.DataMember = "mobil";
        }

        private void CumaDataMobil_Load(object sender, EventArgs e)
        {
            TampilSemua();

            //FORMAT GRID
            DataGridMobil.Columns[0].HeaderText = "ID Mobil";
            DataGridMobil.Columns[1].HeaderText = "Tipe Mobil";
            DataGridMobil.Columns[2].HeaderText = "Merek Mobil";
            DataGridMobil.Columns[3].HeaderText = "Status";
            DataGridMobil.Columns[4].HeaderText = "Harga Sewa";
            DataGridMobil.Columns[4].DefaultCellStyle.Format = "Rp " + " #,###0.00;($#,###0.00);0";
        }
    }
}
