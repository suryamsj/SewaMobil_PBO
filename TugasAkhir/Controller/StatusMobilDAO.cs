using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TugasAkhir.Model;
using TugasAkhir.View;

namespace TugasAkhir.Controller
{
    class StatusMobilDAO
    {
        private MySqlCommand cmd;
        string conn = "server=localhost;database=geekrental;uid=root;pwd='';";
        MySqlConnection terhubung = new MySqlConnection();

        public StatusMobilDAO()
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
                cmd.CommandText = "SELECT * FROM statusmobil";
                MySqlDataAdapter mdap = new MySqlDataAdapter(cmd);
                mdap.Fill(dtm, "statusmobil");
                terhubung.Close();
            }
            catch (MySqlException)
            {
                this.Notif("Data Gagal Ditampilkan", Alert.alertTypeEnum.Error);
            }
            return dtm;
        }

        public bool InsertData(StatusMobil baru)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO tipe (tipe) VALUES ('" + baru.Nm_status + "')";
                cmd.ExecuteNonQuery();
                stat = true;
                Notif("Data Berhasil Ditambahkan", Alert.alertTypeEnum.Success);
                terhubung.Close();
            }
            catch (MySqlException)
            {
                Notif("Data Gagal Ditambahkan", Alert.alertTypeEnum.Error);
            }
            return stat;
        }

        public bool UpdateData(StatusMobil baru, string id_status)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE tipe SET tipe='" + baru.Nm_status + "' WHERE id_tipe='" + id_status + "'";
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

        public bool DeleteData(string id_status)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM statusmobil WHERE id_status='" + id_status + "'";
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
