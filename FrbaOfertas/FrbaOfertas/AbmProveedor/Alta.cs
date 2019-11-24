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

namespace FrbaOfertas.AbmProveedor
{
    public partial class Alta : AltaYModificacion
    {
        public Alta()
        {
            InitializeComponent();
            desactivarErrores();
            habilitado.Visible = false;
            confirmar.Text = "Crear";
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            // TODO: [D] Validaciones
            // TODO: [D] chequeo que no haya 2 con misma razon social y cuit
            desactivarErrores();
            if (validacionCampos())
            {
                bool? proveedorNoExiste = Helper.cuitYRazonSocialNoExisten(CUIT.Text, razonSocial.Text);
                if (proveedorNoExiste == true)
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
                                if (Helper.insertarUsuario(CUIT.Text, CUIT.Text))
                                {
                                    Helper.insertarProveedor(this, idDomicilio, idRubro, CUIT.Text, razonSocial.Text, CUIT.Text, telefono.Text, mail.Text, nombre.Text);
                                }
                            }
                        }
                    }
                }
                else if (proveedorNoExiste == false)
                {
                    MessageBox.Show("Ya existe un proveedor con ese CUIT y Razon Social", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
