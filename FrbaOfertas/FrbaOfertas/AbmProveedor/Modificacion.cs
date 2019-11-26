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
    public partial class Modificacion : AltaYModificacion
    {
        private object[] proveedor;
        string queModificarDelProveedor = "";
        string queModificarDeDomicilio = "";

        public Modificacion(object[] proveedor)
        {
            InitializeComponent();
            desactivarErrores();

            #region Se cargan los datos del proveedor seleccionado en la pantalla
                razonSocial.Text = proveedor[1].ToString();
                CUIT.Text = proveedor[2].ToString();
                localidad.Text = proveedor[5].ToString();
                calle.Text = proveedor[6].ToString();
                piso.Text = proveedor[7].ToString();
                depto.Text = proveedor[8].ToString();
                codigoPostal.Text = proveedor[9].ToString();
                telefono.Text = proveedor[10].ToString();
                mail.Text = proveedor[11].ToString();
                rubro.Text = proveedor[13].ToString();
                nombre.Text = proveedor[14].ToString();
                habilitado.Checked = bool.Parse(proveedor[15].ToString());
            #endregion

            this.proveedor = proveedor;
        }

        private bool modificarProveedor()
        {
            //MODIFICACION DE PROVEEDOR
            if (seModificoAlgoEnProveedor())
            {
                if (!Helper.modificarProveedor(proveedor[0].ToString(), queModificarDelProveedor))
                    return false;
            }

            //MODIFICACION RUBRO DEL PROVEEDOR
            if (!rubro.Text.Equals(proveedor[13].ToString()))
            {
                if (!Helper.modificarRubro(proveedor[0].ToString(), rubro.Text))
                    return false;
            }

            //MODIFICACION LOCALIDAD DEL PROVEEDOR
            if (!localidad.Text.Equals(proveedor[5].ToString()))
            {
                if (!Helper.modificarLocalidad(proveedor[3].ToString(), localidad.Text))
                    return false;
            }

            //MODIFICACION DOMICILIO DEL PROVEEDOR
            if (seModificoAlgoEnDomicilio())
            {
                if (!Helper.modificarDomicilio(proveedor[3].ToString(), queModificarDeDomicilio))
                    return false;
            }

            return true;
        }

        private bool seModificoAlgoEnProveedor()
        {
            bool seModificoAlgoDeProveedor = false;
            if (!razonSocial.Text.Equals(proveedor[1].ToString()))
            {
                queModificarDelProveedor += ("proveedor_razon_social = '" + razonSocial.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!CUIT.Text.Equals(proveedor[2].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_cuit = '" + CUIT.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!telefono.Text.Equals(proveedor[10].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_telefono = '" + telefono.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!mail.Text.Equals(proveedor[11].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_mail = '" + mail.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!nombre.Text.Equals(proveedor[14].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_nombre_contacto = '" + nombre.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (habilitado.Checked != bool.Parse(proveedor[15].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_habilitado = '" + (habilitado.Checked ? "1" : "0") + "'");
                seModificoAlgoDeProveedor = true;
            }
            return seModificoAlgoDeProveedor;
        }

        private bool seModificoAlgoEnDomicilio()
        {
            bool seModificoAlgoDeDomicilio = false;

            if (!calle.Text.Equals(proveedor[6].ToString()))
            {
                queModificarDeDomicilio += ("domicilio_calle = '" + calle.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!piso.Text.Equals(proveedor[7].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDeDomicilio += ", ";
                queModificarDeDomicilio += ("domicilio_numero_piso = '" + piso.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!depto.Text.Equals(proveedor[8].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDeDomicilio += ", ";
                queModificarDeDomicilio += ("domicilio_departamento = '" + depto.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!codigoPostal.Text.Equals(proveedor[9].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDeDomicilio += ", ";
                queModificarDeDomicilio += ("domicilio_codigo_postal = '" + codigoPostal.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }
            return seModificoAlgoDeDomicilio;
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                if (modificarProveedor())
                {
                    MessageBox.Show("El proveedor se modifico exitosamente", "Proveedor modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                    MessageBox.Show("No se ha podido modificar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
