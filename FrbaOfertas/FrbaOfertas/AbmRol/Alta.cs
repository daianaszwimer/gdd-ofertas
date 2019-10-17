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
    public partial class Alta : Utils
    {

        public Alta()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
            buscarFuncionalidadesEnBaseDeDatos();
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

        private void confirmarAlta_Click(object sender, EventArgs e)
        {
            SqlCommand insertarNuevoRol = new SqlCommand(string.Format("INSERT INTO rol (rol_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", nombre.Text), dbOfertas);
            SqlDataReader dataReader = insertarNuevoRol.ExecuteReader();

            if (dataReader.Read())
            {
                string idRol = dataReader.GetValue(0).ToString();
                dataReader.Close();

                insertarFuncionalidadesParaRol(idRol);

            }
            else
            {
                MessageBox.Show("No se pudo guardar el Rol");
                dataReader.Close();
            }
            
        }

        private void insertarFuncionalidadesParaRol(string idRol)
        {
            List<int> funcionalidadesSeleccionadas = funcionalidadesASeleccionar.CheckedIndices.Cast<int>().ToList();

            string valoresAInsertarEnFuncionalidadxRol = "";
            foreach (var funcionalidad in funcionalidadesSeleccionadas)
            {
                valoresAInsertarEnFuncionalidadxRol += "(" + idRol.ToString() + "," + (funcionalidad + 1).ToString() + "), ";
            }
            valoresAInsertarEnFuncionalidadxRol = valoresAInsertarEnFuncionalidadxRol.Remove(valoresAInsertarEnFuncionalidadxRol.Length - 2);

            SqlCommand insertarFuncionalidadesxRol =
                new SqlCommand("INSERT INTO funcionalidadxrol (rol_id, funcionalidad_id) VALUES " + valoresAInsertarEnFuncionalidadxRol, dbOfertas);

            SqlDataReader dataReader = insertarFuncionalidadesxRol.ExecuteReader();

            if (dataReader.RecordsAffected > 0)
            {
                MessageBox.Show("Alta realizada correctamente");
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se pudieron guardar las funcionalidades asociadas a ese Rol");
            }
        }

    }
}
