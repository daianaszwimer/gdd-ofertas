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
            nombre.Text = rol[1].ToString();
            habilitado.Visible = true;
            habilitado.Checked = bool.Parse(rol[3].ToString());
            this.rol = rol;
            marcarCheckBoxFuncionalidades();
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
                    new SqlCommand(string.Format("UPDATE rol SET rol_nombre='{0}' WHERE rol_id={1}; ", nombre.Text, rol[0].ToString()), Helper.dbOfertas);

                SqlDataReader modificarRolDataReader = modificarRol.ExecuteReader();
                if (modificarRolDataReader.RecordsAffected <= 0)
                {
                    modificarRolDataReader.Close();
                    return false;
                }
                modificarRolDataReader.Close();    
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
                    new SqlCommand(string.Format("DELETE FROM funcionalidadxrol WHERE rol_id={0};", rol[0].ToString()), Helper.dbOfertas);

                SqlDataReader eliminarFuncionalidadesViejasDataReader = eliminarFuncionalidadesViejas.ExecuteReader();
                if (eliminarFuncionalidadesViejasDataReader.RecordsAffected <= 0)
                {
                    eliminarFuncionalidadesViejasDataReader.Close();
                    return false;
                }
                eliminarFuncionalidadesViejasDataReader.Close();

                SqlDataReader insertarDataReader = insertarFuncionalidadesParaRol(rol[0].ToString());
                if (insertarDataReader.RecordsAffected <= 0)
                {
                    insertarDataReader.Close();
                    return false;
                }
                insertarDataReader.Close();
            }

            //TODO: [D] Si se habilito y no estaba habilitado o viceversa
            //Deshabilitar/Hablilitar
            //Desvincular usuarios segun corresponda

            return true;
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            if (modificarRol())
            {
                MessageBox.Show("El rol se modifico exitosamente");
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se ha podido modificar el rol correctamente");
            }
        }
    }
}
