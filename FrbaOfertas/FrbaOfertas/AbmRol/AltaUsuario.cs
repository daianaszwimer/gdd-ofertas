using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class AltaUsuario : BarraDeOpciones
    {
        Action<string> agregarUsuario;

        public AltaUsuario(Action<string> agregarUsuario)
        {
            InitializeComponent();
            desactivarErrores();
            this.agregarUsuario = agregarUsuario;
        }

        private void desactivarErrores()
        {
            errorUser.Clear();
            errorPass.Clear();
        }

        private bool validacionCampos()
        {
            bool camposOk = true;
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                errorUser.SetError(username, "Campo Obligatorio");
                camposOk = false;
            }

            if (string.IsNullOrWhiteSpace(password.Text))
            {
                errorPass.SetError(password, "Campo Obligatorio");
                camposOk = false;
            }
            return camposOk;
        }

        private void crear_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                if (Helper.insertarUsuario(username.Text, password.Text))
                {
                    MessageBox.Show("Usuario creado exitosamente", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    agregarUsuario(username.Text);
                    this.Close();
                }
            }
        }
    }
}
