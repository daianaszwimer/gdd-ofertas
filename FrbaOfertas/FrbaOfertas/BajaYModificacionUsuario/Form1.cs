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

namespace FrbaOfertas.BajaYModificacionUsuario
{
    public partial class Form1 : BarraDeOpciones
    {
        protected DataSet usuariosDataSet = new DataSet();

        public Form1()
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
            usuariosDataSet.Clear();
        }

        protected virtual void buscar_Click(object sender, EventArgs e)
        {
            usuariosDataSet.Clear();
            string consultaUsuarios =
                "SELECT usuario_username AS 'Nombre de usuario', usuario_password " +
                "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Usuario WHERE usuario_eliminado=0";

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

        private void modificar_Click(object sender, EventArgs e)
        {
            object[] usuario = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            (new BajaYModificacionUsuario.Modificacion(usuario)).Show();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            object[] usuario = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            string id = usuario[0].ToString();
            SqlCommand eliminarUsuario = new SqlCommand("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Usuario SET usuario_eliminado=1 WHERE usuario_username='" + id + "'", Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(eliminarUsuario);
            if (dataReader != null)
            {
                if (dataReader.RecordsAffected != 0)
                {
                    MessageBox.Show("Usuario eliminado exitosamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usuariosDataSet.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataReader.Close();
            }
        }

    }
}
