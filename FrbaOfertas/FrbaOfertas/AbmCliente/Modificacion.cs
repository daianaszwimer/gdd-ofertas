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
    public partial class Modificacion : AltaYModificacion
    {
        private object[] cliente;
        string queModificarDelCliente = "";
        string queModificarDelDomicilio = "";

        public Modificacion(object[] cliente)
        {
            InitializeComponent();
            desactivarErrores();

            #region Se cargan los datos del cliente seleccionado en la pantalla
                nombre.Text = cliente[1].ToString();
                apellido.Text = cliente[2].ToString();
                dni.Text = cliente[3].ToString();
                mail.Text = cliente[4].ToString();
                telefono.Text = cliente[5].ToString();
                calle.Text = cliente[7].ToString();
                piso.Text = cliente[8].ToString();
                depto.Text = cliente[9].ToString();
                codigoPostal.Text = cliente[10].ToString();
                localidad.Text = cliente[12].ToString();
                fechaNacimiento.Text = cliente[13].ToString();
                habilitado.Checked = bool.Parse(cliente[14].ToString());
            #endregion

            this.cliente = cliente;
        }

        private bool modificarCliente()
        {
            //MODIFICACION DE CLIENTE
            if (seModificoAlgoEnCliente())
            {
                if (!Helper.modificarCliente(cliente[0].ToString(), queModificarDelCliente))
                    return false;
            }

            //MODIFICACION LOCALIDAD DEL CLIENTE
            if (!localidad.Text.Equals(cliente[12].ToString()))
            {
                if (!Helper.modificarLocalidad(cliente[6].ToString(), localidad.Text))
                    return false;
            }

            //MODIFICACION DOMICILIO DEL CLIENTE
            if (seModificoAlgoEnDomicilio())
            {
                if (!Helper.modificarDomicilio(cliente[6].ToString(), queModificarDelDomicilio))
                    return false;
            }
            return true;
        }

        private bool seModificoAlgoEnCliente()
        {
            bool seModificoCliente = false;

            if (!nombre.Text.Equals(cliente[1].ToString()))
            {
                queModificarDelCliente += string.Format(" cliente_nombre = '{0}'", nombre.Text);
                seModificoCliente = true;
            }
            if (!apellido.Text.Equals(cliente[2].ToString()))
            {
                if (seModificoCliente)
                    queModificarDelCliente += ", ";
                queModificarDelCliente += string.Format(" cliente_apellido = '{0}'", apellido.Text);
                seModificoCliente = true;
            }
            if (!dni.Text.Equals(cliente[3].ToString()))
            {
                if (seModificoCliente)
                    queModificarDelCliente += ", ";
                queModificarDelCliente += string.Format(" cliente_dni = '{0}'", dni.Text);
                seModificoCliente = true;
            }
            if (!mail.Text.Equals(cliente[4].ToString()))
            {
                if (seModificoCliente)
                    queModificarDelCliente += ", ";
                queModificarDelCliente += string.Format(" cliente_mail = '{0}'", mail.Text);
                seModificoCliente = true;
            }
            if (!telefono.Text.Equals(cliente[5].ToString()))
            {
                if (seModificoCliente)
                    queModificarDelCliente += ", ";
                queModificarDelCliente += string.Format(" cliente_telefono = '{0}'", telefono.Text);
                seModificoCliente = true;
            }
            if (!fechaNacimiento.Text.Equals(cliente[13].ToString()))
            {
                DateTime myFechaNacimiento = fechaNacimiento.Value;
                string sqlFormattedFechaNacimiento = myFechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss.fff");
                if (seModificoCliente)
                    queModificarDelCliente += ", ";
                queModificarDelCliente += string.Format(" cliente_fecha_nacimiento = '{0}'", sqlFormattedFechaNacimiento);
                seModificoCliente = true;
            }
            if (habilitado.Checked != bool.Parse(cliente[14].ToString()))
            {
                if (seModificoCliente)
                    queModificarDelCliente += ", ";
                queModificarDelCliente += ("cliente_habilitado = '" + (habilitado.Checked ? "1" : "0") + "'");
                seModificoCliente = true;
            }
            return seModificoCliente;
        }

        private bool seModificoAlgoEnDomicilio()
        {
            bool seModificoAlgoDeDomicilio = false;
            if (!calle.Text.Equals(cliente[7].ToString()))
            {
                queModificarDelDomicilio += ("domicilio_calle = '" + calle.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!piso.Text.Equals(cliente[8].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDelDomicilio += ", ";
                queModificarDelDomicilio += ("domicilio_numero_piso = '" + piso.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!depto.Text.Equals(cliente[9].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDelDomicilio += ", ";
                queModificarDelDomicilio += ("domicilio_departamento = '" + depto.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!codigoPostal.Text.Equals(cliente[10].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDelDomicilio += ", ";
                queModificarDelDomicilio += ("domicilio_codigo_postal = '" + codigoPostal.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }
            return seModificoAlgoDeDomicilio;
        }

        override protected void confirmarCliente_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                if (modificarCliente())
                {
                    MessageBox.Show("El cliente se modifico exitosamente");
                    this.Hide();
                }
                else
                    MessageBox.Show("No se ha podido modificar el cliente correctamente");
            }
        }

    }
}
