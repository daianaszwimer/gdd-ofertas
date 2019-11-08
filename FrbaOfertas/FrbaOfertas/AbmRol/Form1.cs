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
            AltaYModificacion alta = new AltaYModificacion();
            alta.Show();
        }

        private void botonListado_Click(object sender, EventArgs e)
        {
            Listado listado = new Listado();
            listado.Show();
        }
    }
}
