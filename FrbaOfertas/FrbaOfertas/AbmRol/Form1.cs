using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            AbmRol.Alta alta = new AbmRol.Alta();
            alta.Show();
        }

        private void botonListado_Click(object sender, EventArgs e)
        {
            AbmRol.Listado listado = new AbmRol.Listado();
            listado.Show();
        }
    }
}
