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
        List<RolYFuncionalidades> rolesYFuncionalidades = new List<RolYFuncionalidades>();

        public Listado()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
           
            table.Columns.Add("Rol", typeof(string));
            table.Columns.Add("Funcionalidades", typeof(string));

            /*table.Rows.Add("Cliente", "ABM Cliente, ABM Proveedor");
            table.Rows.Add("Proveedor", "Compra de oferta");*/

            tablaDeResultados.DataSource = table;
        }

        private void mostrarTodo_Click(object sender, EventArgs e)
        {
            SqlCommand seleccionarTodosLosRoles = 
                new SqlCommand("SELECT r.rol_nombre AS Rol, ISNULL(f.descripcion, '-') AS Funcionalidades FROM rol r LEFT JOIN funcionalidadxrol fxr ON fxr.rol_id = r.rol_id LEFT JOIN funcionalidad f ON fxr.funcionalidad_id = f.id GROUP BY r.rol_nombre, f.descripcion", dbOfertas);
            SqlDataReader dataReader = seleccionarTodosLosRoles.ExecuteReader();

            while (dataReader.Read())
            {
                string rol = dataReader.GetValue(0).ToString();
                string funcionalidad = dataReader.GetValue(1).ToString();

                if (rolesYFuncionalidades.Any(ryf => ryf.rol.Equals(rol)))
                {
                    foreach (var ryF in rolesYFuncionalidades)
                    {
                        if (ryF.rol.Equals(rol))
                        {
                            ryF.funcionalidades.Add(funcionalidad);
                        }
                    }
                }
                else
                {
                    var ryf2 = new RolYFuncionalidades();
                    ryf2.rol = rol;
                    ryf2.funcionalidades.Add(funcionalidad);
                    rolesYFuncionalidades.Add(ryf2);
                }
                
                //funcionalidadesASeleccionar.Items.Add(funcionalidad, false);
            }

            dataReader.Close();

            foreach (var ryf in rolesYFuncionalidades)
            {
                string funcionalidades = "";
                foreach (var f in ryf.funcionalidades)
                {
                    funcionalidades += ", ";
                    funcionalidades += f;
                }
                funcionalidades = funcionalidades.Remove(funcionalidades.Length - 2);

                table.Rows.Add(ryf.rol, funcionalidades);
            }
        }

    }

    public class RolYFuncionalidades
    {
        public string rol { get; set; }
        public List<string> funcionalidades { get; set; }

        public RolYFuncionalidades()
        {
            funcionalidades = new List<string>();
        }
    }
}
