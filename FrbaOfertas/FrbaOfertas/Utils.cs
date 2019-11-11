using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class Utils : Form
    {
        protected SqlConnection dbOfertas;

        public void conectarseABaseDeDatosOfertas()
        {
            try
            {
                string dbOfertasConnectionString = ConfigurationManager.ConnectionStrings["dbOfertas"].ConnectionString;
                dbOfertas = new SqlConnection(dbOfertasConnectionString);
                dbOfertas.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos");
            }
        }

        public string SHA256Encrypt(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }
    }
}
