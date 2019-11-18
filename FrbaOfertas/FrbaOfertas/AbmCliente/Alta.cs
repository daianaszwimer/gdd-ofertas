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
                //TODO: {M} dni UNIQUE + try catch
                SqlCommand chequearExistenciaCliente = 
                    new SqlCommand(
                        string.Format("SELECT cliente_dni FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente WHERE cliente_dni='{0}'", dni.Text), Helper.dbOfertas);
                
                SqlDataReader dataReaderUsuario = Helper.realizarConsultaSQL(chequearExistenciaCliente);
                if (dataReaderUsuario != null)
                {
                    if (!dataReaderUsuario.HasRows) // DNI unico
                    {
                        dataReaderUsuario.Close();
                        SqlCommand chequearLocalidad = 
                            new SqlCommand(
                                string.Format("SELECT localidad_id,localidad_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Localidad WHERE localidad_nombre='{0}'", localidad.Text), Helper.dbOfertas);
                        
                        SqlDataReader dataReaderLocalidad = Helper.realizarConsultaSQL(chequearLocalidad);
                        if (dataReaderLocalidad != null)
                        {
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
                                SqlCommand insertarNuevaLocalidad = 
                                    new SqlCommand(
                                        string.Format(
                                            "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Localidad (localidad_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", localidad.Text), Helper.dbOfertas);
                                
                                SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevaLocalidad);
                                if (dataReader != null)
                                {
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
        }



        private void insertarLocalidadParaDireccion(string idLocalidad)
        {
            SqlCommand chequearDomicilio =
                new SqlCommand(
                    string.Format(
                        "SELECT domicilio_id, domicilio_calle, domicilio_numero_piso, domicilio_departamento " +
                            "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio " +
                            "WHERE domicilio_calle='{0}' AND domicilio_numero_piso='{1}'AND domicilio_departamento='{2}'",
                            calle.Text, piso.Text, depto.Text), Helper.dbOfertas); 
            
            SqlDataReader dataReaderDomicilio = Helper.realizarConsultaSQL(chequearDomicilio);
            if (dataReaderDomicilio != null)
            {
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
                    SqlCommand insertarNuevoDomicilio =
                        new SqlCommand(
                            string.Format(
                                "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio " +
                                "(domicilio_id_localidad,domicilio_calle,domicilio_numero_piso,domicilio_departamento,domicilio_codigo_postal) " +
                                "VALUES ('{0}','{1}','{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()",
                                idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text), Helper.dbOfertas); 
                    
                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoDomicilio);
                    if (dataReader != null)
                    {
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
            }
        }


        private void insertarDomicilioParaCliente(string idDomicilio)
        {
            SqlCommand insertarNuevoCliente = 
                new SqlCommand(
                    string.Format(
                        "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Cliente " +
                        "(cliente_id_domicilio,cliente_nombre,cliente_apellido,cliente_dni,cliente_mail,cliente_telefono,cliente_fecha_nacimiento) " +
                        "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}'); SELECT SCOPE_IDENTITY()", 
                        idDomicilio, nombre.Text, apellido.Text, dni.Text, mail.Text, telefono.Text, fechaNacimiento.Text), 
                        Helper.dbOfertas);
            
            SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoCliente);
            if (dataReader != null)
            {
                dataReader.Read();
                string idClienteNuevo = dataReader.GetValue(0).ToString();
                dataReader.Close();

                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                SqlCommand insertarCreditoInicial =
                    new SqlCommand(
                        string.Format(
                            "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito " +
                            "(carga_credito_id_cliente, carga_credito_id_tipo_pago, carga_credito_id_tarjeta, " +
                            "carga_credito_fecha, carga_credito_monto) VALUES ('{0}','{1}','{2}','{3}','{4}')", 
                            idClienteNuevo, 1, 1, sqlFormattedDate, 200), Helper.dbOfertas);

                SqlDataReader dataReader2 = Helper.realizarConsultaSQL(insertarCreditoInicial);
                if (dataReader2 != null)
                {
                    dataReader2.Close();

                    MessageBox.Show("CLIENTE REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
        }
    }
}
