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
    class TipeMobilDAO
    {
        private MySqlCommand cmd;
        string conn = "server=localhost;database=geekrental;uid=root;pwd='';";
        MySqlConnection terhubung = new MySqlConnection();

        //Constructor
        public TipeMobilDAO()
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
                cmd.CommandText = "SELECT * FROM tipemobil";
                MySqlDataAdapter mdap = new MySqlDataAdapter(cmd);
                mdap.Fill(dtm, "tipemobil");
                terhubung.Close();
            }
            catch (MySqlException)
            {
                this.Notif("Data Gagal Ditampilkan", Alert.alertTypeEnum.Error);
            }
            return dtm;
        }

        public bool InsertData(Model.TipeMobil baru)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO tipemobil (tipe) VALUES ('" + baru.Tipe_mobil + "')";
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

        public bool UpdateData(Model.TipeMobil baru, string id_tipe)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE tipemobil SET tipe='" + baru.Tipe_mobil + "' WHERE id_tipe='" + id_tipe + "'";
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

        public bool DeleteData(string id_tipe)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM tipemobil WHERE id_tipe='" + id_tipe + "'";
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
