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
        public Modificacion(RolxFuncionalidades RxF)
        {
            nombre.Text = RxF.rol;
            habilitado.Visible = true;
            habilitado.Checked = RxF.habilitado;
            rol = RxF;
            RxF.funcionalidades.ForEach(funcionalidad => marcarCheckBoxFuncionalidad(funcionalidad));
        }

        private void marcarCheckBoxFuncionalidad(string funcionalidad)
        {
            List<string> funcionalidades = funcionalidadesASeleccionar.Items.Cast<string>().ToList();
            int indiceAMarcar = funcionalidades.FindIndex(f => f.Equals(funcionalidad));
            funcionalidadesASeleccionar.SetItemCheckState(indiceAMarcar, CheckState.Checked);
        }

        private bool modificarRol()
        {
            if (!nombre.Text.Equals(rol.rol)) // Si se modifico el nombre del rol
            {
                SqlCommand modificarRol =
                    new SqlCommand(string.Format("UPDATE rol SET rol_nombre='{0}' WHERE rol_id={1}; ", nombre.Text, rol.id), dbOfertas);

                SqlDataReader modificarRolDataReader = modificarRol.ExecuteReader();
                if (modificarRolDataReader.RecordsAffected <= 0)
                {
                    modificarRolDataReader.Close();
                    return false;
                }
                modificarRolDataReader.Close();    
            }

            var funcionalidadesSeleccionadas = funcionalidadesASeleccionar.CheckedItems.Cast<string>().ToList();
            if (!(funcionalidadesSeleccionadas.All(rol.funcionalidades.Contains)
                && funcionalidadesSeleccionadas.Count == rol.funcionalidades.Count)) // Si se modifico alguna funcionalidad
            {
                SqlCommand eliminarFuncionalidadesViejas =
                    new SqlCommand(string.Format("DELETE FROM funcionalidadxrol WHERE rol_id={0};", rol.id), dbOfertas);

                SqlDataReader eliminarFuncionalidadesViejasDataReader = eliminarFuncionalidadesViejas.ExecuteReader();
                if (eliminarFuncionalidadesViejasDataReader.RecordsAffected <= 0)
                {
                    eliminarFuncionalidadesViejasDataReader.Close();
                    return false;
                }
                eliminarFuncionalidadesViejasDataReader.Close();

                SqlDataReader insertarDataReader = insertarFuncionalidadesParaRol(rol.id.ToString());
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
