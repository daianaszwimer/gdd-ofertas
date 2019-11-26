using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class Form1 : BarraDeOpciones
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void altaProveedor_Click(object sender, EventArgs e)
        {
            AbmProveedor.Alta alta = new AbmProveedor.Alta();
            alta.Show();
        }

        private void listadoProveedor_Click(object sender, EventArgs e)
        {
            AbmProveedor.Listado listado = new AbmProveedor.Listado();
            listado.Show();
        }

    }
}
