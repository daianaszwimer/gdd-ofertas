using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class ListadoProveedores : AbmProveedor.Listado
    {
        Action<string,string> agregarProveedorSeleccionado;

        public ListadoProveedores(Action<string, string> agregarProveedorSeleccionado)
        {
            InitializeComponent();
            modificar.Visible = false;
            eliminar.Visible = false;
            confirmar.Visible = false;
            this.agregarProveedorSeleccionado = agregarProveedorSeleccionado;
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
            agregarProveedorSeleccionado(
                tablaDeResultados.SelectedRows[0].Cells[0].Value.ToString(),
                tablaDeResultados.SelectedRows[0].Cells[2].Value.ToString());
            this.Close();
        }
    }
}
