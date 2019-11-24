using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public static class Helper
    {
        public static SqlConnection dbOfertas;
        public static string usuarioActual = "";
        public static List<string> rolesActuales = new List<string>();

        public static void conectarseABaseDeDatosOfertas()
        {
            try
            {
                dbOfertas = new SqlConnection(obtenerConnectionString());
                dbOfertas.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TODO: Cerrar la app
            }
        }

        public static void cerrarConexionConBaseDeDatosOfertas()
        {
            try
            {
                dbOfertas.Close();
            }
            catch (Exception)
            {
                // TODO: Mensaje??
            }
        }

        public static string encriptarConSHA256(string variableAEncriptar)
        {
            var encriptador = new SHA256CryptoServiceProvider();

            byte[] bytesAEncriptar = Encoding.UTF8.GetBytes(variableAEncriptar);
            byte[] bytesEncriptados = encriptador.ComputeHash(bytesAEncriptar);

            var variableEncriptada = new StringBuilder();

            for (int i = 0; i < bytesEncriptados.Length; i++)
                variableEncriptada.Append(bytesEncriptados[i].ToString("x2").ToLower());

            return variableEncriptada.ToString();
        }

        public static object[] obtenerValoresFilaSeleccionada(DataGridView tablaDeResultados)
        {
            return tablaDeResultados.SelectedRows[0].Cells
                .Cast<DataGridViewCell>()
                .Select(celda => celda.Value).ToArray();
        }

        public static string obtenerConnectionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["dbOfertas"].ConnectionString;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener el Connection String del archivo de configuracion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DateTime obtenerFechaActual()
        {
            try
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings["MyDate"]);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener la fecha actual del archivo de configuracion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarSesion();
                return new DateTime();
            }
        }

        public static SqlDataReader realizarConsultaSQL(SqlCommand consulta)
        {
            try
            {
                return consulta.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo realizar la consulta SQL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TODO: [D] que no se siga ejecutando ese form
                cerrarSesion();
                return null;
            }
        }

        public static string obtenerIdCliente()
        {
            string consultaCliente = string.Format("SELECT cliente_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente " +
                                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = cliente_id_usuario " +
                                                   "WHERE usuario_username='{0}'", Helper.usuarioActual);
            SqlCommand obtenerIdCliente = new SqlCommand(consultaCliente, Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(obtenerIdCliente);
            if (dataReader != null)
            {
                if (dataReader.Read())
                {
                    string idCliente = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    return idCliente;
                }
                dataReader.Close();
                return "";
            }
            dataReader.Close();
            return "";
        }

        public static string obtenerIdProveedor()
        {
            SqlCommand obtenerIdProveedor = new SqlCommand("SELECT proveedor_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = proveedor_id_usuario WHERE usuario_username='" + Helper.usuarioActual + "'", Helper.dbOfertas);
            SqlDataReader dataReaderProveedor = Helper.realizarConsultaSQL(obtenerIdProveedor);
            if (dataReaderProveedor != null)
            {
                if (dataReaderProveedor.Read())
                {
                    string idProveedor = dataReaderProveedor.GetValue(0).ToString();
                    dataReaderProveedor.Close();
                    return idProveedor;
                }
                dataReaderProveedor.Close();
                return "";
            }
            dataReaderProveedor.Close();
            return "";
        }

        public static string insertarLocalidad(string nombreLocalidad)
        {
            SqlCommand chequearLocalidad =
                new SqlCommand(
                    string.Format(
                        "SELECT localidad_id,localidad_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Localidad WHERE localidad_nombre='{0}'",
                        nombreLocalidad), Helper.dbOfertas);

            SqlDataReader dataReaderLocalidad = Helper.realizarConsultaSQL(chequearLocalidad);
            if (dataReaderLocalidad != null)
            {
                if (dataReaderLocalidad.HasRows) // Localidad ya existe
                {
                    dataReaderLocalidad.Read();
                    string idLocalidad = dataReaderLocalidad.GetValue(0).ToString();
                    dataReaderLocalidad.Close();
                    return idLocalidad;
                }
                else
                {
                    dataReaderLocalidad.Close();
                    SqlCommand insertarNuevaLocalidad =
                        new SqlCommand(
                            string.Format(
                                "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Localidad (localidad_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()",
                                nombreLocalidad), Helper.dbOfertas);

                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevaLocalidad);
                    if (dataReader != null)
                    {
                        if (dataReader.Read())
                        {
                            string idLocalidad = dataReader.GetValue(0).ToString();
                            dataReader.Close();
                            return idLocalidad;
                        }
                        else
                        {
                            dataReader.Close();
                            return null;
                        }
                    }
                    else
                        return null;
                }
            }
            else
                return null;
        }

        public static bool modificarLocalidad(string idDomicilio, string localidadNueva)
        {
            string consultaLocalidad = string.Format("SELECT localidad_id,localidad_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Localidad WHERE localidad_nombre='{0}'", localidadNueva);
            SqlCommand chequearLocalidad = new SqlCommand(consultaLocalidad, Helper.dbOfertas);
            SqlDataReader dataReaderLocalidad = Helper.realizarConsultaSQL(chequearLocalidad);
            if (dataReaderLocalidad != null)
            {
                if (dataReaderLocalidad.HasRows) // Localidad ya existe
                {
                    dataReaderLocalidad.Read();
                    string idLocalidad = dataReaderLocalidad.GetValue(0).ToString();
                    dataReaderLocalidad.Close();

                    string consultaModificarLocalidad = string.Format("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio SET domicilio_id_localidad='{0}' WHERE domicilio_id={1};", idLocalidad, idDomicilio);
                    SqlCommand modificarLocalidadCliente = new SqlCommand(consultaModificarLocalidad, Helper.dbOfertas);
                    SqlDataReader modificarClienteDataReader = modificarLocalidadCliente.ExecuteReader();
                    if (modificarClienteDataReader.RecordsAffected <= 0)
                    {
                        modificarClienteDataReader.Close();
                        return false;
                    }
                    modificarClienteDataReader.Close();
                }
                else
                {
                    dataReaderLocalidad.Close();

                    string consultaInsertarLocalidad = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Localidad (localidad_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", localidadNueva);
                    SqlCommand insertarNuevaLocalidad = new SqlCommand(consultaInsertarLocalidad, Helper.dbOfertas);
                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevaLocalidad);
                    if (dataReader != null)
                    {
                        if (dataReader.Read())
                        {
                            string idLocalidad = dataReader.GetValue(0).ToString();
                            dataReader.Close();

                            string consultaModificarLocalidadCliente = string.Format("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio SET domicilio_id_localidad='{0}' WHERE domicilio_id={1};", idLocalidad, idDomicilio);
                            SqlCommand modificarLocalidadCliente = new SqlCommand(consultaInsertarLocalidad, Helper.dbOfertas);
                            SqlDataReader modificarClienteDataReader = modificarLocalidadCliente.ExecuteReader();
                            if (modificarClienteDataReader.RecordsAffected <= 0)
                            {
                                modificarClienteDataReader.Close();
                                return false;
                            }
                            modificarClienteDataReader.Close();
                        }
                        else
                        {
                            dataReader.Close();
                            return false;
                        }
                    }
                }
                return true;
            }
            else
                return false;
        }

        public static string insertarDomicilio(string idLocalidad, string calle, string piso, string depto, string codigoPostal)
        {
            SqlCommand chequearDomicilio =
                new SqlCommand(
                    string.Format(
                        "SELECT domicilio_id, domicilio_calle, domicilio_numero_piso, domicilio_departamento " +
                            "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio " +
                            "WHERE domicilio_calle='{0}' AND domicilio_numero_piso='{1}'AND domicilio_departamento='{2}'",
                            calle, piso, depto), Helper.dbOfertas);

            SqlDataReader dataReaderDomicilio = Helper.realizarConsultaSQL(chequearDomicilio);
            if (dataReaderDomicilio != null)
            {
                if (dataReaderDomicilio.HasRows) // Domicilio ya existe
                {
                    dataReaderDomicilio.Read();
                    string idDomicilio = dataReaderDomicilio.GetValue(0).ToString();
                    dataReaderDomicilio.Close();
                    return idDomicilio;
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
                                idLocalidad, calle, piso, depto, codigoPostal), Helper.dbOfertas);

                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoDomicilio);
                    if (dataReader != null)
                    {
                        if (dataReader.Read())
                        {
                            string idDomicilio = dataReader.GetValue(0).ToString();
                            dataReader.Close();
                            return idDomicilio;
                        }
                        else
                        {
                            dataReader.Close();
                            return null;
                        }
                    }
                    else
                        return null;
                }
            }
            else
                return null;
        }

        public static bool modificarDomicilio(string idDomicilio, string queModificarDeDomicilio)
        {
            string modificarDomicilioString =
                    string.Format(
                        "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio SET {0} WHERE domicilio_id={1}; ",
                        queModificarDeDomicilio, idDomicilio);

            SqlCommand modificarDomicilio = new SqlCommand(modificarDomicilioString, Helper.dbOfertas);
            SqlDataReader modificarDomicilioDataReader = Helper.realizarConsultaSQL(modificarDomicilio);
            if (modificarDomicilioDataReader != null)
            {
                if (modificarDomicilioDataReader.RecordsAffected <= 0)
                {
                    modificarDomicilioDataReader.Close();
                    return false;
                }
                modificarDomicilioDataReader.Close();
                return true;
            }
            return false;
        }

        public static string insertarRubro(string nombreRubro)
        {
            SqlCommand chequearRubro =
                new SqlCommand(
                    string.Format("SELECT rubro_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Rubro WHERE rubro_descripcion='{0}'",
                    nombreRubro), Helper.dbOfertas);

            SqlDataReader dataReaderRubro = Helper.realizarConsultaSQL(chequearRubro);
            if (dataReaderRubro != null)
            {
                if (dataReaderRubro.HasRows) // Rubro ya existe
                {
                    dataReaderRubro.Read();
                    string idRubro = dataReaderRubro.GetValue(0).ToString();
                    dataReaderRubro.Close();
                    return idRubro;
                }
                else
                {
                    dataReaderRubro.Close();
                    SqlCommand insertarNuevoRubro =
                        new SqlCommand(
                            string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Rubro (rubro_descripcion) VALUES ('{0}'); " +
                                            "SELECT SCOPE_IDENTITY()", nombreRubro), Helper.dbOfertas);

                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoRubro);
                    if (dataReader != null)
                    {
                        if (dataReader.Read())
                        {
                            string idRubro = dataReader.GetValue(0).ToString();
                            dataReader.Close();
                            return idRubro;
                        }
                        else
                        {
                            dataReader.Close();
                            return null;
                        }
                    }
                    else
                        return null;
                }
            }
            else
                return null;
        }

        public static bool insertarUsuario(string usuario, string contrasenia)
        {
            SqlCommand chequearExistenciaUsuario =
                    new SqlCommand(
                        string.Format("SELECT usuario_username FROM NO_LO_TESTEAMOS_NI_UN_POCO.Usuario WHERE usuario_username='{0}'", usuario), Helper.dbOfertas);

            SqlDataReader dataReaderUsuario = Helper.realizarConsultaSQL(chequearExistenciaUsuario);
            if (dataReaderUsuario != null)
            {
                if (dataReaderUsuario.HasRows) // Usuario existe
                {
                    dataReaderUsuario.Close();
                    MessageBox.Show("El usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Helper.cerrarSesion();
                    return false;
                }
                else
                {
                    dataReaderUsuario.Close();

                    SqlCommand insertarNuevoUsuario =
                        new SqlCommand(
                            string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Usuario (usuario_username, usuario_password) " +
                            "VALUES ('{0}','{1}');",
                            usuario, Helper.encriptarConSHA256(contrasenia)), Helper.dbOfertas);

                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoUsuario);
                    if (dataReader != null)
                    {
                        if (dataReader.RecordsAffected == 0)
                        {
                            dataReader.Close();
                            return false;
                        }
                        else
                        {
                            dataReader.Close();
                            return true;
                        }
                    }
                    else
                        return false;
                }
            }
            else
                return false;
        }

        public static void insertarProveedor(Form form, string idDomicilio, string idRubro, string usuario, string razonSocial, string CUIT, string telefono, string mail, string apodo)
        {
            SqlCommand insertarRolProveedor =
                new SqlCommand(
                    string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario (rolesxusuario_id_usuario, rolesxusuario_id_rol) VALUES('{0}',{1})",
                    usuario, "2"), Helper.dbOfertas);

            SqlDataReader dataReaderRolProveedor = Helper.realizarConsultaSQL(insertarRolProveedor);
            if (dataReaderRolProveedor != null)
            {
                if (dataReaderRolProveedor.RecordsAffected == 0)
                {
                    dataReaderRolProveedor.Close();
                }
                else
                {
                    dataReaderRolProveedor.Close();
                    SqlCommand insertarNuevoProveedor =
                        new SqlCommand(
                            string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor (proveedor_razon_social, proveedor_id_domicilio," +
                            "proveedor_cuit, proveedor_telefono, proveedor_mail, proveedor_id_rubro, proveedor_nombre_contacto, proveedor_id_usuario) " +
                            "VALUES ('{0}',{1},'{2}','{3}','{4}',{5},'{6}','{7}'); SELECT SCOPE_IDENTITY()",
                    razonSocial, idDomicilio, CUIT, telefono, mail, idRubro, apodo, usuario), Helper.dbOfertas);

                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoProveedor);
                    if (dataReader != null)
                    {
                        if (dataReader.RecordsAffected == 0)
                        {
                            dataReader.Close();
                            MessageBox.Show("Error al crear proveedor", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            form.Close();
                        }
                        else
                        {
                            dataReader.Close();
                            MessageBox.Show("Proveedor REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            form.Close();
                        }
                    }
                }
            }
        }

        public static void insertarCliente(Form form, string idDomicilio, string usuario, string nombre, string apellido, string dni, string mail, string telefono, string fechaNacimiento)
        {

            string consultaInsertarRolCliente = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario (rolesxusuario_id_usuario, rolesxusuario_id_rol) VALUES('{0}',{1})", dni, "3");
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
                    string consultaNuevoCliente = string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Cliente (cliente_id_domicilio,cliente_nombre," +
                           "cliente_apellido,cliente_dni,cliente_mail,cliente_telefono,cliente_fecha_nacimiento, cliente_credito, cliente_id_usuario) " +
                           "VALUES ({0},'{1}','{2}',{3},'{4}',{5},'{6}',{7},'{8}'); SELECT SCOPE_IDENTITY()",
                           idDomicilio, nombre, apellido, dni, mail, telefono, fechaNacimiento, 200, usuario);
                    SqlCommand insertarNuevoCliente = new SqlCommand(consultaNuevoCliente, Helper.dbOfertas);
                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoCliente);
                    if (dataReader != null)
                    {
                        if (dataReader.RecordsAffected == 0)
                        {
                            MessageBox.Show("Error al crear cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataReader.Close();
                            form.Hide();
                        }
                        else
                        {

                            MessageBox.Show("Cliente REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataReader.Close();
                            form.Hide();
                        }
                    }
                }

            }
        }

        public static bool usuarioUnico(Form form, string username)
        {
            bool usuarioUnico = true;
            SqlCommand chequearExistenciaUsername =
                new SqlCommand(
                    string.Format("SELECT usuario_username FROM NO_LO_TESTEAMOS_NI_UN_POCO.Usuario WHERE usuario_username='{0}'", username), Helper.dbOfertas);
            SqlDataReader dataReaderUsuario = Helper.realizarConsultaSQL(chequearExistenciaUsername);
            if (dataReaderUsuario.HasRows)
            {
                usuarioUnico = false;
                dataReaderUsuario.Close();
            }
            return usuarioUnico;
        }

        public static bool? dniNoExisten(string dni)
        {
            SqlCommand chequearExistencia =
                    new SqlCommand(
                        string.Format(
                            "SELECT cliente_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor WHERE cliente_dni='{0}' ", dni), Helper.dbOfertas);

            SqlDataReader dataReaderCliente = Helper.realizarConsultaSQL(chequearExistencia);
            if (dataReaderCliente != null)
            {
                if (dataReaderCliente.HasRows)
                {
                    dataReaderCliente.Close();
                    return false;
                }
                else
                {
                    dataReaderCliente.Close();
                    return true;
                }
            }
            else
                return null;
        }














        public static bool? cuitYRazonSocialNoExisten(string cuit, string razonSocial)
        {
            SqlCommand chequearExistencia =
                    new SqlCommand(
                        string.Format(
                            "SELECT proveedor_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor WHERE proveedor_cuit='{0}' AND proveedor_razon_social='{1}'", cuit, razonSocial), Helper.dbOfertas);

            SqlDataReader dataReaderProveedor = Helper.realizarConsultaSQL(chequearExistencia);
            if (dataReaderProveedor != null)
            {
                if (dataReaderProveedor.HasRows)
                {
                    dataReaderProveedor.Close();
                    return false;
                }
                else
                {
                    dataReaderProveedor.Close();
                    return true;
                }
            }
            else
                return null;
        }

        public static void cerrarSesion()
        {
            MessageBox.Show("Se ha cerrado la sesion", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (Form formAbierto in Application.OpenForms)
            {
                formAbierto.Hide();
            }
            usuarioActual = "";
            rolesActuales = new List<string>();
            cerrarConexionConBaseDeDatosOfertas();
            (new Form1()).Show();
        }
    }
}
