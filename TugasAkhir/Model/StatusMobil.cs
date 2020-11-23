using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasAkhir.Model
{
    class StatusMobil
    {
        string nm_status;
        public StatusMobil(string nm_status)
        {
            this.Nm_status = nm_status;
        }
        public string Nm_status { get => nm_status; set => nm_status = value; }
    }
}
