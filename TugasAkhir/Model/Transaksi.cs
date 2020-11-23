using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasAkhir.Model
{
    class Transaksi
    {
        string id_transaksi;
        string id_pelanggan;
        string mobil;
        string tgl_sewa;
        string tgl_kembali;
        string harga;
        string status;
        public Transaksi() { }
        public Transaksi(string id_transaksi, string id_pelanggan, string mobil, string tgl_sewa, string tgl_kembali, string harga, string status)
        {
            this.Id_transaksi = id_transaksi;
            this.Id_pelanggan = id_pelanggan;
            this.Mobil = mobil;
            this.Tgl_sewa = tgl_sewa;
            this.Tgl_kembali = tgl_kembali;
            this.Harga = harga;
            this.Status = status;
        }
        public string Id_transaksi { get => id_transaksi; set => id_transaksi = value; }
        public string Id_pelanggan { get => id_pelanggan; set => id_pelanggan = value; }
        public string Mobil { get => mobil; set => mobil = value; }
        public string Tgl_sewa { get => tgl_sewa; set => tgl_sewa = value; }
        public string Tgl_kembali { get => tgl_kembali; set => tgl_kembali = value; }
        public string Harga { get => harga; set => harga = value; }
        public string Status { get => status; set => status = value; }
    }
}
