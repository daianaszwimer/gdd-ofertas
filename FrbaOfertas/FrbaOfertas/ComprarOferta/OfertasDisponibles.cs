using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class OfertasDisponibles : Form
    {
        public OfertasDisponibles(DataSet ofertasDataSet)
        {
            InitializeComponent();
            confirmar.Visible = false;
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
            object[] oferta = Helper.obtenerValoresFilaSeleccionada(tablaDeResultados);
            string idOferta = oferta[0].ToString();
            string descripcionOferta = oferta[1].ToString();
            string precioOferta = oferta[2].ToString();
            string cantidadOferta = oferta[3].ToString();
            string restriccionOferta = oferta[4].ToString();
            (new ComprarOferta.Form1(idOferta, descripcionOferta, precioOferta, cantidadOferta, restriccionOferta)).Show();
            this.Close();
        }
    }
}
