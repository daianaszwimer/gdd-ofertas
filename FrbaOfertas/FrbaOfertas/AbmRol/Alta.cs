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
    public partial class Alta : Form
    {
        SqlConnection dbOfertas;

        public Alta()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
            SqlCommand obtenerFuncionalidadesDisponibles = new SqlCommand("SELECT descripcion FROM funcionalidad", dbOfertas);
            SqlDataReader dataReader = obtenerFuncionalidadesDisponibles.ExecuteReader();
            List<string> funcionalidades = new List<string>();

            while(dataReader.Read()) {
                string funcionalidad = dataReader.GetValue(0).ToString();
                funcionalidades.Add(funcionalidad);
            }

            foreach (var funcionalidad in funcionalidades) {
                funcionalidadesASeleccionar.Items.Add(funcionalidad, false);
            } 

        }

        public void conectarseABaseDeDatosOfertas()
        {
            try
            {
                string dbOfertasConnectionString = ConfigurationManager.ConnectionStrings["dbOfertas"].ConnectionString;
                dbOfertas = new SqlConnection(dbOfertasConnectionString);
                dbOfertas.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos");
            }
        }

    }
}
