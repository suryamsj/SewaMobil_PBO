using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasAkhir.Model
{
    class Pelanggan
    {
        string nama;
        string alamat;
        string no_ktp;
        string no_hp;
        public Pelanggan() { }
        public Pelanggan(string nama, string alamat, string no_ktp, string no_hp)
        {
            this.Nama = nama;
            this.Alamat = alamat;
            this.No_ktp = no_ktp;
            this.No_hp = no_hp;
        }
        public string Nama { get => nama; set => nama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string No_ktp { get => no_ktp; set => no_ktp = value; }
        public string No_hp { get => no_hp; set => no_hp = value; }
    }
}
