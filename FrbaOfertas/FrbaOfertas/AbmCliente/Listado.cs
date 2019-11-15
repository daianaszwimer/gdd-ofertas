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

        private void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
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
                "SELECT c.cliente_id, c.cliente_nombre, c.cliente_apellido, c.cliente_dni, c.cliente_mail, c.cliente_telefono, " +
                        "d.domicilio_id, d.domicilio_calle, d.domicilio_piso, d.domicilio_depto, d.domicilio_codpostal, " +
                        "l.localidad_id, l.localidad_nombre, c.cliente_fechaNacimiento, c.cliente_habilitado " +
                "FROM cliente c LEFT JOIN domicilio d ON c.idDomicilio = d.domicilio_id " +
                               "LEFT JOIN localidad l ON d.idLocalidad = l.localidad_id " +
                "WHERE c.cliente_eliminado = 0";

            string nombreAFiltrar = nombre.Text;
            string apellidoAFiltrar = apellido.Text;
            string dniAFiltrar = dni.Text;
            string mailAFiltrar = mail.Text;

            if (!string.IsNullOrWhiteSpace(nombreAFiltrar))
            {
                consultaClientes += string.Format(" AND c.cliente_nombre LIKE '%{0}%'", nombreAFiltrar);//EXACTO '{0}'
            }
            if (!string.IsNullOrWhiteSpace(apellidoAFiltrar))
            {
                consultaClientes += string.Format(" AND c.cliente_apellido LIKE '%{0}%'", apellidoAFiltrar);//LIBRE '%{0}%'
            }
            if (!string.IsNullOrWhiteSpace(dniAFiltrar))
            {
                consultaClientes += string.Format(" AND c.cliente_dni LIKE '{0}'", dniAFiltrar);//LIBRE '%{0}%'
            }
            if (!string.IsNullOrWhiteSpace(mailAFiltrar))
            {
                consultaClientes += string.Format(" AND c.cliente_mail LIKE '%{0}%'", mailAFiltrar);//LIBRE '%{0}%'
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
            SqlCommand eliminarCliente = new SqlCommand("UPDATE cliente SET cliente_eliminado = 1 WHERE cliente_id=" + id, Helper.dbOfertas);
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
