using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TugasAkhir.View;

namespace TugasAkhir.Controller
{
    class CekLogin
    {
        private MySqlConnection terhubung = new MySqlConnection();
        public bool cek_login(string user, string pass)
        {
            string server = "server=localhost;database=geekrental;uid=root;pwd='';";
            terhubung = new MySqlConnection(server);
            terhubung.Open();
            MySqlCommand query = new MySqlCommand();
            query.CommandText = "SELECT * FROM admin WHERE username=@id_peg AND password = @password";
            query.Parameters.AddWithValue("@id_peg", user);
            query.Parameters.AddWithValue("@password", pass);
            query.Connection = terhubung;

            MySqlDataReader masuk = query.ExecuteReader();

            if (masuk.Read())
            {
                terhubung.Close();
                return true;
            }
            else
            {
                terhubung.Close();
                return false;
            }
        }
        
    }
}
