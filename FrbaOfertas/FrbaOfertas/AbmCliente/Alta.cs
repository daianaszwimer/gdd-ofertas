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
        public Alta() : base()
        {
            //InitializeComponent();
            //conectarseABaseDeDatosOfertas();
            habilitado.Visible = false;
        }

        override protected void confirmarCliente_Click(object sender, EventArgs e)
        {
            AbmCliente.Form1 abmCliente = new AbmCliente.Form1();
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;

            if (validarDatosIngresados())
            {
                //TODO: dni UNIQUE
                SqlCommand chequearExistenciaCliente = new SqlCommand(string.Format("SELECT cliente_dni FROM cliente WHERE cliente_dni='{0}'", dni.Text), dbOfertas);
                SqlDataReader dataReaderUsuario = chequearExistenciaCliente.ExecuteReader();

                if (!dataReaderUsuario.HasRows) // DNI unico
                {
                    dataReaderUsuario.Close();
                    SqlCommand chequearLocalidad = new SqlCommand(string.Format("SELECT localidad_id,localidad_nombre FROM localidad WHERE localidad_nombre='{0}'", localidad.Text), dbOfertas);
                    SqlDataReader dataReaderLocalidad = chequearLocalidad.ExecuteReader();

                    if (dataReaderLocalidad.HasRows) // Localidad ya existe
                    {
                        dataReaderLocalidad.Read();
                        string idLocalidad = dataReaderLocalidad.GetValue(0).ToString();
                        dataReaderLocalidad.Close();
                        insertarLocalidadParaDireccion(idLocalidad);
                    }
                    else
                    {
                        dataReaderLocalidad.Close();
                        SqlCommand insertarNuevaLocalidad = new SqlCommand(string.Format("INSERT INTO localidad (localidad_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", localidad.Text), dbOfertas);
                        SqlDataReader dataReader = insertarNuevaLocalidad.ExecuteReader();
                        if (dataReader.Read())
                        {
                            string idLocalidad = dataReader.GetValue(0).ToString();
                            dataReader.Close();
                            insertarLocalidadParaDireccion(idLocalidad);
                        }
                        else
                        {
                            //MessageBox.Show("Error al guardar la localidad");
                            dataReader.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El DNI ingresado ya se encuentra en el sistema", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataReaderUsuario.Close();
                }
                this.Hide();
            }
        }



        private void insertarLocalidadParaDireccion(string idLocalidad)
        {
            SqlCommand chequearDomicilio = new SqlCommand(string.Format("SELECT domicilio_id, domicilio_calle, domicilio_piso, domicilio_depto FROM domicilio WHERE domicilio_calle='{0}' AND domicilio_piso='{1}'AND domicilio_depto='{2}'", calle.Text, piso.Text, depto.Text), dbOfertas);
            SqlDataReader dataReaderDomicilio = chequearDomicilio.ExecuteReader();
            if (dataReaderDomicilio.HasRows) // Domicilio ya existe
            {
                dataReaderDomicilio.Read();
                string idDomicilio = dataReaderDomicilio.GetValue(0).ToString();
                dataReaderDomicilio.Close();
                insertarDomicilioParaCliente(idDomicilio);
            }
            else
            {
                dataReaderDomicilio.Close();
                SqlCommand insertarNuevoDomicilio = new SqlCommand(string.Format("INSERT INTO domicilio (idLocalidad,domicilio_calle,domicilio_piso,domicilio_depto,domicilio_codpostal) VALUES ('{0}','{1}','{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()", idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text), dbOfertas);
                SqlDataReader dataReader = insertarNuevoDomicilio.ExecuteReader();
                if (dataReader.Read())
                {
                    string idDomicilio = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    insertarLocalidadParaDireccion(idDomicilio);
                }
                else
                {
                    //MessageBox.Show("Error al guardar el domicilio");
                    dataReader.Close();
                }
            }
        }


        private void insertarDomicilioParaCliente(string idDomicilio)
        {
            SqlCommand insertarNuevoCliente = new SqlCommand(string.Format("INSERT INTO cliente (idDomicilio,cliente_nombre,cliente_apellido,cliente_dni,cliente_mail,cliente_telefono,cliente_fechaNacimiento) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}'); SELECT SCOPE_IDENTITY()", idDomicilio, nombre.Text, apellido.Text, dni.Text, mail.Text, telefono.Text, fechaNacimiento.Text), dbOfertas);
            SqlDataReader dataReader = insertarNuevoCliente.ExecuteReader();
            dataReader.Read();
            string idClienteNuevo = dataReader.GetValue(0).ToString();
            dataReader.Close();

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-dd-MM HH:mm:ss.fff");

            SqlCommand insertarCreditoInicial =
                new SqlCommand(string.Format("INSERT INTO cargaDeCredito (idCliente, idTipoDePago, idTarjeta, carga_credito_fecha, carga_credito_monto) VALUES ('{0}','{1}','{2}','{3}','{4}')", idClienteNuevo, 1, 1, sqlFormattedDate, 200), dbOfertas);
            SqlDataReader dataReader2 = insertarCreditoInicial.ExecuteReader();
            dataReader2.Close();

            MessageBox.Show("CLIENTE REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
