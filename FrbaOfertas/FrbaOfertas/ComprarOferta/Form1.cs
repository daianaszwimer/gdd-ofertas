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

namespace FrbaOfertas.ComprarOferta
{
    public partial class Form1 : BarraDeOpciones
    {
        DataSet ofertasDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            tablaDeResultados.SelectionChanged += tablaDeResultados_SelectionChanged;
        }

        private void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            ofertasDataSet.Clear();
            SqlDataAdapter ofertasDataAdapter = new SqlDataAdapter(string.Format("SELECT oferta_id, oferta_descripcion, oferta_precio_lista FROM Oferta WHERE oferta_fecha_venc >= '{0}'", Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff")), Helper.dbOfertas);
            ofertasDataAdapter.Fill(ofertasDataSet);
            tablaDeResultados.DataSource = ofertasDataSet.Tables[0];
        }
    }
}
