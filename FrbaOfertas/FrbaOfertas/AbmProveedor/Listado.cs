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
    public partial class Listado : BarraDeOpciones
    {
        DataSet proveedoresDataSet = new DataSet();

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
            proveedoresDataSet.Clear();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            proveedoresDataSet.Clear();
            string consultaProveedores =
                "SELECT proveedor_id AS Id, proveedor_razon_social AS 'Razon Social', proveedor_cuit AS Cuit, domicilio_id, localidad_id, localidad_nombre AS Localidad, " +
                "domicilio_calle AS Calle, domicilio_piso AS Piso, domicilio_depto AS Depto, domicilio_codpostal AS 'Cod. Postal', proveedor_telefono AS Telefono, proveedor_mail AS Mail, " +
                "proveedor_id_rubro, rubro_descripcion AS Rubro, proveedor_nombre_contacto AS Nombre, proveedor_habilitado AS Habilitado " +
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

            SqlDataAdapter proveedoresDataAdapter = new SqlDataAdapter(consultaProveedores, Helper.dbOfertas);
            proveedoresDataAdapter.Fill(proveedoresDataSet);
            tablaDeResultados.DataSource = proveedoresDataSet.Tables[0];
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            object[] proveedor = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            (new AbmProveedor.Modificacion(proveedor)).Show();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            object[] proveedor = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            string id = proveedor[0].ToString();
            SqlCommand eliminarProveedor = new SqlCommand("UPDATE proveedor SET proveedor_eliminado = 1 WHERE proveedor_id=" + id, Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(eliminarProveedor);
            if (dataReader != null)
            {
                if (dataReader.RecordsAffected != 0)
                {
                    MessageBox.Show("Proveedor eliminado exitosamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    proveedoresDataSet.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el proveedor", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataReader.Close();
            }
        }

    }
}
