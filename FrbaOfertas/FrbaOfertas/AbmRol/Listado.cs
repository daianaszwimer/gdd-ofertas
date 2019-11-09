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
    public partial class Listado : Utils
    {
        DataTable table = new DataTable();
        List<RolxFuncionalidades> rolesYfuncionalidades = new List<RolxFuncionalidades>();
        
        public Listado()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();

            // Se crean las columnas
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Rol", typeof(string));
            table.Columns.Add("Funcionalidades", typeof(string));
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
            columnaModificar.HeaderText = "Eliminar";
            tablaDeResultados.Columns.Add(columnaEliminar);
        }

        // Evento para modificar y borrar
        private void tablaDeResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(tablaDeResultados[2, e.RowIndex].Value);
            
            if (e.ColumnIndex == 0) // Si es un boton de modificar
            {
                var RxF = rolesYfuncionalidades.Find(rol => rol.id == id);
                (new AbmRol.Modificacion(RxF)).Show();
            }

            if (e.ColumnIndex == 1)
            {
                eliminarRol(id);
            }
        }

        private void eliminarRol(int id)
        {
            SqlCommand eliminarRol = new SqlCommand("UPDATE rol SET rol_eliminado = 1 WHERE rol_id=" + id.ToString(), dbOfertas);
            SqlDataReader dataReader = eliminarRol.ExecuteReader();

            if (dataReader.RecordsAffected != 0)
            {
                MessageBox.Show("Rol eliminado exitosamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                table.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el rol ", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string consultaRoles = 
                "SELECT r.rol_id, r.rol_habilitado, r.rol_nombre AS Rol, ISNULL(f.descripcion, '-') AS Funcionalidades " +
                    "FROM rol r LEFT JOIN funcionalidadxrol fxr ON fxr.rol_id = r.rol_id " +
                               "LEFT JOIN funcionalidad f ON fxr.funcionalidad_id = f.id WHERE r.rol_eliminado = 0";

            string rolAFiltrar = rolTextBox.Text;
            object funcionalidadSeleccionada = funcionalidadesComboBox.SelectedItem;

            if (!string.IsNullOrWhiteSpace(rolAFiltrar) && funcionalidadSeleccionada != null)
            {
                consultaRoles += string.Format(" AND r.rol_nombre LIKE '%{0}%' AND f.descripcion = '{1}'", rolAFiltrar, funcionalidadSeleccionada);
            }
            else if (string.IsNullOrWhiteSpace(rolAFiltrar) && funcionalidadSeleccionada != null)
            {
                consultaRoles += string.Format(" AND f.descripcion = '{0}'", funcionalidadSeleccionada);
            }
            else if (!string.IsNullOrWhiteSpace(rolAFiltrar) && funcionalidadSeleccionada == null)
            {
                consultaRoles += string.Format(" AND r.rol_nombre LIKE '%{0}%'", rolAFiltrar);
            }

            SqlCommand seleccionarRoles = new SqlCommand(consultaRoles, dbOfertas);
            SqlDataReader dataReader = seleccionarRoles.ExecuteReader();

            // Se guarda en rolesYfuncionalidades la respuesta al SELECT 
            // (en formato List<RolxFuncionalidades> para que sea mas facil acceder y filtrar elementos)
            rolesYfuncionalidades = convertirRespuestaAListaDeRolesYFuncionalidades(dataReader);

            dataReader.Close();

            foreach (var RxF in rolesYfuncionalidades)
            {
                string funcionalidades = string.Join(", ", RxF.funcionalidades);
                table.Rows.Add(RxF.id, RxF.rol, funcionalidades, RxF.habilitado); // Se agrega una fila a la tabla
                tablaDeResultados.Rows[table.Rows.Count - 1].Cells[0].Value = "..."; // Boton de modificar
            }
        }

        private List<RolxFuncionalidades> convertirRespuestaAListaDeRolesYFuncionalidades(SqlDataReader dataReader)
        {
            List<RolxFuncionalidades> listaDeRxF = new List<RolxFuncionalidades>();

            while (dataReader.Read())
            {
                int id = (int) dataReader.GetValue(0);
                bool habilitado = (bool) dataReader.GetValue(1);
                string rol = dataReader.GetValue(2).ToString();
                string funcionalidad = dataReader.GetValue(3).ToString();

                // Si ya existe un rol con ese id, se le agrega la funcionalidad
                // sino, creo el rol
                if (listaDeRxF.Any(RxF => RxF.id.Equals(id)))
                {
                    foreach (var RxF in listaDeRxF)
                    {
                        if (RxF.id.Equals(id))
                        {
                            RxF.funcionalidades.Add(funcionalidad);
                        }
                    }
                }
                else
                {
                    var RxF = new RolxFuncionalidades();
                    RxF.id = id;
                    RxF.habilitado = habilitado;
                    RxF.rol = rol;
                    RxF.funcionalidades.Add(funcionalidad);
                    listaDeRxF.Add(RxF);
                }

            }

            return listaDeRxF;
        }

    }
}
