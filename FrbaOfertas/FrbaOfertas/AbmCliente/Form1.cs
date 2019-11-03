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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newCliente_Click(object sender, EventArgs e)
        {
            Alta alta = new Alta();
            alta.Show();
        }

        private void editCliente_Click(object sender, EventArgs e)
        {
            Listado listado = new Listado();
            listado.Show();
        }

    }
}
