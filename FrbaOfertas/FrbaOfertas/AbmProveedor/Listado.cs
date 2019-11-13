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

namespace FrbaOfertas.AbmProveedor
{
    public partial class Listado : Form
    {
        DataTable table = new DataTable();
        List<Proveedores> proveedores = new List<Proveedores>();

        public Listado()
        {
            InitializeComponent();

            // Se crean las columnas
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Razon Social", typeof(string));
            table.Columns.Add("Domicilio", typeof(string));
            table.Columns.Add("CUIT", typeof(string));
            table.Columns.Add("Telefono", typeof(string));
            table.Columns.Add("Mail", typeof(string));
            table.Columns.Add("Rubro", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Habilitado", typeof(bool));

            tablaDeResultados.DataSource = table; // Binding de table con el dataGridView tablaDeResultados
            tablaDeResultados.CellContentClick += tablaDeResultados_CellContentClick; // Evento para modificar y borrar

            // Se agrega columna modificar
            // (no se puede agregar al data table del binding un button)
            DataGridViewButtonColumn columnaModificar = new DataGridViewButtonColumn();
            columnaModificar.HeaderText = "Modificar";
            tablaDeResultados.Columns.Add(columnaModificar);

            // Se agrega columna eliminar
            // (no se puede agregar al data table del binding un button)
            DataGridViewButtonColumn columnaEliminar = new DataGridViewButtonColumn();
            columnaEliminar.HeaderText = "Eliminar";
            tablaDeResultados.Columns.Add(columnaEliminar);
        }

        // Evento para modificar y borrar
        private void tablaDeResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(tablaDeResultados[2, e.RowIndex].Value);

            if (e.ColumnIndex == 0) // Si es un boton de modificar
            {
                var proveedor = proveedores.Find(prov => prov.id == id);
                (new AbmProveedor.Modificacion(proveedor)).Show();
            }

            if (e.ColumnIndex == 1)
            {
                eliminarProveedor(id);
            }
        }

        private void eliminarProveedor(int id)
        {
            SqlCommand eliminarProveedor = new SqlCommand("UPDATE proveedor SET proveedor_eliminado = 1 WHERE proveedor_id=" + id.ToString(), Helper.dbOfertas);
            SqlDataReader dataReader = eliminarProveedor.ExecuteReader();

            if (dataReader.RecordsAffected != 0)
            {
                MessageBox.Show("Proveedor eliminado exitosamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                table.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el proveedor", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataReader.Close();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            table.Clear();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            table.Clear();
            string consultaProveedores =
                "SELECT proveedor_id, proveedor_razon_social, proveedor_cuit, domicilio_id, localidad_id, localidad_nombre, " +
                "domicilio_calle, domicilio_piso, domicilio_depto, domicilio_codpostal, proveedor_telefono, proveedor_mail, " +
                " proveedor_id_rubro, rubro_descripcion, proveedor_nombre_contacto, proveedor_habilitado " +
                    "FROM proveedor LEFT JOIN domicilio ON domicilio_id = proveedor_id_domicilio " +
                                   "LEFT JOIN localidad ON localidad_id = idLocalidad " +
                                   "LEFT JOIN rubro f ON rubro_id = proveedor_id_rubro WHERE proveedor_eliminado = 0";

            string razonSocialAFiltrar = razonSocial.Text;
            string cuitAFiltrar = CUIT.Text;
            string mailAFiltrar = mail.Text;

            if (!string.IsNullOrWhiteSpace(razonSocialAFiltrar))
            {
                consultaProveedores += string.Format(" AND proveedor_razon_social LIKE '%{0}%'", razonSocialAFiltrar);
            }
            if (!string.IsNullOrWhiteSpace(cuitAFiltrar))
            {
                consultaProveedores += string.Format(" AND proveedor_cuit = '{0}'", cuitAFiltrar);
            }
            if (!string.IsNullOrWhiteSpace(mailAFiltrar))
            {
                consultaProveedores += string.Format(" AND proveedor_mail LIKE '%{0}%'", mailAFiltrar);
            }

            SqlCommand seleccionarProveedores = new SqlCommand(consultaProveedores, Helper.dbOfertas);
            SqlDataReader dataReader = seleccionarProveedores.ExecuteReader();

            proveedores = convertirRespuestaAListaDeProveedores(dataReader);

            dataReader.Close();

            foreach (var proveedor in proveedores)
            {
                string domicilio = proveedor.domicilio_calle + ", " + proveedor.localidad_nombre;
                table.Rows.Add(proveedor.id.ToString(), proveedor.razonSocial, domicilio, proveedor.cuit, 
                    proveedor.telefono.ToString(), proveedor.mail, proveedor.rubro, proveedor.nombreContacto, 
                    proveedor.habilitado); // Se agrega una fila a la tabla
                tablaDeResultados.Rows[table.Rows.Count - 1].Cells[0].Value = "..."; // Boton de modificar
            }
        }

        private List<Proveedores> convertirRespuestaAListaDeProveedores(SqlDataReader dataReader)
        {
            List<Proveedores> listaDeProveedores = new List<Proveedores>();

            while (dataReader.Read())
            {
                Proveedores proveedor = new Proveedores();
                proveedor.id = (int)dataReader.GetValue(0);
                proveedor.razonSocial = dataReader.GetValue(1).ToString();
                proveedor.cuit = dataReader.GetValue(2).ToString();
                proveedor.idDomicilio = (int)dataReader.GetValue(3);
                proveedor.localidad_id = (int)dataReader.GetValue(4);
                proveedor.localidad_nombre = dataReader.GetValue(5).ToString();
                proveedor.domicilio_calle = dataReader.GetValue(6).ToString();
                proveedor.domicilio_piso = (int)dataReader.GetValue(7);
                proveedor.domicilio_depto = dataReader.GetValue(8).ToString();
                proveedor.domicilio_codpostal = (int)dataReader.GetValue(9);
                proveedor.telefono = (int)dataReader.GetValue(10);
                proveedor.mail = dataReader.GetValue(11).ToString();
                proveedor.idRubro = (int)dataReader.GetValue(12);
                proveedor.rubro = dataReader.GetValue(13).ToString();
                proveedor.nombreContacto = dataReader.GetValue(14).ToString();
                proveedor.habilitado = (bool)dataReader.GetValue(15);

                listaDeProveedores.Add(proveedor);
            }
            return listaDeProveedores;
        }

    }
}
