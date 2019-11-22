using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.EntregaDeOferta
{
    public partial class ListadoCupon : BarraDeOpciones
    {
        Action<string, string, string> agregarCuponSeleccionado;

        public ListadoCupon(Action<string, string, string> agregarCuponSeleccionado, DataSet cuponesDataSet)
        {
            InitializeComponent();
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
                tablaDeResultados.SelectedRows[0].Cells[0].Value.ToString(),
                tablaDeResultados.SelectedRows[0].Cells[1].Value.ToString(),
                tablaDeResultados.SelectedRows[0].Cells[2].Value.ToString()
            );
            this.Close();
        }

    }
}
