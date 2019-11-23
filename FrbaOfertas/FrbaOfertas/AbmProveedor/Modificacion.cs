using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class Modificacion : AltaYModificacion
    {
        private object[] proveedor;

        public Modificacion(object[] proveedor)
        {
            InitializeComponent();

            razonSocial.Text = proveedor[1].ToString();
            CUIT.Text = proveedor[2].ToString();
            localidad.Text = proveedor[5].ToString();
            calle.Text = proveedor[6].ToString();
            piso.Text = proveedor[7].ToString();
            depto.Text = proveedor[8].ToString();
            codigoPostal.Text = proveedor[9].ToString();
            telefono.Text = proveedor[10].ToString();
            mail.Text = proveedor[11].ToString();
            rubro.Text = proveedor[13].ToString();
            nombre.Text = proveedor[14].ToString();
            habilitado.Checked = bool.Parse(proveedor[15].ToString());
        }

        private bool modificarProveedor()
        {
            /*if (!nombre.Text.Equals(rol.rol)) // Si se modifico el nombre del rol
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
            */
            return true;
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            if (modificarProveedor())
            {
                MessageBox.Show("El proveedor se modifico exitosamente");
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se ha podido modificar el proveedor correctamente");
            }
        }
    }
}
