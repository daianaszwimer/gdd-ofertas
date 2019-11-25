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

namespace FrbaOfertas
{
    public partial class RegistrarUsuario : Form
    {
        bool camposOk = true;

        public RegistrarUsuario()
        {
            InitializeComponent();
            Helper.conectarseABaseDeDatosOfertas();
            rol.DataSource = obtenerRolesPosibles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (camposObligatorios())
            {
                if (Helper.usuarioUnico(this, username.Text))
                {
                    Button confirmar = (Button)sender;
                    rol.Enabled = false;
                    confirmar.Enabled = false;

                    if (rol.Text == "cliente")
                        AddFormInPanel(new RegistroUsuario.AltaCliente(this, username.Text, password.Text));
                    if (rol.Text == "proveedor")
                        AddFormInPanel(new RegistroUsuario.AltaProveedor(this, username.Text, password.Text));
                }
                else
                {
                    errorUsername.SetError(username, "Username ya existe");

                }
           }
        }


       
        
        private void AddFormInPanel(object formHijo)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            if (fh.Size.Height > Size.Height || fh.Size.Width > Size.Width)
            {
                this.Size = new Size(fh.Width + button1.Size.Width, fh.Height + button1.Size.Height);
            }
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;

            fh.Show();
        }

        private bool camposObligatorios()
        {
            bool camposOk = true;
            if (string.IsNullOrEmpty(username.Text))
            {
                errorUsername.SetError(username, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrEmpty(password.Text))
            {
                errorPassword.SetError(password, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrEmpty(rol.Text))
            {
                errorRol.SetError(rol, "Campo Obligatorio");
                camposOk = false;
            }
            return camposOk;
        }

        private void desactivarErrores()
        {
            errorUsername.Clear();
            errorPassword.Clear();
            errorRol.Clear();
        }

        private List<String> obtenerRolesPosibles()
        {
            List<String> rolesPosibles = new List<string>();
            SqlCommand seleccionarRolesPosibles = 
                new SqlCommand(
                    string.Format("SELECT rol_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Rol WHERE rol_habilitado=1 AND rol_eliminado=0 AND rol_nombre!='administrativo' AND rol_nombre NOT LIKE 'admin%' "), Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(seleccionarRolesPosibles);
            if (dataReader != null)
            {
                rolesPosibles.Add("");
                while (dataReader.Read())
                {
                    string rol = dataReader.GetValue(0).ToString();
                    rolesPosibles.Add(rol);
                }
                dataReader.Close();
            }
            return rolesPosibles;
        }


    }
}
