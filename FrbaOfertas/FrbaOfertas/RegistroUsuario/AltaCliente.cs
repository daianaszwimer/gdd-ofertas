using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.RegistroUsuario
{
    public partial class AltaCliente : AbmCliente.Alta
    {
        string username;
        string password;
        Form registroDeUsuario;

        public AltaCliente(Form registroDeUsuario, string username, string password)
        {
            InitializeComponent();
            menuStrip1.Visible = false;
            this.username = username;
            this.password = password;
            this.registroDeUsuario = registroDeUsuario;
        }

        override protected void confirmarCliente_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                bool? clienteNoExiste = Helper.dniNoExisten(dni.Text);
                if (clienteNoExiste == true)
                {
                    string idLocalidad = Helper.insertarLocalidad(localidad.Text);
                    if (idLocalidad != null)
                    {
                        string idDomicilio = Helper.insertarDomicilio(idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text);
                        if (idDomicilio != null)
                        {
                            if (Helper.insertarUsuario(username, password))
                            {
                                DateTime myFechaNacimiento = fechaNacimiento.Value;
                                string sqlFormattedFechaNacimiento = myFechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss.fff");

                                Helper.insertarCliente(this, idDomicilio, username, nombre.Text, apellido.Text, dni.Text, mail.Text, telefono.Text, sqlFormattedFechaNacimiento);
                                registroDeUsuario.Close();
                            }
                        }
                    }
                }
                else if (clienteNoExiste == false)
                {
                    MessageBox.Show("Ya existe un cliente con ese Dni", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
