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

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class Form1 : BarraDeOpciones
    {
        DataSet proveedoresDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            anio.Format = DateTimePickerFormat.Custom;
            anio.CustomFormat = "yyyy";
            anio.ShowUpDown = true;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            proveedoresDataSet.Clear();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            //TODO: [D] validar que todos los campos esten llenos
            proveedoresDataSet.Clear();
            string consultaProveedores;

            if (tipoDeListado.SelectedIndex == 1) // Proveedores con mayor descuento
            {
                /*SELECT TOP 5 * FROM Proveedor INNER JOIN Oferta ON oferta_id_proveedor = proveedor_id
                WHERE --mayor porcentaje de descuento ofrecido en sus ofertas y semestre
                ORDER BY oferta_precio_lista*/
            }
            if (tipoDeListado.SelectedIndex == 2) // Proveedores con mayor facturacion
            {
            }

            /*SqlDataAdapter proveedoresDataAdapter = new SqlDataAdapter(consultaProveedores, Helper.dbOfertas);
            proveedoresDataAdapter.Fill(proveedoresDataSet);
            tablaDeResultados.DataSource = proveedoresDataSet.Tables[0];*/
        }
    }
}
