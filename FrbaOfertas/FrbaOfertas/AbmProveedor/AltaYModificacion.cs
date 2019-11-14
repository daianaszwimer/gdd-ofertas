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
    public abstract partial class AltaYModificacion : BarraDeOpciones
    {
        public AltaYModificacion()
        {
            InitializeComponent();
        }

        abstract protected void confirmar_Click(object sender, EventArgs e);
    }
}
