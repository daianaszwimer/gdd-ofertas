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
                consultaProveedores = 
                    string.Format(
                        "SELECT * FROM NO_LO_TESTEAMOS_NI_UN_POCO.top_5_mayor_porcentaje({0}, {1})", anio.Text, semestre.Text);
            }
            else // Proveedores con mayor facturacion
            {
                consultaProveedores =
                    string.Format(
                        "SELECT * FROM NO_LO_TESTEAMOS_NI_UN_POCO.top_5_mayor_facturacion({0}, {1})", anio.Text, semestre.Text);
            }

            SqlDataAdapter proveedoresDataAdapter = new SqlDataAdapter(consultaProveedores, Helper.dbOfertas);
            proveedoresDataAdapter.Fill(proveedoresDataSet);
            tablaDeResultados.DataSource = proveedoresDataSet.Tables[0];
        }
    }
}
