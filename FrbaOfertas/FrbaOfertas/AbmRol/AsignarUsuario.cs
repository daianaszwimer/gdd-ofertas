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
    public partial class AsignarUsuario : BarraDeOpciones
    {
        object[] rol;

        public AsignarUsuario(object[] rol)
        {
            InitializeComponent();
            desactivarErrores();
            descripcionRol.Text = rol[1].ToString();
            this.rol = rol;
        }

        private void desactivarErrores()
        {
            errorUsuario.Clear();
        }

        private bool validacionCampos()
        {
            bool camposOk = true;
            if (string.IsNullOrWhiteSpace(usuario.Text))
            {
                errorUsuario.SetError(usuario, "Debe seleccionar un usuario o agregar uno nuevo");
                camposOk = false;
            }
            return camposOk;
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            (new AbmRol.ListadoUsuarios(agregarUsuario)).Show();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            (new AbmRol.AltaUsuario(agregarUsuario)).Show();
        }

        private void asignar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                SqlCommand insertarRol =
                    new SqlCommand(
                        string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario (rolesxusuario_id_usuario, rolesxusuario_id_rol) VALUES('{0}',{1})",
                        usuario.Text, rol[0].ToString()), Helper.dbOfertas);

                SqlDataReader dataReaderRol = Helper.realizarConsultaSQL(insertarRol);
                if (dataReaderRol != null)
                {
                    if (dataReaderRol.RecordsAffected == 0)
                    {
                        dataReaderRol.Close();
                        MessageBox.Show("El rol: " + rol[1].ToString() + " no se pudo asignar\n al usuario: " + usuario.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dataReaderRol.Close();
                        MessageBox.Show("El rol: " + rol[1].ToString() + " se asigno\nal usuario: " + usuario.Text + " exitosamente", "Asignar Rol a Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        public void agregarUsuario(string username)
        {
            usuario.Text = username;
        }

    }
}
