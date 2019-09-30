using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class Form1 : Form
    {

        SqlConnection dbOfertas;

        public Form1()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
        }

        private void conectarseABaseDeDatosOfertas() 
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

        private void login_Click(object sender, EventArgs e)
        {
            SqlCommand chequearLogIn = new SqlCommand("SELECT username, pass FROM pruebaLogin WHERE username='" + username.Text + "' AND pass='" + password.Text + "'", dbOfertas);
            
            SqlDataReader dataReader = chequearLogIn.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Log In exitoso");
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
            dataReader.Close();
        }
    }
}
