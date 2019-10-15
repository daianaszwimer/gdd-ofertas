using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FrbaOfertas
{
    public partial class Form1 : Form
    {

        SqlConnection dbOfertas;

        public Form1()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
        }

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

        private void login_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol.Form1 abmRol = new AbmRol.Form1();
            abmRol.Show();
            /*
            // Con una tabla de prueba "usuario" que tiene username: admin 
            // y pass: w23e encriptada como "e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7"
            SqlCommand chequearLogIn = new SqlCommand("SELECT username, pass FROM usuario WHERE username='" + username.Text + "' AND pass='" + this.SHA256Encrypt(password.Text) + "'", dbOfertas);
            
            SqlDataReader dataReader = chequearLogIn.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Log In exitoso");
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
            dataReader.Close();*/
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
