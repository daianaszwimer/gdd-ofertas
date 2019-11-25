using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class Alta : AltaYModificacion
    {
        public Alta()
        {
            InitializeComponent();
            desactivarErrores();
            habilitado.Visible = false;
            confirmarCliente.Text = "CREAR";
            
        }

        override protected void confirmarCliente_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos()) //Campos obligatorios y formato validos
            {
                bool? clienteNoExiste = Helper.dniYMailNoExisten(dni.Text, mail.Text);
                if (clienteNoExiste == true)
                {
                    string idLocalidad = Helper.insertarLocalidad(localidad.Text);
                    if (idLocalidad != null)
                    {
                        string idDomicilio = Helper.insertarDomicilio(idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text);
                        if (idDomicilio != null)
                        {
                            if (Helper.insertarUsuario(dni.Text, dni.Text))
                            {
                                DateTime myFechaNacimiento = fechaNacimiento.Value;
                                string sqlFormattedFechaNacimiento = myFechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                Helper.insertarCliente(this, idDomicilio, dni.Text, nombre.Text, apellido.Text, dni.Text, mail.Text, telefono.Text, sqlFormattedFechaNacimiento);
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
