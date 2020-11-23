using Microsoft.VisualBasic.ApplicationServices;
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
using TugasAkhir.UI;
using TugasAkhir.View;

namespace TugasAkhir
{
    public partial class Login : Form
    {
        CekLogin cek = new CekLogin();
        private MySqlConnection terhubung = new MySqlConnection();

        public Login()
        {
            InitializeComponent();
        }

        public static object Properties { get; private set; }
        public void Notif(string pesan, Alert.alertTypeEnum type)
        {
            Alert f = new Alert();
            f.setAlert(pesan, type);
        }
        private void TombolLogin_Click(object sender, EventArgs e)
        {
            string admin = Username.Text;
            string pass = Password.Text;

            if(admin == "" || pass == "")
            {
                Notif("Data Kosong!", Alert.alertTypeEnum.Warning);
                return;
            }
            bool validasi = cek.cek_login(admin, pass);
            if (validasi)
            {
                Dashboard fd = new Dashboard();
                Notif("Selamat Datang!", Alert.alertTypeEnum.Success);
                fd.Show();
                this.Hide();
            }
            else
            {
                Notif("Gagal Login!", Alert.alertTypeEnum.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TombolLogin.PerformClick();
        }
    }
}
