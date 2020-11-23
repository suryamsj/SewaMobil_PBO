using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasAkhir.Model;
using TugasAkhir.View;

namespace TugasAkhir.Controller
{
    class PelangganDAO
    {
        private MySqlCommand cmd;
        string conn = "server=localhost;database=geekrental;uid=root;pwd='';";
        MySqlConnection terhubung = new MySqlConnection();

        public PelangganDAO()
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
                cmd.CommandText = "SELECT * FROM pelanggan";
                MySqlDataAdapter mdap = new MySqlDataAdapter(cmd);
                mdap.Fill(dtm, "pelanggan");
                terhubung.Close();
            }
            catch (MySqlException)
            {
                this.Notif("Data Gagal Ditampilkan", Alert.alertTypeEnum.Error);
            }
            return dtm;
        }
        public bool InsertData(Pelanggan baru)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO pelanggan (nm_pelanggan, alamat, no_ktp, no_hp) VALUES ('" + baru.Nama + "','" + baru.Alamat + "','" + baru.No_ktp + "','" + baru.No_hp + "')";
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
        public bool UpdateData(Pelanggan baru, string id_pelanggan)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE pelanggan SET nm_pelanggan='" + baru.Nama + "'," + "alamat='" + baru.Alamat + "'," +
                    "no_ktp='" + baru.No_ktp + "'," + "no_hp='" + baru.No_hp + "' WHERE id_pelanggan='" + id_pelanggan + "'";
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
        public bool DeleteData(string id_pelanggan)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM pelanggan WHERE id_pelanggan='" + id_pelanggan + "'";
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
