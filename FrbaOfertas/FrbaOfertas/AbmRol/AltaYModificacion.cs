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
    public abstract partial class AltaYModificacion : BarraDeOpciones
    {
        public AltaYModificacion()
        {
            InitializeComponent();
            buscarFuncionalidadesEnBaseDeDatos();
        }

        private void buscarFuncionalidadesEnBaseDeDatos()
        {
            SqlCommand seleccionarFuncionalidades = 
                new SqlCommand("SELECT funcionalidad_descripcion FROM NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad", Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(seleccionarFuncionalidades);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    string funcionalidad = dataReader.GetValue(0).ToString();
                    funcionalidadesASeleccionar.Items.Add(funcionalidad, false);
                }

                dataReader.Close();
            }
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
                new SqlCommand("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol " +
                                "(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES " + valoresAInsertarEnFuncionalidadxRol, Helper.dbOfertas);

            SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarFuncionalidadesxRol);
            return dataReader;
        }

        abstract protected void confirmar_Click(object sender, EventArgs e);

    }
}
