using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class AltaYModificacion : Utils
    {

        bool estoyEnModificacion;
        RolxFuncionalidades rol;

        public AltaYModificacion()
        {
            InitializeComponent();
            habilitado.Visible = false;
            estoyEnModificacion = false;
            confirmar.Text = "Crear";
            conectarseABaseDeDatosOfertas();
            buscarFuncionalidadesEnBaseDeDatos();
        }

        public AltaYModificacion(RolxFuncionalidades RxF)
        {
            InitializeComponent();
            estoyEnModificacion = true;
            nombre.Text = RxF.rol;
            habilitado.Visible = true;
            habilitado.Checked = RxF.habilitado;
            rol = RxF;
            conectarseABaseDeDatosOfertas();
            buscarFuncionalidadesEnBaseDeDatos();
            RxF.funcionalidades.ForEach(funcionalidad => marcarCheckBoxFuncionalidad(funcionalidad));
        }

        private void marcarCheckBoxFuncionalidad(string funcionalidad)
        {
            List<string> funcionalidades = funcionalidadesASeleccionar.Items.Cast<string>().ToList();
            int indiceAMarcar = funcionalidades.FindIndex(f => f.Equals(funcionalidad));
            funcionalidadesASeleccionar.SetItemCheckState(indiceAMarcar, CheckState.Checked);
        }

        private void buscarFuncionalidadesEnBaseDeDatos()
        {
            SqlCommand seleccionarFuncionalidades = new SqlCommand("SELECT descripcion FROM funcionalidad", dbOfertas);
            SqlDataReader dataReader = seleccionarFuncionalidades.ExecuteReader();

            while (dataReader.Read())
            {
                string funcionalidad = dataReader.GetValue(0).ToString();
                funcionalidadesASeleccionar.Items.Add(funcionalidad, false);
            }

            dataReader.Close();
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            //TODO: validaciones sobre campos
            if (estoyEnModificacion)
            {
                //TODO: Si no modifique nada
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
            else 
            {
                if (crearRol())
                {
                    MessageBox.Show("El rol se creo exitosamente");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No se ha podido crear el rol correctamente");
                }
            }
        }

        private bool crearRol()
        {
            SqlCommand insertarNuevoRol =
                new SqlCommand(string.Format("INSERT INTO rol (rol_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", nombre.Text), dbOfertas);

            SqlDataReader dataReader = insertarNuevoRol.ExecuteReader();

            if (dataReader.Read())
            {
                string idRol = dataReader.GetValue(0).ToString();
                dataReader.Close();
                SqlDataReader dataReaderFuncionalidades = insertarFuncionalidadesParaRol(idRol);
                if (dataReaderFuncionalidades.RecordsAffected > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private bool modificarRol()
        {
            if (!nombre.Text.Equals(rol.rol)) // Si se modifico el nombre del rol
            {
                SqlCommand modificarRol = 
                    new SqlCommand(string.Format("UPDATE rol SET rol_nombre='{0}' WHERE rol_id={1}; ", nombre.Text, rol.id), dbOfertas);

                if (modificarRol.ExecuteReader().RecordsAffected <= 0)
                    return false;
            }

            var funcionalidadesSeleccionadas = funcionalidadesASeleccionar.CheckedItems.Cast<string>().ToList();
            if (!(funcionalidadesSeleccionadas.All(rol.funcionalidades.Contains)
                && funcionalidadesSeleccionadas.Count == rol.funcionalidades.Count)) // Si se modifico alguna funcionalidad
            {
                SqlCommand eliminarFuncionalidadesViejas = 
                    new SqlCommand(string.Format("DELETE FROM funcionalidadxrol WHERE rol_id={0};", rol.id), dbOfertas);
                if (eliminarFuncionalidadesViejas.ExecuteReader().RecordsAffected <= 0)
                    return false;

                if (insertarFuncionalidadesParaRol(rol.id.ToString()).RecordsAffected <= 0)
                    return false;
            }

            //TODO: Si se habilito y no estaba habilitado o viceversa
                //Deshabilitar/Hablilitar
                //Desvincular usuarios segun corresponda

            return true;
        }

        private SqlDataReader insertarFuncionalidadesParaRol(string idRol)
        {
            List<int> funcionalidadesSeleccionadas = funcionalidadesASeleccionar.CheckedIndices.Cast<int>().ToList();

            //TODO: si no selecciona ninguna
            string valoresAInsertarEnFuncionalidadxRol = "";
            foreach (var funcionalidad in funcionalidadesSeleccionadas)
            {
                valoresAInsertarEnFuncionalidadxRol += "(" + idRol.ToString() + "," + (funcionalidad + 1).ToString() + "),";
            }
            valoresAInsertarEnFuncionalidadxRol = valoresAInsertarEnFuncionalidadxRol.Remove(valoresAInsertarEnFuncionalidadxRol.Length - 1);

            SqlCommand insertarFuncionalidadesxRol =
                new SqlCommand("INSERT INTO funcionalidadxrol (rol_id, funcionalidad_id) VALUES " + valoresAInsertarEnFuncionalidadxRol, dbOfertas);

            SqlDataReader dataReader = insertarFuncionalidadesxRol.ExecuteReader();
            return dataReader;
        }
    }
}
