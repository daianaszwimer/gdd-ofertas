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
    public partial class AltaProveedor : AbmProveedor.Alta
    {
        string username;
        string password;
        Form registroDeUsuario;

        public AltaProveedor(Form registroDeUsuario, string username, string password)
        {
            InitializeComponent();
            menuStrip1.Visible = false;
            this.username = username;
            this.password = password;
            this.registroDeUsuario = registroDeUsuario;
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                string idLocalidad = Helper.insertarLocalidad(localidad.Text);
                if (idLocalidad != null)
                {
                    string idDomicilio = Helper.insertarDomicilio(idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text);
                    if (idDomicilio != null)
                    {
                        string idRubro = Helper.insertarRubro(rubro.Text);
                        if (idRubro != null)
                        {
                            if (Helper.insertarUsuario(username, password))
                            {
                                Helper.insertarProveedor(this, idDomicilio, idRubro, username, razonSocial.Text, CUIT.Text, telefono.Text, mail.Text, nombre.Text);
                                registroDeUsuario.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
