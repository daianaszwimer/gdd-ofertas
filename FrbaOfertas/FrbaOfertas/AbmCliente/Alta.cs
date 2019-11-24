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
        public Alta()
        {
            InitializeComponent();
            habilitado.Visible = false;
            confirmar.Text = "CREAR";
            desactivarErrores();
        }

        override protected void confirmarCliente_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validarCampos()) //Campos obligatorios y formato validos
            {
                SqlCommand chequearExistenciaCliente =
                    new SqlCommand(
                        string.Format("SELECT cliente_dni FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente WHERE cliente_dni='{0}'", dni.Text), Helper.dbOfertas);

                SqlDataReader dataReaderUsuario = Helper.realizarConsultaSQL(chequearExistenciaCliente);
                if (dataReaderUsuario != null)
                {
                    if (!dataReaderUsuario.HasRows) // DNI unico
                    {
                        dataReaderUsuario.Close();
                        insertarLocalidad();
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

        private void insertarLocalidad()
        {
            string consultaLocalidad = string.Format("SELECT localidad_id,localidad_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Localidad " +
                                                        "WHERE localidad_nombre='{0}'", localidad.Text);
            SqlCommand chequearLocalidad = new SqlCommand(consultaLocalidad, Helper.dbOfertas);
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
                    string consultaNuevaLocalidad = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Localidad (localidad_nombre) " +
                                                                    "VALUES ('{0}'); SELECT SCOPE_IDENTITY()", localidad.Text);
                    SqlCommand insertarNuevaLocalidad = new SqlCommand(consultaNuevaLocalidad, Helper.dbOfertas);
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


        private void insertarLocalidadParaDireccion(string idLocalidad)
        {
            string consultaDomicilio = string.Format("SELECT domicilio_id, domicilio_calle, domicilio_numero_piso, domicilio_departamento " +
                                                       "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio " +
                                                       "WHERE domicilio_calle='{0}' AND domicilio_numero_piso='{1}'AND domicilio_departamento='{2}'",
                                                       calle.Text, piso.Text, depto.Text);
            SqlCommand chequearDomicilio = new SqlCommand(consultaDomicilio, Helper.dbOfertas);
            SqlDataReader dataReaderDomicilio = Helper.realizarConsultaSQL(chequearDomicilio);
            if (dataReaderDomicilio != null)
            {
                if (dataReaderDomicilio.HasRows) // Domicilio ya existe
                {
                    dataReaderDomicilio.Read();
                    string idDomicilio = dataReaderDomicilio.GetValue(0).ToString();
                    dataReaderDomicilio.Close();
                    insertarCliente(idDomicilio);
                }
                else
                {
                    dataReaderDomicilio.Close();
                    string consultaNuevoDomicilio = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio (domicilio_id_localidad,domicilio_calle,domicilio_numero_piso,domicilio_departamento,domicilio_codigo_postal) " +
                                                  "VALUES ('{0}','{1}','{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()",
                                                  idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text);
                    SqlCommand insertarNuevoDomicilio = new SqlCommand(consultaNuevoDomicilio, Helper.dbOfertas);
                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoDomicilio);
                    if (dataReader != null)
                    {
                        if (dataReader.Read())
                        {
                            string idDomicilio = dataReader.GetValue(0).ToString();
                            dataReader.Close();
                            insertarCliente(idDomicilio);
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


        private void insertarCliente(string idDomicilio)
        {
            string consultaNuevoUsuario = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Usuario (usuario_username, usuario_password) " +
                                                            "VALUES ('{0}','{1}');", dni.Text, Helper.encriptarConSHA256(dni.Text));
            SqlCommand insertarNuevoUsuario = new SqlCommand(consultaNuevoUsuario, Helper.dbOfertas);
            SqlDataReader dataReaderUsuario = Helper.realizarConsultaSQL(insertarNuevoUsuario);
            if (dataReaderUsuario != null)
            {
                if (dataReaderUsuario.RecordsAffected == 0)
                {
                    dataReaderUsuario.Close();
                }
                else
                {
                    dataReaderUsuario.Close();
                    string consultaInsertarRolCliente = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario (rolesxusuario_id_usuario, rolesxusuario_id_rol) VALUES('{0}',{1})", dni.Text, "3");
                    SqlCommand insertarRolCliente = new SqlCommand(consultaInsertarRolCliente, Helper.dbOfertas);
                    SqlDataReader dataReaderRolCliente = Helper.realizarConsultaSQL(insertarRolCliente);
                    if (dataReaderRolCliente != null)
                    {
                        if (dataReaderRolCliente.RecordsAffected == 0)
                        {
                            dataReaderRolCliente.Close();
                        }
                        else
                        {
                            dataReaderRolCliente.Close();
                            DateTime myFechaNacimiento = fechaNacimiento.Value;
                            string sqlFormattedFechaNacimiento = myFechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            string consultaNuevoCliente = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Cliente (cliente_id_domicilio,cliente_nombre," +
                                   "cliente_apellido,cliente_dni,cliente_mail,cliente_telefono,cliente_fecha_nacimiento, cliente_credito, cliente_id_usuario) " +
                                   "VALUES ({0},'{1}','{2}',{3},'{4}',{5},'{6}',{7},'{8}'); SELECT SCOPE_IDENTITY()",
                                   idDomicilio, nombre.Text, apellido.Text, dni.Text, mail.Text, telefono.Text, sqlFormattedFechaNacimiento, 200, dni.Text);
                            SqlCommand insertarNuevoCliente = new SqlCommand(consultaNuevoCliente, Helper.dbOfertas);
                            SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoCliente);
                            if (dataReader != null)
                            {
                                if (dataReader.RecordsAffected == 0)
                                {
                                    MessageBox.Show("Error al crear cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dataReader.Close();
                                    this.Hide();
                                }
                                else
                                {

                                    MessageBox.Show("Cliente REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dataReader.Close();
                                    this.Hide();
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
