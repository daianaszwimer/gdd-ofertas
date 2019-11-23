using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class Listado : BarraDeOpciones
    {

        DataSet clientesDataSet = new DataSet();

        public Listado()
        {
            InitializeComponent();
            modificar.Visible = false;
            eliminar.Visible = false;
            tablaDeResultados.SelectionChanged += tablaDeResultados_SelectionChanged;
        }

        protected virtual void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaDeResultados.SelectedRows.Count == 0)
            {
                modificar.Visible = false;
                eliminar.Visible = false;
            }
            else
            {
                modificar.Visible = true;
                eliminar.Visible = true;
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            clientesDataSet.Clear();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            clientesDataSet.Clear();
            string consultaClientes =
                "SELECT cliente_id, cliente_nombre, cliente_apellido, cliente_dni, cliente_mail, cliente_telefono, " +
                        "domicilio_id, domicilio_calle, domicilio_numero_piso, domicilio_departamento, domicilio_codigo_postal, " +
                        "localidad_id, localidad_nombre, cliente_fecha_nacimiento, cliente_habilitado " +
                "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente LEFT JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio ON cliente_id_domicilio = domicilio_id " +
                   "LEFT JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Localidad ON domicilio_id_localidad = localidad_id " +
                "WHERE cliente_eliminado = 0";

            string nombreAFiltrar = nombre.Text;
            string apellidoAFiltrar = apellido.Text;
            string dniAFiltrar = dni.Text;
            string mailAFiltrar = mail.Text;

            if (!string.IsNullOrWhiteSpace(nombreAFiltrar))
            {
                consultaClientes += string.Format(" AND cliente_nombre LIKE '%{0}%'", nombreAFiltrar);//EXACTO '{0}'
            }
            if (!string.IsNullOrWhiteSpace(apellidoAFiltrar))
            {
                consultaClientes += string.Format(" AND cliente_apellido LIKE '%{0}%'", apellidoAFiltrar);//LIBRE '%{0}%'
            }
            if (!string.IsNullOrWhiteSpace(dniAFiltrar))
            {
                consultaClientes += string.Format(" AND cliente_dni LIKE '{0}'", dniAFiltrar);//LIBRE '%{0}%'
            }
            if (!string.IsNullOrWhiteSpace(mailAFiltrar))
            {
                consultaClientes += string.Format(" AND cliente_mail LIKE '%{0}%'", mailAFiltrar);//LIBRE '%{0}%'
            }

            SqlDataAdapter clientesDataAdapter = new SqlDataAdapter(consultaClientes, Helper.dbOfertas);
            clientesDataAdapter.Fill(clientesDataSet);
            tablaDeResultados.DataSource = clientesDataSet.Tables[0];
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            object[] cliente = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            (new AbmCliente.Modificacion(cliente)).Show();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            object[] cliente = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            string id = cliente[0].ToString();
            SqlCommand eliminarCliente =
                new SqlCommand("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Cliente SET cliente_eliminado = 1 WHERE cliente_id=" + id, Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(eliminarCliente);
            if (dataReader != null)
            {
                if (dataReader.RecordsAffected != 0)
                {
                    MessageBox.Show("Cliente eliminado exitosamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clientesDataSet.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente ", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataReader.Close();
            }
        }
    }
}
