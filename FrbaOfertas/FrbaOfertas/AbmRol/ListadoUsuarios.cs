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
    public partial class ListadoUsuarios : BajaYModificacionUsuario.Form1
    {
        Action<string> agregarUsuario;

        public ListadoUsuarios(Action<string> agregarUsuario)
        {
            InitializeComponent();
            modificar.Visible = false;
            eliminar.Visible = false;
            confirmar.Visible = false;
            tablaDeResultados.SelectionChanged += tablaDeResultados_SelectionChanged;
            this.agregarUsuario = agregarUsuario;
        }

        override protected void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaDeResultados.SelectedRows.Count == 0)
                confirmar.Visible = false;
            else
                confirmar.Visible = true;
        }

        override protected void buscar_Click(object sender, EventArgs e)
        {
            usuariosDataSet.Clear();
            string consultaUsuarios =
                "SELECT usuario_username AS 'Nombre de usuario', usuario_password " +
                "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Usuario " +
                "LEFT OUTER JOIN NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario ON rolesxusuario_id_usuario=usuario_username WHERE usuario_eliminado=0 AND rolesxusuario_id_usuario is null";

            string usernameAFiltrar = username.Text;

            if (!string.IsNullOrWhiteSpace(usernameAFiltrar))
            {
                consultaUsuarios += string.Format(" AND usuario_username LIKE '%{0}%'", usernameAFiltrar);
            }

            SqlDataAdapter usuariosDataAdapter = new SqlDataAdapter(consultaUsuarios, Helper.dbOfertas);
            usuariosDataAdapter.Fill(usuariosDataSet);
            tablaDeResultados.DataSource = usuariosDataSet.Tables[0];
            tablaDeResultados.Columns[1].Visible = false;
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            agregarUsuario(
                tablaDeResultados.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }
    }
}
