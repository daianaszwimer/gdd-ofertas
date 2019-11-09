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
    public abstract partial class AltaYModificacion : Utils
    {

        protected RolxFuncionalidades rol;

        public AltaYModificacion()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
            buscarFuncionalidadesEnBaseDeDatos();
        }

        /*public AltaYModificacion()
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
        }*/

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

        /*private void confirmar_Click(object sender, EventArgs e)
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
        }*/

        protected SqlDataReader insertarFuncionalidadesParaRol(string idRol)
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

        abstract protected void confirmar_Click(object sender, EventArgs e);

    }
}
