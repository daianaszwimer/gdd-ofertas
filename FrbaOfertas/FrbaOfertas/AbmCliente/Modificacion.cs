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

            this.cliente = cliente;
            desactivarErrores();
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

        private bool modificarCliente()
        {
            //MODIFICACION DE CLIENTE
            if (controlDeModificacionEnCliente())
            {
                string consultaModificarCliente = string.Format("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Cliente SET {0} WHERE cliente_id={1}; ", queModificarDelCliente, cliente[0]);
                SqlCommand modificarCliente = new SqlCommand(consultaModificarCliente, Helper.dbOfertas);
                SqlDataReader modificarClienteDataReader = modificarCliente.ExecuteReader();
                if (modificarClienteDataReader.RecordsAffected <= 0)
                {
                    modificarClienteDataReader.Close();
                    return false;
                }
                modificarClienteDataReader.Close();
            }

            //MODIFICACION LOCALIDAD DEL CLIENTE
            if (!localidad.Text.Equals(cliente[11].ToString()))
            {
                
            }

            //MODIFICACION DOMICILIO DEL CLIENTE
            if (controlDeModificacionEnDomicilio())
            {
                string idDomicilio = cliente[6].ToString();
                string consultaModificacinDomicilio = string.Format("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio SET {0} WHERE domicilio_id={1}; ", queModificarDelDomicilio, idDomicilio);
                SqlCommand modificarDomicilio = new SqlCommand(consultaModificacinDomicilio, Helper.dbOfertas);
                SqlDataReader modificarDomicilioDataReader = modificarDomicilio.ExecuteReader();
                if (modificarDomicilioDataReader.RecordsAffected <= 0)
                {
                    modificarDomicilioDataReader.Close();
                    return false;
                }
                modificarDomicilioDataReader.Close();
            }
            return true;
        }

        private bool controlDeModificacionEnCliente()
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

        private bool controlDeModificacionEnDomicilio()
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




    }
}
