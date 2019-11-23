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
    public partial class ListadoOfertas : BarraDeOpciones
    {
        Action<string, string, string, string> agregarCuponSeleccionado;

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
    }
}
