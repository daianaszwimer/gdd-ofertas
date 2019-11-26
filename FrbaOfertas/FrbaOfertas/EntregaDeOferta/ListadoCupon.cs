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

namespace FrbaOfertas.EntregaDeOferta
{
    public partial class ListadoCupon : BarraDeOpciones
    {
        Action<string> agregarCuponSeleccionado;
        DataSet cuponesDataSet = new DataSet();
        string idProv;

        public ListadoCupon(Action<string> agregarCuponSeleccionado, DataSet cuponesDataSet, string idProveedor)
        {
            InitializeComponent();
            confirm.Visible = false;
            idProv = idProveedor;
            this.agregarCuponSeleccionado = agregarCuponSeleccionado;
            tablaDeResultados.DataSource = cuponesDataSet.Tables[0];
            tablaDeResultados.SelectionChanged += tablaDeResultados_SelectionChanged;
        }

        private void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaDeResultados.SelectedRows.Count == 0)
                confirm.Visible = false;
            else
                confirm.Visible = true;
        }


        private void confirm_Click(object sender, EventArgs e)
        {
            agregarCuponSeleccionado(
                tablaDeResultados.SelectedRows[0].Cells[0].Value.ToString()
            );
            this.Close();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            string consultaCupones =string.Format(
                "select cupon_codigo from NO_LO_TESTEAMOS_NI_UN_POCO.Cupon" +
                    " join NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta on compra_oferta_id = cupon_id_compra_oferta" +
                    " join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta on oferta_id = compra_oferta_id_oferta" +
                    " where oferta_id_proveedor = {0}", idProv);

            string codigoAFiltrar = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(codigoAFiltrar))
            {
                consultaCupones += string.Format(" AND cupon_codigo LIKE '%{0}%'", codigoAFiltrar);
            }
            SqlDataAdapter cuponesDataAdapter = new SqlDataAdapter(consultaCupones, Helper.dbOfertas);
            cuponesDataAdapter.Fill(cuponesDataSet);
            tablaDeResultados.DataSource = cuponesDataSet.Tables[0];
        }

    }
}
