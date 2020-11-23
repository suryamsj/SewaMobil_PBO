using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasAkhir.Model;
using TugasAkhir.UI;
using TugasAkhir.View;

namespace TugasAkhir.Controller
{
    class MobilDAO
    {
        private MySqlCommand cmd;
        string conn = "server=localhost;database=geekrental;uid=root;pwd='';";
        MySqlConnection terhubung = new MySqlConnection();

        //Constructor
        public MobilDAO()
        {
            terhubung.ConnectionString = conn;
        }
        public void Notif(string pesan, Alert.alertTypeEnum type)
        {
            Alert f = new Alert();
            f.setAlert(pesan, type);
        }
        public DataSet Getall()
        {
            DataSet dtm = new DataSet();
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM mobil";
                MySqlDataAdapter mdap = new MySqlDataAdapter(cmd);
                mdap.Fill(dtm, "mobil");
                terhubung.Close();
            }
            catch (MySqlException)
            {
                this.Notif("Data Gagal Ditampilkan", Alert.alertTypeEnum.Error);
            }
            return dtm;
        }
        public DataSet JustReady()
        {
            DataSet redi = new DataSet();
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT id_mobil,tipe_mobil,merek,status_mobil,harga FROM mobil WHERE status_mobil='Ready'";
                MySqlDataAdapter mdap = new MySqlDataAdapter(cmd);
                mdap.Fill(redi, "mobil");
                terhubung.Close();
            }
            catch (MySqlException)
            {
                this.Notif("Data Gagal Ditampilkan", Alert.alertTypeEnum.Error);
            }
            return redi;
        }
        public bool InsertData(Mobil baru)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO mobil (tipe_mobil, merek, no_plat, thn_pembuatan, status_mobil, harga) VALUES ('" + baru.Tipe + "','" + baru.Merek + "','" + baru.No_plat + "','" + baru.Thn_pembuatan+ "','" + baru.Status+"','"+baru.Harga+"')";
                cmd.ExecuteNonQuery();
                stat = true;
                Notif("Data Berhasil Ditambahkan", Alert.alertTypeEnum.Success);
                terhubung.Close();
            }
            catch(MySqlException)
            {
               Notif("Data Gagal Ditambahkan", Alert.alertTypeEnum.Error);
            }
            return stat;
        }

        public bool UpdateData(Mobil baru,string id_mobil)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE mobil SET tipe_mobil='" + baru.Tipe + "'," + "merek='" + baru.Merek + "'," +
                    "no_plat='" + baru.No_plat + "'," + "thn_pembuatan='" + baru.Thn_pembuatan + "'," + "status_mobil = '" + baru.Status + "'," + "harga='" + baru.Harga + "' WHERE id_mobil='" + id_mobil + "'";
                cmd.ExecuteNonQuery();
                stat = true;
                Notif("Data Berhasil Diubah", Alert.alertTypeEnum.Success);
                terhubung.Close();
            }
            catch (MySqlException)
            {
                Notif("Data Gagal Diubah", Alert.alertTypeEnum.Error);
            }
            return stat;
        }

        public bool DeleteData(string id_mobil)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM mobil WHERE id_mobil='" + id_mobil + "'";
                cmd.ExecuteNonQuery();
                stat = true;
                Notif("Data Berhasil Dihapus", Alert.alertTypeEnum.Success);
                terhubung.Close();
            }
            catch (MySqlException)
            {
                Notif("Data Gagal Dihapus", Alert.alertTypeEnum.Error);
            }
            return stat;
        }
    }
}
