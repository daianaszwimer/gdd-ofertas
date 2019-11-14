using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class Form1 : BarraDeOpciones
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newCliente_Click(object sender, EventArgs e)
        {
            AbmCliente.Alta alta = new AbmCliente.Alta();
            alta.Show();
        }

        private void editCliente_Click(object sender, EventArgs e)
        {
            AbmCliente.Listado listado = new AbmCliente.Listado();
            listado.Show();
        }

    }
}
