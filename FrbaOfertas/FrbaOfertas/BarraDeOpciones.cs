using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class BarraDeOpciones : Form
    {
        public BarraDeOpciones()
        {
            InitializeComponent();
        }

        private void volverAlMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAbierto in Application.OpenForms)
            {
                formAbierto.Hide();
            }
            (new Menu()).Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAbierto in Application.OpenForms)
            {
                formAbierto.Hide();
            }
            Helper.cerrarSesion();
        }
    }
}
