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
           
            table.Columns.Add("Rol", typeof(string));
            table.Columns.Add("Funcionalidades", typeof(string));

            tablaDeResultados.DataSource = table;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            table.Clear();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            string consultaRoles = 
                "SELECT r.rol_nombre AS Rol, ISNULL(f.descripcion, '-') AS Funcionalidades " +
                    "FROM rol r LEFT JOIN funcionalidadxrol fxr ON fxr.rol_id = r.rol_id " +
                               "LEFT JOIN funcionalidad f ON fxr.funcionalidad_id = f.id";

            string rolAFiltrar = rolTextBox.Text;
            object funcionalidadSeleccionada = funcionalidadesComboBox.SelectedItem;

            if (!string.IsNullOrWhiteSpace(rolAFiltrar) && funcionalidadSeleccionada != null)
            {
                consultaRoles += string.Format(" WHERE r.rol_nombre LIKE '%{0}%' AND f.descripcion = '{1}'", rolAFiltrar, funcionalidadSeleccionada);
            }
            else if (string.IsNullOrWhiteSpace(rolAFiltrar) && funcionalidadSeleccionada != null)
            {
                consultaRoles += string.Format(" WHERE f.descripcion = '{0}'", funcionalidadSeleccionada);
            }
            else if (!string.IsNullOrWhiteSpace(rolAFiltrar) && funcionalidadSeleccionada == null)
            {
                consultaRoles += string.Format(" WHERE r.rol_nombre LIKE '%{0}%'", rolAFiltrar);
            }

            SqlCommand seleccionarRoles = new SqlCommand(consultaRoles, dbOfertas);
            SqlDataReader dataReader = seleccionarRoles.ExecuteReader();

            rolesYfuncionalidades = convertirRespuestaAListaDeRolesYFuncionalidades(dataReader);

            dataReader.Close();

            foreach (var RxF in rolesYfuncionalidades)
            {
                string funcionalidades = string.Join(", ", RxF.funcionalidades);
                table.Rows.Add(RxF.rol, funcionalidades);
            }
        }

        private List<RolxFuncionalidades> convertirRespuestaAListaDeRolesYFuncionalidades(SqlDataReader dataReader)
        {
            List<RolxFuncionalidades> listaDeRxF = new List<RolxFuncionalidades>();

            while (dataReader.Read())
            {
                string rol = dataReader.GetValue(0).ToString();
                string funcionalidad = dataReader.GetValue(1).ToString();

                if (listaDeRxF.Any(RxF => RxF.rol.Equals(rol)))
                {
                    foreach (var RxF in listaDeRxF)
                    {
                        if (RxF.rol.Equals(rol))
                        {
                            RxF.funcionalidades.Add(funcionalidad);
                        }
                    }
                }
                else
                {
                    var RxF = new RolxFuncionalidades();
                    RxF.rol = rol;
                    RxF.funcionalidades.Add(funcionalidad);
                    listaDeRxF.Add(RxF);
                }

            }

            return listaDeRxF;
        }

    }

    public class RolxFuncionalidades
    {
        public string rol { get; set; }
        public List<string> funcionalidades { get; set; }

        public RolxFuncionalidades()
        {
            funcionalidades = new List<string>();
        }
    }
}
