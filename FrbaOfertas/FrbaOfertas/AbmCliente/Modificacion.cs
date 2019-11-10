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
        public Modificacion(Clientes seleccionado) : base()
        {
            nombre.Text = seleccionado.cliente_nombre;
            apellido.Text = seleccionado.cliente_apellido;
            dni.Text = seleccionado.cliente_dni.ToString();
            mail.Text = seleccionado.cliente_mail;
            telefono.Text = seleccionado.cliente_telefono.ToString();
            calle.Text = seleccionado.domicilio_calle;
            piso.Text = seleccionado.domicilio_piso.ToString();
            depto.Text = seleccionado.domicilio_depto;
            codigoPostal.Text = seleccionado.domicilio_codigoPostal.ToString();
            localidad.Text = seleccionado.localidad_nombre;
            fechaNacimiento.Text = seleccionado.cliente_fechaNacimiento.ToString();
            habilitado.Checked = seleccionado.cliente_habilitado;

            clienteAux = seleccionado;
            habilitado.Visible = true;
        }

        override protected void confirmarCliente_Click(object sender, EventArgs e)
        {
            if (validarDatosIngresados()) {
                //TODO: error update
                if (!nombre.Text.Equals(clienteAux.cliente_nombre)) // Modifico el nombre cliente
                {
                    SqlCommand modificarNombreCliente = new SqlCommand(string.Format("UPDATE cliente SET cliente_nombre='{0}' WHERE cliente_id={1}; ", nombre.Text, clienteAux.cliente_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarNombreCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!apellido.Text.Equals(clienteAux.cliente_apellido)) // Modifico el apellido cliente
                {
                    SqlCommand modificarApellidoCliente = new SqlCommand(string.Format("UPDATE cliente SET cliente_apellido='{0}' WHERE cliente_id={1}; ", apellido.Text, clienteAux.cliente_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarApellidoCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!dni.Text.Equals(clienteAux.cliente_dni)) // Modifico el dni cliente
                {
                    SqlCommand modificarDNICliente = new SqlCommand(string.Format("UPDATE cliente SET cliente_dni='{0}' WHERE cliente_id={1}; ", dni.Text, clienteAux.cliente_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarDNICliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!mail.Text.Equals(clienteAux.cliente_mail)) // Modifico el mail cliente
                {
                    SqlCommand modificarMailCliente = new SqlCommand(string.Format("UPDATE cliente SET cliente_mail='{0}' WHERE cliente_id={1}; ", mail.Text, clienteAux.cliente_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarMailCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!telefono.Text.Equals(clienteAux.cliente_telefono)) // Modifico el telefono cliente
                {
                    SqlCommand modificarTelefonoCliente = new SqlCommand(string.Format("UPDATE cliente SET cliente_telefono='{0}' WHERE cliente_id={1}; ", telefono.Text, clienteAux.cliente_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarTelefonoCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!calle.Text.Equals(clienteAux.domicilio_calle)) // Modifico el calle cliente
                {
                    SqlCommand modificarCalleCliente = new SqlCommand(string.Format("UPDATE domicilio SET domicilio_calle='{0}' WHERE domicilio_id={1}; ", calle.Text, clienteAux.domicilio_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarCalleCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!piso.Text.Equals(clienteAux.domicilio_piso)) // Modifico el piso cliente
                {
                    SqlCommand modificarPisoCliente = new SqlCommand(string.Format("UPDATE domicilio SET domicilio_piso='{0}' WHERE domicilio_id={1}; ", piso.Text, clienteAux.domicilio_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarPisoCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!depto.Text.Equals(clienteAux.domicilio_depto)) // Modifico el depto cliente
                {
                    SqlCommand modificarDeptoCliente = new SqlCommand(string.Format("UPDATE domicilio SET domicilio_depto='{0}' WHERE domicilio_id={1}; ", depto.Text, clienteAux.domicilio_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarDeptoCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!codigoPostal.Text.Equals(clienteAux.domicilio_codigoPostal)) // Modifico el codigoPostal cliente
                {
                    SqlCommand modificarCodigoPostalCliente = new SqlCommand(string.Format("UPDATE domicilio SET domicilio_codpostal='{0}' WHERE domicilio_id={1}; ", codigoPostal.Text, clienteAux.domicilio_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarCodigoPostalCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!localidad.Text.Equals(clienteAux.localidad_nombre)) // Modifico el codigoPostal cliente
                {
                    SqlCommand modificarLocalidadCliente = new SqlCommand(string.Format("UPDATE localidad SET localidad_nombre='{0}' WHERE localidad_id={1}; ", localidad.Text, clienteAux.localidad_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarLocalidadCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!fechaNacimiento.Text.Equals(clienteAux.cliente_fechaNacimiento)) // Modifico el codigoPostal cliente
                {
                    SqlCommand modificarFechaNacimientoCliente = new SqlCommand(string.Format("UPDATE cliente SET cliente_fechaNacimiento='{0}' WHERE cliente_id={1}; ", fechaNacimiento.Text, clienteAux.cliente_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarFechaNacimientoCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                if (!habilitado.Checked.Equals(clienteAux.cliente_habilitado)) // Modifico el habilitado cliente
                {
                    SqlCommand modificarHabilitadoCliente = new SqlCommand(string.Format("UPDATE cliente SET cliente_habilitado='{0}' WHERE cliente_id={1}; ", habilitado.Checked, clienteAux.cliente_id), dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarHabilitadoCliente.ExecuteReader();
                    modificarClienteDataReader.Close();
                }

                MessageBox.Show("El cliente se modifico exitosamente");
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se ha podido modificar el cliente correctamente");
            }
        }

    }
}
