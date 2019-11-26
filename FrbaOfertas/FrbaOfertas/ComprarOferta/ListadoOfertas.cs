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
    public partial class ListadoOfertas : BarraDeOpciones
    {
        Action<string, string, string, string> agregarCuponSeleccionado;
        DataSet ofertasDataSet = new DataSet();

        public ListadoOfertas(Action<string, string, string, string> agregarCuponSeleccionado, DataSet ofertasDataSet)
        {
            InitializeComponent();
            confirmar.Visible = false;
            this.agregarCuponSeleccionado = agregarCuponSeleccionado;
            tablaDeResultados.DataSource = ofertasDataSet.Tables[0];
            tablaDeResultados.SelectionChanged += tablaDeResultados_SelectionChanged;
        }

        
        private void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaDeResultados.SelectedRows.Count == 0)
            {
                confirmar.Visible = false;
            }
            else
            {
                confirmar.Visible = true;
            }
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            agregarCuponSeleccionado(
                tablaDeResultados.SelectedRows[0].Cells[0].Value.ToString(), //id
                tablaDeResultados.SelectedRows[0].Cells[1].Value.ToString(), //descripcion
                tablaDeResultados.SelectedRows[0].Cells[3].Value.ToString(), //cantidad
                tablaDeResultados.SelectedRows[0].Cells[4].Value.ToString()  //restriccin
            );
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                ofertasDataSet.Clear();
                string consultaOferta = string.Format("SELECT oferta_id, oferta_descripcion, oferta_precio_lista, oferta_cantidad, oferta_restriccion_compra " +
                                      "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Oferta " +
                                      "WHERE oferta_fecha_venc >= '{0}' AND oferta_fecha_publicacion >= '{0}' AND oferta_cantidad > 0",
                                      Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff"));
                SqlDataAdapter ofertasDataAdapter = new SqlDataAdapter(consultaOferta, Helper.dbOfertas);

                string descripcionAFiltrar = descripcion.Text;
                string precioAFiltrar = precio.Text;
                string cantidadAFiltrar = cantidad.Text;
                if (!string.IsNullOrWhiteSpace(descripcionAFiltrar))
                {
                    consultaOferta += string.Format(" AND oferta_descripcion LIKE '%{0}%'", descripcionAFiltrar);
                }
                if (!string.IsNullOrWhiteSpace(precioAFiltrar))
                {
                    consultaOferta += string.Format(" AND oferta_precio_lista > {0}", int.Parse(precioAFiltrar));
                }
                if (!string.IsNullOrWhiteSpace(precioAFiltrar))
                {
                    consultaOferta += string.Format(" AND oferta_cantidad > {0}", int.Parse(cantidadAFiltrar));
                }
                SqlDataAdapter cuponesDataAdapter = new SqlDataAdapter(consultaOferta, Helper.dbOfertas);
                cuponesDataAdapter.Fill(ofertasDataSet);
                tablaDeResultados.DataSource = ofertasDataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            ofertasDataSet.Clear();
        }

    }
}
