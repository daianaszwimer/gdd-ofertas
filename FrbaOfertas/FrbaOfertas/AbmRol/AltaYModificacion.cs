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
    public abstract partial class AltaYModificacion : Form
    {
        public AltaYModificacion()
        {
            InitializeComponent();
            buscarFuncionalidadesEnBaseDeDatos();
        }

        private void buscarFuncionalidadesEnBaseDeDatos()
        {
            SqlCommand seleccionarFuncionalidades = new SqlCommand("SELECT descripcion FROM funcionalidad", Helper.dbOfertas);
            SqlDataReader dataReader = seleccionarFuncionalidades.ExecuteReader();

            while (dataReader.Read())
            {
                string funcionalidad = dataReader.GetValue(0).ToString();
                funcionalidadesASeleccionar.Items.Add(funcionalidad, false);
            }

            dataReader.Close();
        }

        protected SqlDataReader insertarFuncionalidadesParaRol(string idRol)
        {
            List<int> funcionalidadesSeleccionadas = funcionalidadesASeleccionar.CheckedIndices.Cast<int>().ToList();

            //TODO: [D] si no selecciona ninguna
            string valoresAInsertarEnFuncionalidadxRol = "";
            foreach (var funcionalidad in funcionalidadesSeleccionadas)
            {
                valoresAInsertarEnFuncionalidadxRol += "(" + idRol.ToString() + "," + (funcionalidad + 1).ToString() + "),";
            }
            valoresAInsertarEnFuncionalidadxRol = valoresAInsertarEnFuncionalidadxRol.Remove(valoresAInsertarEnFuncionalidadxRol.Length - 1);

            SqlCommand insertarFuncionalidadesxRol =
                new SqlCommand("INSERT INTO funcionalidadxrol (rol_id, funcionalidad_id) VALUES " + valoresAInsertarEnFuncionalidadxRol, Helper.dbOfertas);

            SqlDataReader dataReader = insertarFuncionalidadesxRol.ExecuteReader();
            return dataReader;
        }

        abstract protected void confirmar_Click(object sender, EventArgs e);

    }
}
