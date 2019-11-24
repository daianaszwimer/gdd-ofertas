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
            catch(Exception)
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
            catch (Exception)
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

        public static void cerrarSesion()
        {
            MessageBox.Show("Se ha cerrado la sesion", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach(Form formAbierto in Application.OpenForms) 
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
