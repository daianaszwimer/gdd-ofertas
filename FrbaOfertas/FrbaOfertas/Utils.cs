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

namespace FrbaOfertas
{
    public partial class Utils : Form
    {
        protected SqlConnection dbOfertas;

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
