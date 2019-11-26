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
    public partial class Modificacion : BarraDeOpciones
    {
        private object[] usuario;

        public Modificacion(object[] usuario)
        {
            InitializeComponent();
            usernameTextBox.Text = usuario[0].ToString();
            this.usuario = usuario;
            desactivarErrores();
        }

        private void desactivarErrores()
        {
            errorPassword.Clear();
        }

        private bool validacionCampos()
        {
            bool camposOk = true;

            if (string.IsNullOrWhiteSpace(passwordNueva.Text))
            {
                errorPassword.SetError(passwordNueva, "Este campo no puede estar vacio");
                camposOk = false;
            }

            if (usuario[1].ToString().Equals(Helper.encriptarConSHA256(passwordNueva.Text)))
            {
                errorPassword.SetError(passwordNueva, "La password nueva no puede \n ser igual a la anterior");
                camposOk = false;
            }
            return camposOk;
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                SqlCommand actualizarPassword =
                    new SqlCommand(
                        string.Format(
                            "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Usuario SET usuario_password='{0}'" +
                            "WHERE usuario_username='{1}'",
                            Helper.encriptarConSHA256(passwordNueva.Text), usuario[0].ToString()), Helper.dbOfertas);
                SqlDataReader dataReader = Helper.realizarConsultaSQL(actualizarPassword);
                if (dataReader != null)
                {
                    if (dataReader.RecordsAffected > 0)
                    {
                        MessageBox.Show("Contraseña actualizada exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo actualizar la contraseña", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataReader.Close();
                }
            }
        }
    }
}
