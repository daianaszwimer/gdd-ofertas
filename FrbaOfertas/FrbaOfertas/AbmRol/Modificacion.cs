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
    public partial class Modificacion : AltaYModificacion
    {
        private object[] rol;

        public Modificacion(object[] rol)
        {
            InitializeComponent();
            buscarFuncionalidadesEnBaseDeDatos();
            nombre.Text = rol[1].ToString();
            habilitado.Visible = true;
            habilitado.Checked = bool.Parse(rol[3].ToString());
            this.rol = rol;
            marcarCheckBoxFuncionalidades();
            desactivarErrores();
        }

        private void marcarCheckBoxFuncionalidades()
        {
            if (!rol[2].ToString().Equals("-"))
            {
                List<string> funcionalidadesAMarcar = new List<string>();

                if (rol[2].ToString().Contains(","))
                {
                    funcionalidadesAMarcar.AddRange(rol[2].ToString().Split(new string[] { ", " }, StringSplitOptions.None));
                } 
                else
                    funcionalidadesAMarcar.Add(rol[2].ToString());

                List<string> funcionalidades = funcionalidadesASeleccionar.Items.Cast<string>().ToList();

                foreach (var f in funcionalidadesAMarcar)
                {
                    int indiceAMarcar = funcionalidades.FindIndex(func => func.Equals(f));
                    funcionalidadesASeleccionar.SetItemCheckState(indiceAMarcar, CheckState.Checked);
                }
            }
        }

        private bool modificarRol()
        {
            if (!nombre.Text.Equals(rol[1].ToString())) // Si se modifico el nombre del rol
            {
                SqlCommand modificarRol =
                    new SqlCommand(string.Format("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Rol SET rol_nombre='{0}' WHERE rol_id={1}; ", nombre.Text, rol[0].ToString()), Helper.dbOfertas);
                
                SqlDataReader modificarRolDataReader = Helper.realizarConsultaSQL(modificarRol);
                if (modificarRolDataReader != null)
                {
                    if (modificarRolDataReader.RecordsAffected <= 0)
                    {
                        modificarRolDataReader.Close();
                        return false;
                    }
                    modificarRolDataReader.Close();
                }
            }

            List<string> funcionalidadesAMarcar = new List<string>();
            if (!rol[2].ToString().Equals("-"))
            {
                if (rol[2].ToString().Contains(","))
                {
                    funcionalidadesAMarcar.AddRange(rol[2].ToString().Split(new string[] { ", " }, StringSplitOptions.None));
                }
                else
                    funcionalidadesAMarcar.Add(rol[2].ToString());
            }

            var funcionalidadesSeleccionadas = funcionalidadesASeleccionar.CheckedItems.Cast<string>().ToList();
            if (!(funcionalidadesSeleccionadas.All(funcionalidadesAMarcar.Contains)
                && funcionalidadesSeleccionadas.Count == funcionalidadesAMarcar.Count)) // Si se modifico alguna funcionalidad
            {
                SqlCommand eliminarFuncionalidadesViejas =
                    new SqlCommand(
                        string.Format(
                            "DELETE FROM NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol WHERE funcionalidadxrol_id_rol={0};", 
                            rol[0].ToString()), Helper.dbOfertas);

                SqlDataReader eliminarFuncionalidadesViejasDataReader = Helper.realizarConsultaSQL(eliminarFuncionalidadesViejas);
                if (eliminarFuncionalidadesViejas != null)
                {
                    if (eliminarFuncionalidadesViejasDataReader.RecordsAffected <= 0)
                    {
                        eliminarFuncionalidadesViejasDataReader.Close();
                        return false;
                    }
                    eliminarFuncionalidadesViejasDataReader.Close();

                    SqlDataReader insertarDataReader = insertarFuncionalidadesParaRol(rol[0].ToString());
                    if (insertarDataReader != null)
                    {
                        if (insertarDataReader.RecordsAffected <= 0)
                        {
                            insertarDataReader.Close();
                            return false;
                        }
                        insertarDataReader.Close();
                    }
                    else
                        return false;
                }
            }

            //TODO: [D] Si se habilito y no estaba habilitado o viceversa
            //Deshabilitar/Hablilitar
            //Desvincular usuarios segun corresponda
            if (habilitado.Checked != bool.Parse(rol[3].ToString())) // Si se modifico este checkbox
            {
                if (habilitado.Checked) // Actualizo el rol a habilitado
                {
                    SqlCommand modificarRol =
                    new SqlCommand(
                        string.Format(
                            "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Rol SET rol_habilitado={0} WHERE rol_id={1}; ", habilitado.Checked?"1":"0", rol[0].ToString()), Helper.dbOfertas);

                    SqlDataReader modificarRolDataReader = Helper.realizarConsultaSQL(modificarRol);
                    if (modificarRolDataReader != null)
                    {
                        if (modificarRolDataReader.RecordsAffected <= 0)
                        {
                            modificarRolDataReader.Close();
                            return false;
                        }
                        modificarRolDataReader.Close();
                    }
                }
                else // Actualizo el rol a deshabilitado y saco el rol a los usuarios que lo posean
                {
                    SqlCommand modificarRol =
                    new SqlCommand(
                        string.Format(
                            "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Rol SET rol_habilitado={0} WHERE rol_id={1}; ", habilitado.Checked ? "1" : "0", rol[0].ToString()), Helper.dbOfertas);

                    SqlDataReader modificarRolDataReader = Helper.realizarConsultaSQL(modificarRol);
                    if (modificarRolDataReader != null)
                    {
                        if (modificarRolDataReader.RecordsAffected <= 0)
                        {
                            modificarRolDataReader.Close();
                            return false;
                        }
                        modificarRolDataReader.Close();
                    }

                    SqlCommand eliminarRolEnUsuarios =
                    new SqlCommand(
                        string.Format(
                            "DELETE FROM NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario WHERE rolesxusuario_id_rol={0}; ", rol[0].ToString()), Helper.dbOfertas);

                    SqlDataReader eliminarRolEnUsuariosDataReader = Helper.realizarConsultaSQL(eliminarRolEnUsuarios);
                    if (eliminarRolEnUsuariosDataReader != null)
                    {
                        if (eliminarRolEnUsuariosDataReader.RecordsAffected <= 0)
                        {
                            eliminarRolEnUsuariosDataReader.Close();
                            return false;
                        }
                        eliminarRolEnUsuariosDataReader.Close();
                    }

                }
            }

            return true;
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                if (modificarRol())
                {
                    MessageBox.Show("El rol se modifico exitosamente", "Rol modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No se ha podido modificar el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
