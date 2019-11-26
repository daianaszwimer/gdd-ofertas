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

namespace FrbaOfertas.CambiarPassword
{
    public partial class Form1 : BarraDeOpciones
    {
        public Form1()
        {
            InitializeComponent();
            desactivarErrores();
        }

        private void desactivarErrores()
        {
            errorPasswordAnterior.Clear();
            errorPasswordNueva.Clear();
        }

        private bool validacionCampos()
        {
            bool camposOk = true;
            SqlCommand chequearSiLaPasswordAnteriorEsCorrecta =
                new SqlCommand(
                    string.Format(
                        "SELECT usuario_username FROM NO_LO_TESTEAMOS_NI_UN_POCO.Usuario " +
                        "WHERE usuario_username='{0}' AND usuario_password='{1}'", Helper.usuarioActual ,Helper.encriptarConSHA256(passwordAnterior.Text)), Helper.dbOfertas);
            SqlDataReader dataReaderUsuario = Helper.realizarConsultaSQL(chequearSiLaPasswordAnteriorEsCorrecta);
            if (dataReaderUsuario != null)
            {
                if (!dataReaderUsuario.HasRows)
                {
                    errorPasswordAnterior.SetError(passwordAnterior, "La password insertada no es la anterior");
                    camposOk = false;
                }

                dataReaderUsuario.Close();

                if (passwordAnterior.Text.Equals(passwordNueva.Text))
                {
                    errorPasswordNueva.SetError(passwordNueva, "La password nueva no puede \n ser igual a la anterior");
                    camposOk = false;
                }
                return camposOk;
            }
            else
                return false;
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
                            Helper.encriptarConSHA256(passwordNueva.Text), Helper.usuarioActual), Helper.dbOfertas);
                SqlDataReader dataReader = Helper.realizarConsultaSQL(actualizarPassword);
                if (dataReader != null)
                {
                    if(dataReader.RecordsAffected > 0)
                    {
                        MessageBox.Show("Contraseña actualizada exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Helper.cerrarSesion();
                    }
                    else
                        MessageBox.Show("No se pudo actualizar la contraseña", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataReader.Close();
                }
            }
        }
    }
}
