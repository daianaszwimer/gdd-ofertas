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
            localidad.Text = cliente[11].ToString();
            fechaNacimiento.Text = cliente[13].ToString();
            habilitado.Checked = bool.Parse(cliente[14].ToString());

           // habilitado.Visible = true;

        }

        private bool modificarCliente() //TODO: {M} Descomentar esto
        {
            //if (validarDatosIngresados())
            //{

            //    string parte1Cliente = "UPDATE cliente SET ";
            //    string parte2Cliente = " WHERE cliente_id={0}";

            //    if (!nombre.Text.Equals(cliente[1].ToString()))
            //    {
            //        parte1Cliente += string.Format(" cliente_nombre = '{0}',", nombre.Text);
            //    }
            //    if (!apellido.Text.Equals(cliente[2].ToString()))
            //    {
            //        parte1Cliente += string.Format(" cliente_apellido = '{0}',", apellido.Text);
            //    }
            //    if (!dni.Text.Equals(cliente[3].ToString()))
            //    {
            //        parte1Cliente += string.Format(" cliente_dni = '{0}',", dni.Text);
            //    }
            //    if (!mail.Text.Equals(cliente[4].ToString()))
            //    {
            //        parte1Cliente += string.Format(" cliente_mail = '{0}',", mail.Text);
            //    }

            //    if (!telefono.Text.Equals(cliente[5].ToString()))
            //    {
            //        parte1Cliente += string.Format(" cliente_telefono = '{0}',", telefono.Text);
            //    }

            //    if (!fechaNacimiento.Text.Equals(cliente[14].ToString()))
            //    {
            //        parte1Cliente += string.Format(" cliente_fechaNacimiento = '{0}',", fechaNacimiento.Text);
            //    }

            //    if (!habilitado.Checked.Equals(bool.Parse(cliente[15].ToString())))
            //    {
            //        parte1Cliente += string.Format(" cliente_habilitado = '{0}',", habilitado.Checked);
            //    }

            //    parte1Cliente = parte1Cliente.Remove(parte1Cliente.Length - 1);
            //    string modificarCliente = parte1Cliente + parte2Cliente;

            //    SqlCommand modificarDatosCliente = new SqlCommand(string.Format(modificarCliente, cliente[0].ToString()), Helper.dbOfertas);
            //    SqlDataReader modificarClienteDataReader1 = Helper.realizarConsultaSQL(modificarDatosCliente);
            //    modificarClienteDataReader1.Close();




            //    string parte1Domicilio = "UPDATE domicilio SET ";
            //    string parte2Domicilio = " WHERE domicilio_id={0}";

            //    if (!calle.Text.Equals(cliente[8].ToString())) // Modifico el calle cliente
            //    {
            //        parte1Domicilio += string.Format(" domicilio_calle = '{0}',", calle.Text);
            //    }

            //    if (!piso.Text.Equals(cliente[9].ToString())) // Modifico el piso cliente
            //    {
            //        parte1Domicilio += string.Format(" domicilio_piso = '{0}',", piso.Text);
            //    }

            //    if (!depto.Text.Equals(cliente[10].ToString())) // Modifico el depto cliente
            //    {
            //        parte1Domicilio += string.Format(" domicilio_depto = '{0}',", depto.Text);
            //    }

            //    if (!codigoPostal.Text.Equals(cliente[11].ToString())) // Modifico el codigoPostal cliente
            //    {
            //        parte1Domicilio += string.Format(" domicilio_codpostal = '{0}',", codigoPostal.Text);
            //    }

            //    parte1Domicilio = parte1Domicilio.Remove(parte1Domicilio.Length - 1);
            //    string modificarDomicilio = parte1Domicilio + parte2Domicilio;

            //    SqlCommand modificarDatosDomicilio = new SqlCommand(string.Format(modificarDomicilio, cliente[7].ToString()), Helper.dbOfertas);
            //    SqlDataReader modificarClienteDataReader2 = Helper.realizarConsultaSQL(modificarDatosDomicilio);
            //    modificarClienteDataReader1.Close();




            //    if (!localidad.Text.Equals(cliente[13].ToString()))
            //    {
            //        SqlCommand modificarLocalidadCliente = new SqlCommand(string.Format("UPDATE localidad SET localidad_nombre='{0}' WHERE localidad_id={1}; ", localidad.Text, cliente[12].ToString()), Helper.dbOfertas);
            //        SqlDataReader modificarClienteDataReader = Helper.realizarConsultaSQL(modificarLocalidadCliente);
            //        modificarClienteDataReader.Close();
            //    }


            //    MessageBox.Show("El cliente se modifico exitosamente");
                return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        override protected void confirmarCliente_Click(object sender, EventArgs e)
        {
            if (modificarCliente())
            {
                MessageBox.Show("El proveedor se modifico exitosamente");
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se ha podido modificar el proveedor correctamente");
            }
        }

       
    }
}
