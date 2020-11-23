using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasAkhir.View;

namespace TugasAkhir.Controller
{
    class TransaksiDAO
    {
        private MySqlCommand cmd;
        string conn = "server=localhost;database=geekrental;uid=root;pwd='';";
        MySqlConnection terhubung = new MySqlConnection();
        public TransaksiDAO()
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
                cmd.CommandText = "SELECT * FROM transaksi";
                MySqlDataAdapter mdap = new MySqlDataAdapter(cmd);
                mdap.Fill(dtm, "transaksi");
                terhubung.Close();
            }
            catch (MySqlException)
            {
                this.Notif("Data Gagal Ditampilkan", Alert.alertTypeEnum.Error);
            }
            return dtm;
        }
        public bool InsertData(Model.Transaksi baru)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO transaksi (id_pelanggan, id_mobil, tgl_sewa, tgl_kembali, total_sewa, status_transaksi) VALUES ('" + baru.Id_pelanggan + "','" + baru.Mobil + "','" + baru.Tgl_sewa + "','" + baru.Tgl_kembali + "','" + baru.Harga + "','" + baru.Status + "')";
                cmd.ExecuteNonQuery();
                stat = true;
                Notif("Data Berhasil Ditambahkan", Alert.alertTypeEnum.Success);
            }
            catch(MySqlException)
            {
                Notif("Data Gagal Ditambahkan", Alert.alertTypeEnum.Error);
            }
            return stat;
        }
        public bool UpdateData(Model.Transaksi baru,string id_transaksi)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE transaksi SET id_pelanggan='" + baru.Id_pelanggan + "'," + "id_mobil='" + baru.Mobil + "'," + "tgl_sewa='" + baru.Tgl_sewa + "'," + "tgl_kembali='" + baru.Tgl_kembali + "'," + "total_sewa='" + baru.Harga + "'," + "status_transaksi='" + baru.Status + "' WHERE id_transaksi='" + id_transaksi + "'";
                cmd.ExecuteNonQuery();
                stat = true;
                Notif("Data Berhasil Ditambahkan", Alert.alertTypeEnum.Success);
            }
            catch (MySqlException)
            {
                Notif("Data Gagal Ditambahkan", Alert.alertTypeEnum.Error);
            }
            return stat;
        }
        public bool DeleteData(string id_transaksi)
        {
            Boolean stat = false;
            try
            {
                terhubung.Open();
                cmd = new MySqlCommand();
                cmd.Connection = terhubung;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM transaksi WHERE id_transaksi='" + id_transaksi + "'";
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
