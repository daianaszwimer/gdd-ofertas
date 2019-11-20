using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Facturar
{
    public partial class Form1 : BarraDeOpciones
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void facturar_Click(object sender, EventArgs e)
        {
            //if (Helper.rolesActuales.Contains("administrativo"))
            //{
            //    using (SqlCommand cmd = Helper.dbOfertas.CreateCommand())
            //    {
            //        cmd.CommandText = "NO_LO_TESTEAMOS_NI_UN_POCO.proveedor_entrega_oferta";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("fecha_consumo", Helper.obtenerFechaActual());
            //        cmd.Parameters.AddWithValue("id_proveedor", Helper.usuarioActual);
            //        cmd.Parameters.AddWithValue("id_cliente", int.Parse(clienteCupon.Text));
            //        cmd.Parameters.AddWithValue("codigo_cup", codigoCupon.Text);

            //        cmd.ExecuteNonQuery();
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("DISPONIBLE SOLO PARA ROL PROVEEDOR", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
