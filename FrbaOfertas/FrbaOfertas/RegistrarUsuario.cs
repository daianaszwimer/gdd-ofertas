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
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             AddFormInPanel(new AbmCliente.Alta());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFormInPanel(new AbmProveedor.Alta());
        }

        private void AddFormInPanel(object formHijo)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            if (fh.Size.Height > Size.Height || fh.Size.Width > Size.Width)
            {
                this.Size = new Size(fh.Width + button1.Size.Width, fh.Height + button1.Size.Height);
            }
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();
        }
    }
}
