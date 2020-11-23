using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasAkhir.Model;
using TugasAkhir.Controller;
using MySql.Data.MySqlClient;
using TugasAkhir.View;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace TugasAkhir.UI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private bool DropDown;

        public void panel(object formtampil)
        {
            if(this.guna2Panel2.Controls.Count > 0)
            {
                this.guna2Panel2.Controls.RemoveAt(0);
                Form fh = formtampil as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.guna2Panel2.Controls.Add(fh);
                this.guna2Panel2.Tag = fh;
                fh.Show();
            }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void TombolDataMobil_Click(object sender, EventArgs e)
        {
            DataMobil.ActiveForm.Hide();
            this.guna2Panel2.Show();
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
           //KEKLICK
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DropDown)
            {
                MobilDropdown.Height += 10;
                if (MobilDropdown.Size == MobilDropdown.MaximumSize)
                {
                    timer1.Stop();
                    DropDown = false;
                }
            }
            else
            {
                MobilDropdown.Height -= 10;
                if (MobilDropdown.Size == MobilDropdown.MinimumSize)
                {
                    timer1.Stop();
                    DropDown = true;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void TombolDataMobil_Click_2(object sender, EventArgs e)
        {
            panel(new DataMobil());
            LabelMenu.Text = "Sewa Mobil - Data Mobil";
        }

        private void TombolTipeMobil_Click(object sender, EventArgs e)
        {
            panel(new View.TipeMobil());
            LabelMenu.Text = "Sewa Mobil - Data Tipe Mobil";
        }

        private void TombolHome_Click(object sender, EventArgs e)
        {
            panel(new Home());
            LabelMenu.Text = "Sewa Mobil - Dashboard";
        }

        private void DataPelanggan_Click(object sender, EventArgs e)
        {
            panel(new Costumers());
            LabelMenu.Text = "Sewa Mobil - Data Pelanggan";
        }

        private void TombolTransaksi_Click(object sender, EventArgs e)
        {
            panel(new View.Transaksi());
            LabelMenu.Text = "Sewa Mobil - Data Transaksi";
        }

        private void TombolExit_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
