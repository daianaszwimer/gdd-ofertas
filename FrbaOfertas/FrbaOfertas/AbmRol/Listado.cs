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
    public partial class Listado : BarraDeOpciones
    {
        DataSet rolesDataSet = new DataSet();
        
        public Listado()
        {
            InitializeComponent();
            modificar.Visible = false;
            eliminar.Visible = false;
            asignarRolAUsuario.Visible = false;
            tablaDeResultados.SelectionChanged += tablaDeResultados_SelectionChanged;
        }

        private void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaDeResultados.SelectedRows.Count == 0)
            {
                modificar.Visible = false;
                eliminar.Visible = false;
                asignarRolAUsuario.Visible = false;
            }
            else
            {
                object[] rol = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
                modificar.Visible = true;
                eliminar.Visible = true;
                asignarRolAUsuario.Visible = true;

                if (!bool.Parse(rol[3].ToString()) || rol[0].ToString().Equals("2") || rol[0].ToString().Equals("3"))
                    asignarRolAUsuario.Enabled = false;
                else
                    asignarRolAUsuario.Enabled = true;
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
                "SELECT DISTINCT rol_id AS Id, rol_nombre AS Rol, " +
	                "ISNULL(STUFF(" +
		                "(SELECT ', ' + funcionalidad_descripcion " +
                            "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad " +
                            "LEFT JOIN NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol " +
                            "ON funcionalidadxrol_id_funcionalidad = funcionalidad_id " +
		                    "WHERE funcionalidadxrol_id_rol = rol_id " +
		                    "FOR XML PATH (''))," +
		                    "1,2, ''),'-') AS Funcionalidades, rol_habilitado AS Habilitado " +
                    "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Rol " +
                    "LEFT JOIN NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol ON funcionalidadxrol_id_rol = rol_id " +
                    "LEFT JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad ON funcionalidadxrol_id_funcionalidad = funcionalidad_id " +
	                "WHERE rol_eliminado=0";

            string rolAFiltrar = rolTextBox.Text;
            object funcionalidadSeleccionada = funcionalidadesComboBox.SelectedItem;

            if (!string.IsNullOrWhiteSpace(rolAFiltrar))
            {
                consultaRoles += string.Format(" AND rol_nombre LIKE '%{0}%'", rolAFiltrar);
            }

            if (funcionalidadSeleccionada != null)
            {
                consultaRoles += string.Format(" AND funcionalidad_descripcion LIKE '%{0}%'", funcionalidadSeleccionada);
            }

            SqlDataAdapter rolesDataAdapter = new SqlDataAdapter(consultaRoles, Helper.dbOfertas);
            rolesDataAdapter.Fill(rolesDataSet);
            tablaDeResultados.DataSource = rolesDataSet.Tables[0];
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            object[] rol = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            (new AbmRol.Modificacion(rol)).Show();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            object[] rol = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            string id = rol[0].ToString();
            SqlCommand eliminarRol = new SqlCommand("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Rol SET rol_eliminado = 1 WHERE rol_id=" + id, Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(eliminarRol);
            if (dataReader != null)
            {
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
        }

        private void asignarRolAUsuario_Click(object sender, EventArgs e)
        {
            object[] rol = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            (new AbmRol.AsignarUsuario(rol)).Show();
        }
    }
}
