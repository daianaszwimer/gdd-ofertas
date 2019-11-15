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
            comprar.Visible = false;
            tablaDeResultados.SelectionChanged += tablaDeResultados_SelectionChanged;
        }

        private void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaDeResultados.SelectedRows.Count == 0)
            {
                comprar.Visible = false;
            }
            else
            {
                comprar.Visible = true;
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            ofertasDataSet.Clear();
            SqlDataAdapter ofertasDataAdapter = new SqlDataAdapter(string.Format("SELECT oferta_id, oferta_descripcion, oferta_precio_lista, oferta_cantidad FROM Oferta WHERE oferta_fecha_venc >= '{0}' AND oferta_cantidad > 0", Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff")), Helper.dbOfertas);
            ofertasDataAdapter.Fill(ofertasDataSet);
            tablaDeResultados.DataSource = ofertasDataSet.Tables[0];
        }

        private void comprar_Click(object sender, EventArgs e)
        {
            object[] oferta = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            string id = oferta[0].ToString();

            //TODO: VALIDAR SALDO SUFICIENTE
            //TODO: CANTIDAD MAX USUARIO
            SqlCommand restarOferta = new SqlCommand(string.Format("UPDATE Oferta SET oferta_cantidad = oferta_cantidad-1 WHERE oferta_id="+ id), Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(restarOferta);
            if (dataReader != null)
            {
                MessageBox.Show("DATOS DE COMPRA", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                ofertasDataSet.Clear();
                dataReader.Close();
            }
            dataReader.Close();

        }
    }
}
