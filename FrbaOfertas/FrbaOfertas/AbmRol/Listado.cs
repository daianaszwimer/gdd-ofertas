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

namespace FrbaOfertas.AbmRol
{
    public partial class Listado : Form
    {
        DataSet rolesDataSet = new DataSet();
        
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
            rolesDataSet.Clear();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            rolesDataSet.Clear();
            string consultaRoles = 
                "SELECT DISTINCT r.rol_id AS Id, r.rol_nombre AS Rol, " +
	                "ISNULL(STUFF(" +
		                "(SELECT ', ' + f.descripcion " +
                            "FROM funcionalidad f " +
                            "LEFT JOIN funcionalidadxrol fxr ON fxr.funcionalidad_id = f.id " +
		                    "WHERE fxr.rol_id = r.rol_id " +
		                    "FOR XML PATH (''))," +
		                    "1,2, ''),'-') AS Funcionalidades, r.rol_habilitado AS Habilitado " +
                    "FROM rol r " +
                    "LEFT JOIN funcionalidadxrol fxr ON fxr.rol_id = r.rol_id " +
                    "LEFT JOIN funcionalidad f ON fxr.funcionalidad_id = f.id " +
	                "WHERE r.rol_eliminado=0";

            string rolAFiltrar = rolTextBox.Text;
            object funcionalidadSeleccionada = funcionalidadesComboBox.SelectedItem;

            if (!string.IsNullOrWhiteSpace(rolAFiltrar))
            {
                consultaRoles += string.Format(" AND r.rol_nombre LIKE '%{0}%'", rolAFiltrar);
            }
            if (funcionalidadSeleccionada != null)
            {
                consultaRoles += string.Format(" AND f.descripcion LIKE '%{0}%'", funcionalidadSeleccionada);
            }

            SqlDataAdapter rolesDataAdapter = new SqlDataAdapter(consultaRoles, Helper.dbOfertas);
            rolesDataAdapter.Fill(rolesDataSet);
            tablaDeResultados.DataSource = rolesDataSet.Tables[0];
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            object[] rol = obtenerValoresFilaSeleccionada();
            (new AbmRol.Modificacion(rol)).Show();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            object[] rol = obtenerValoresFilaSeleccionada();
            string id = rol[0].ToString();
            SqlCommand eliminarRol = new SqlCommand("UPDATE rol SET rol_eliminado = 1 WHERE rol_id=" + id, Helper.dbOfertas);
            SqlDataReader dataReader = eliminarRol.ExecuteReader();

            if (dataReader.RecordsAffected != 0)
            {
                MessageBox.Show("Rol eliminado exitosamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rolesDataSet.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el rol", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataReader.Close();
        }

        private object[] obtenerValoresFilaSeleccionada()
        {
            return tablaDeResultados.SelectedRows[0].Cells
                .Cast<DataGridViewCell>()
                .Select(celda => celda.Value).ToArray();
        }
    }
}
