using MySql.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasAkhir.Properties;

namespace TugasAkhir.View
{
    public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
        }

        public enum alertTypeEnum
        {
            Success,
            Error,
            Warning
        }

        private int x, y;
        public void setAlert(string pesan, Alert.alertTypeEnum type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Alert f = (Alert)Application.OpenForms[fname];

                if (f == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            switch (type)
            {
                case Alert.alertTypeEnum.Success:
                    this.guna2PictureBox1.Image = Properties.Resources.icons8_delete_90px;
                    this.BackColor = Color.FromArgb(26, 188, 156);
                    this.guna2Panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
                    break;
                case Alert.alertTypeEnum.Warning:
                    this.guna2PictureBox1.Image = Properties.Resources.icons8_delete_90px;
                    this.BackColor = Color.FromArgb(241, 196, 15);
                    this.guna2Panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
                    break;
                case Alert.alertTypeEnum.Error:
                    this.guna2PictureBox1.Image = Properties.Resources.icons8_delete_90px;
                    this.BackColor = Color.FromArgb(231, 76, 60);
                    this.guna2Panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
                    break;
            }
            this.label1.Text = pesan;

            this.Show();
            this.action = actionEnum.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
        public enum actionEnum
        {
            wait,
            start,
            close
        }
        private Alert.actionEnum action;

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 1;
            this.action = Alert.actionEnum.close;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case Alert.actionEnum.wait:
                    this.timer1.Interval = 5000;
                    this.action = Alert.actionEnum.close;
                    break;
                case Alert.actionEnum.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            this.action = Alert.actionEnum.wait;
                        }
                    }
                    break;
                case Alert.actionEnum.close:
                    this.timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        
    }
}
