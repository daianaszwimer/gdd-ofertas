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
                
                string parte1Cliente = "UPDATE cliente SET ";
                string parte2Cliente = " WHERE cliente_id={0}";  
                              
                if (!nombre.Text.Equals(clienteAux.cliente_nombre)) 
                {
                    parte1Cliente += string.Format(" cliente_nombre = '{0}',", nombre.Text);
                }
                if (!apellido.Text.Equals(clienteAux.cliente_apellido))
                {
                    parte1Cliente += string.Format(" cliente_apellido = '{0}',", apellido.Text);
                }
                if (!dni.Text.Equals(clienteAux.cliente_dni)) 
                {
                    parte1Cliente += string.Format(" cliente_dni = '{0}',", dni.Text);
                }
                if (!mail.Text.Equals(clienteAux.cliente_mail)) 
                {
                    parte1Cliente += string.Format(" cliente_mail = '{0}',", mail.Text);
                }

                if (!telefono.Text.Equals(clienteAux.cliente_telefono)) 
                {
                    parte1Cliente += string.Format(" cliente_telefono = '{0}',", telefono.Text);
                }

                if (!fechaNacimiento.Text.Equals(clienteAux.cliente_fechaNacimiento))
                {
                    parte1Cliente += string.Format(" cliente_fechaNacimiento = '{0}',", fechaNacimiento.Text);
                }

                if (!habilitado.Checked.Equals(clienteAux.cliente_habilitado))
                {
                    parte1Cliente += string.Format(" cliente_habilitado = '{0}',", habilitado.Checked);
                }
        
                parte1Cliente = parte1Cliente.Remove(parte1Cliente.Length - 1);
                string modificarCliente = parte1Cliente + parte2Cliente;

                SqlCommand modificarDatosCliente = new SqlCommand(string.Format(modificarCliente, clienteAux.cliente_id), Helper.dbOfertas);
                SqlDataReader modificarClienteDataReader1 = Helper.realizarConsultaSQL(modificarDatosCliente);
                modificarClienteDataReader1.Close();




                string parte1Domicilio = "UPDATE domicilio SET ";
                string parte2Domicilio = " WHERE domicilio_id={0}";

                if (!calle.Text.Equals(clienteAux.domicilio_calle)) // Modifico el calle cliente
                {
                    parte1Domicilio += string.Format(" domicilio_calle = '{0}',", calle.Text);
                }

                if (!piso.Text.Equals(clienteAux.domicilio_piso)) // Modifico el piso cliente
                {
                    parte1Domicilio += string.Format(" domicilio_piso = '{0}',", piso.Text);
                }

                if (!depto.Text.Equals(clienteAux.domicilio_depto)) // Modifico el depto cliente
                {
                    parte1Domicilio += string.Format(" domicilio_depto = '{0}',", depto.Text);
                }

                if (!codigoPostal.Text.Equals(clienteAux.domicilio_codigoPostal)) // Modifico el codigoPostal cliente
                {
                    parte1Domicilio += string.Format(" domicilio_codpostal = '{0}',", codigoPostal.Text);
                }

                parte1Domicilio = parte1Domicilio.Remove(parte1Domicilio.Length - 1);
                string modificarDomicilio = parte1Domicilio + parte2Domicilio;

                SqlCommand modificarDatosDomicilio = new SqlCommand(string.Format(modificarDomicilio, clienteAux.domicilio_id), Helper.dbOfertas);
                SqlDataReader modificarClienteDataReader2 = Helper.realizarConsultaSQL(modificarDatosDomicilio);
                modificarClienteDataReader1.Close();




                if (!localidad.Text.Equals(clienteAux.localidad_nombre)) 
                {
                    SqlCommand modificarLocalidadCliente = new SqlCommand(string.Format("UPDATE localidad SET localidad_nombre='{0}' WHERE localidad_id={1}; ", localidad.Text, clienteAux.localidad_id), Helper.dbOfertas);
                    SqlDataReader modificarClienteDataReader = Helper.realizarConsultaSQL(modificarLocalidadCliente);
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
