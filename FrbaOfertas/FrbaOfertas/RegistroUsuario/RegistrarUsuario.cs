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
    public partial class RegistrarUsuario : BarraDeOpciones
    {
        string elUsername;
        bool usuarioOk = false;
        bool camposOk = true;

        public RegistrarUsuario()
        {
            InitializeComponent();
            rol.DataSource = obtenerRolesPosibles();
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            crearUsuario();
            if (rol.Text == "cliente")
                AddFormInPanel(new RegistroUsuario.AltaCliente());
            if (rol.Text == "proveedor")
                AddFormInPanel(new RegistroUsuario.AltaProveedor());
        }


        private void crearUsuario()
        {
            errorUsername.Clear();
            errorPassword.Clear();
            errorRol.Clear();
            camposOk = camposObligatorios();
            if (camposOk)
            {
                if (this.usuarioUnico()) 
                {
                    SqlCommand insertarNuevoUsuario = 
                        new SqlCommand(
                            string.Format(
                            "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Usuario (usuario_username, usuario_password) VALUES ('{0}','{1}')", username.Text, Helper.encriptarConSHA256(password.Text)), Helper.dbOfertas);
                    
                    SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoUsuario);
                    if (dataReader != null)
                    {
                        elUsername = username.Text;
                        dataReader.Close();
                    }
                }
                else
                {
                    errorUsername.SetError(username, "Username ya existe");
                    this.Show();
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
            if (username.Text == string.Empty)
            {
                errorUsername.SetError(username, "Campo Obligatorio");
                camposOk = false;
            }
            if (password.Text == string.Empty)
            {
                errorPassword.SetError(password, "Campo Obligatorio");
                camposOk = false;
            }
            if (rol.Text == string.Empty)
            {
                errorRol.SetError(rol, "Campo Obligatorio");
                camposOk = false;
            }
            return camposOk;
        }


        private bool usuarioUnico()
        {
            SqlCommand chequearExistenciaUsername = 
                new SqlCommand(
                    string.Format("SELECT usuario_username FROM NO_LO_TESTEAMOS_NI_UN_POCO.Usuario WHERE usuario_username='{0}'", username.Text), Helper.dbOfertas);
            SqlDataReader dataReaderUsuario = Helper.realizarConsultaSQL(chequearExistenciaUsername);
            if (dataReaderUsuario != null)
            {
                usuarioOk = !dataReaderUsuario.HasRows;
                dataReaderUsuario.Close();
            }
            return usuarioOk;
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
