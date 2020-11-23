using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasAkhir.Model
{
    class TipeMobil
    {
        string tipe_mobil;
        public TipeMobil() { }
        public TipeMobil(string tipe_mobil)
        {
            this.Tipe_mobil = tipe_mobil;
        }
        public string Tipe_mobil { get => tipe_mobil; set => tipe_mobil = value; }
    }
}
