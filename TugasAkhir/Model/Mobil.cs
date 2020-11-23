using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasAkhir.Model
{
    class Mobil
    {
        string id_mobil;
        string tipe;
        string merek;
        string no_plat;
        string thn_pembuatan;
        string status;
        string harga;

        public Mobil() { }

        public Mobil(string id_mobil, string tipe, string merek, string no_plat, string thn_pembuatan, string status, string harga)
        {
            this.Id_mobil = id_mobil;
            this.Tipe = tipe;
            this.Merek = merek;
            this.No_plat = no_plat;
            this.Thn_pembuatan = thn_pembuatan;
            this.Status = status;
            this.Harga = harga;
        }

        public string Id_mobil { get => id_mobil; set => id_mobil = value; }
        public string Tipe { get => tipe; set => tipe = value; }
        public string Merek { get => merek; set => merek = value; }
        public string No_plat { get => no_plat; set => no_plat = value; }
        public string Thn_pembuatan { get => thn_pembuatan; set => thn_pembuatan = value; }
        public string Status { get => status; set => status = value; }
        public string Harga { get => harga; set => harga = value; }
    }
}
