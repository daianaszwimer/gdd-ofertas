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
    public partial class ListadoClientes : AbmCliente.Listado
    {
        Action<string,string> agregarClienteSeleccionado;

        public ListadoClientes(Action<string, string> agregarClienteSeleccionado)
        {
            InitializeComponent();
            modificar.Visible = false;
            eliminar.Visible = false;
            confirmar.Visible = false;
            this.agregarClienteSeleccionado = agregarClienteSeleccionado;
        }

        override protected void tablaDeResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaDeResultados.SelectedRows.Count == 0)
                confirmar.Visible = false;
            else
                confirmar.Visible = true;
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            agregarClienteSeleccionado(
                tablaDeResultados.SelectedRows[0].Cells[0].Value.ToString(),
                tablaDeResultados.SelectedRows[0].Cells[3].Value.ToString());
            this.Close();
        }
    }
}
