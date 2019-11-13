using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public static class Helper
    {
        public static SqlConnection dbOfertas;

        public static void conectarseABaseDeDatosOfertas()
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

        public static void cerrarConexionConBaseDeDatosOfertas()
        {
            try
            {
                dbOfertas.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("No se pudo cerrar la conezion con la base de datos");
            }
        }

        public static string encriptarConSHA256(string variableAEncriptar)
        {
            var encriptador = new SHA256CryptoServiceProvider();

            byte[] bytesAEncriptar = Encoding.UTF8.GetBytes(variableAEncriptar);
            byte[] bytesEncriptados = encriptador.ComputeHash(bytesAEncriptar);

            var variableEncriptada = new StringBuilder();

            for (int i = 0; i < bytesEncriptados.Length; i++)
                variableEncriptada.Append(bytesEncriptados[i].ToString("x2").ToLower());

            return variableEncriptada.ToString();
        }
    }
}
