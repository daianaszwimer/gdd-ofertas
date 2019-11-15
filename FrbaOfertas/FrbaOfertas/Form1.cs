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

        public Form1()
        {
            InitializeComponent();
            Helper.conectarseABaseDeDatosOfertas();
        }

        private void login_Click(object sender, EventArgs e)
        {          
            //TODO: {M} Cambiar nombres atributos usuario
            // Con una tabla de prueba "usuario" que tiene username: admin 
            // y pass: w23e encriptada como "e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7"
            SqlCommand chequearUsuario = new SqlCommand(string.Format("SELECT usuario_username, usuario_intentos_fallidos_login FROM usuario WHERE usuario_username='{0}'", username.Text), Helper.dbOfertas);
            SqlDataReader estadoUsuario = Helper.realizarConsultaSQL(chequearUsuario);
            if (estadoUsuario != null)
            {
                estadoUsuario.Read();
                int intentosLogin = (int)estadoUsuario.GetValue(1);

                if (estadoUsuario.HasRows) // USUARIO EXISTE 
                {
                    estadoUsuario.Close();
                    SqlCommand chequearLogIn = new SqlCommand(string.Format("SELECT usuario_username, usuario_password FROM usuario WHERE usuario_username='{0}' AND usuario_password='{1}'", username.Text, Helper.encriptarConSHA256(password.Text)), Helper.dbOfertas);
                    SqlDataReader estadoLogin = Helper.realizarConsultaSQL(chequearLogIn);
                    if (estadoLogin != null)
                    {
                        if (estadoLogin.Read())
                        {
                            estadoLogin.Close(); // HABILITADO OK
                            SqlCommand loginCorrecto = new SqlCommand(string.Format("UPDATE dbo.usuario SET usuario_intentos_fallidos_login = 0 WHERE usuario_username='" + username.Text + "'"), Helper.dbOfertas);
                            SqlDataReader dataReader = Helper.realizarConsultaSQL(loginCorrecto);
                            if (dataReader != null)
                            {
                                dataReader.Close();

                                this.Hide();
                                Helper.usuarioActual = username.Text;
                                (new Menu()).Show();
                            }
                        }
                        else
                        {
                            estadoLogin.Close(); // HABILITADO (1* o 2* error)
                            if (intentosLogin <= 2)
                            {
                                SqlCommand loginIncorrecto = new SqlCommand(string.Format("UPDATE dbo.usuario SET usuario_intentos_fallidos_login = usuario_intentos_fallidos_login+1 WHERE usuario_username='" + username.Text + "'"), Helper.dbOfertas);
                                SqlDataReader dataReader = Helper.realizarConsultaSQL(loginIncorrecto);
                                if (dataReader != null)
                                {
                                    MessageBox.Show("DATOS INCORRECTO", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dataReader.Close();

                                    this.Show();
                                }
                            }
                            else // INHABILITADO (3* error)
                            {
                                estadoLogin.Close();
                                SqlCommand inhabilitarUsuario = new SqlCommand(string.Format("UPDATE dbo.usuario SET usuario_habilitado = 0 WHERE usuario_username='" + username.Text + "'"), Helper.dbOfertas);
                                SqlDataReader dataReader = Helper.realizarConsultaSQL(inhabilitarUsuario);
                                if (dataReader != null)
                                {
                                    MessageBox.Show("USUARIO INHABILITADO", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dataReader.Close();
                                    this.Show();
                                }
                            }
                        }
                    }
                }
                else // USUARIO NO EXISTE
                {
                    MessageBox.Show("USUARIO NO REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estadoUsuario.Close();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new RegistrarUsuario()).Show();
        }
    }
}
