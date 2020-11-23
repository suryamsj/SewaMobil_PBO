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
    public partial class TipeMobil : Form
    {
        public TipeMobil()
        {
            InitializeComponent();
        }
        TipeMobilDAO UD = new TipeMobilDAO();
        StatusMobilDAO ID = new StatusMobilDAO();
        string id_tipe;
        //string id_status;
        void TampilTipe()
        {
            DataSet tipemobil = UD.Getall();
            DataGridTipeMobil.DataSource = tipemobil;
            DataGridTipeMobil.DataMember = "tipemobil";
        }

        private void TipeMobil_Load(object sender, EventArgs e)
        {
            TampilTipe();
            DataGridTipeMobil.Columns[0].HeaderText = "ID Tipe Mobil";
            DataGridTipeMobil.Columns[1].HeaderText = "Tipe Mobil";
        }

        private void TambahTipe_Click(object sender, EventArgs e)
        {
            Model.TipeMobil tipemobil = new Model.TipeMobil();
            tipemobil.Tipe_mobil = TipeMobilBox.Text;

            UD.InsertData(tipemobil);
            TipeMobilBox.Text = "";
            TampilTipe();
        }

        private void EditTipe_Click(object sender, EventArgs e)
        {
            Model.TipeMobil tipemobil = new Model.TipeMobil();
            tipemobil.Tipe_mobil = TipeMobilBox.Text;
            UD.UpdateData(tipemobil, id_tipe);
            TampilTipe();
        }

        private void DeleteTipe_Click(object sender, EventArgs e)
        {
            DialogResult tampilpesan = MessageBox.Show("Yakin mau hapus data ini?", "Delete Mobil", MessageBoxButtons.YesNo);
            if (tampilpesan == DialogResult.Yes)
            {
                //hapus data
                UD.DeleteData(id_tipe);
                TampilTipe();
            }
            else if (tampilpesan == DialogResult.No)
            {
                //do something
            }
        }

        private void ResetTipe_Click(object sender, EventArgs e)
        {
            TipeMobilBox.Text = "";
        }

        private void DataGridTipeMobil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TipeMobilBox.Text = DataGridTipeMobil.Rows[e.RowIndex].Cells[1].Value.ToString();

            id_tipe = DataGridTipeMobil.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
