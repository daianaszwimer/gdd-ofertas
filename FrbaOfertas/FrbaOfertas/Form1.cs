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
    public partial class Form1 : Utils
    {

        public Form1()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
        }

        private void login_Click(object sender, EventArgs e)
        {          
            AbmRol.Form1 abmRol = new AbmRol.Form1();
            
            // Con una tabla de prueba "usuario" que tiene username: admin 
            // y pass: w23e encriptada como "e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7"
            SqlCommand chequearLogIn = new SqlCommand(string.Format("SELECT username, pass FROM usuario WHERE username='{0}' AND pass='{1}'", username.Text, this.SHA256Encrypt(password.Text)), dbOfertas);
            
            SqlCommand consultarEstadoUsuario = new SqlCommand(string.Format("SELECT habilitado FROM usuario WHERE username='" + username.Text + "'"), dbOfertas);
            SqlDataReader estadoUsuario = consultarEstadoUsuario.ExecuteReader();
            estadoUsuario.Read();
            string estado = estadoUsuario.GetValue(0).ToString();
            
           
            if (estado.Equals("1"))
            {
                estadoUsuario.Close();
                SqlDataReader estadoLogin = chequearLogIn.ExecuteReader();
                if (estadoLogin.Read())
                {
                    estadoLogin.Close();
                    MessageBox.Show("Log In exitoso");
                    SqlCommand loginCorrecto = new SqlCommand(string.Format("UPDATE dbo.usuario SET intentos_fallidos_login = 0 WHERE username='" + username.Text + "'"), dbOfertas);
                    SqlDataReader dataReader = loginCorrecto.ExecuteReader();
                    dataReader.Close();
                    
                    this.Hide();
                    abmRol.Show();
                }
                else
                {
                    try
                    {
                        estadoLogin.Close();
                        SqlCommand loginIncorrecto = new SqlCommand(string.Format("UPDATE dbo.usuario SET intentos_fallidos_login = intentos_fallidos_login+1 WHERE username='" + username.Text + "'"), dbOfertas);
                        SqlDataReader dataReader = loginIncorrecto.ExecuteReader();
                        MessageBox.Show("Datos incorrectos");
                        dataReader.Close();

                        this.Show();
                        
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        SqlCommand inhabilitarUsuario = new SqlCommand(string.Format("UPDATE dbo.usuario SET habilitado = 0 WHERE username='" + username.Text + "'"), dbOfertas);
                        SqlDataReader dataReader = inhabilitarUsuario.ExecuteReader();
                        MessageBox.Show("Limite login");
                        dataReader.Close();

                        this.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("USUARIO INHABILITADO", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                estadoUsuario.Close();
                
                this.Show();
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
