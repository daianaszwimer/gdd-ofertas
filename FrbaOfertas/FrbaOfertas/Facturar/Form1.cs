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
        string idProveedor;
        int idFactura;
        decimal monto;
        bool camposOk = true;
        DataSet cuponesDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            proveedor.Text = "";
        }

        private void facturar_Click(object sender, EventArgs e)
        {
            cuponObligatorio();
            if (camposOk)
            {
                DateTime myDateTimeI = desde.Value;
                string sqlFormattedDateDesde = myDateTimeI.ToString("yyyy-MM-dd HH:mm:ss.fff");

                DateTime myDateTimeII = hasta.Value;
                string sqlFormattedDateHasta = myDateTimeII.ToString("yyyy-MM-dd HH:mm:ss.fff");

                try
                {
                    using (SqlCommand cmd = Helper.dbOfertas.CreateCommand())
                    {
                        cmd.CommandText = "NO_LO_TESTEAMOS_NI_UN_POCO.facturacion";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("fecha_inicio", sqlFormattedDateDesde);
                        cmd.Parameters.AddWithValue("fecha_fin", sqlFormattedDateHasta);
                        cmd.Parameters.AddWithValue("id_proveedor", idProveedor);
                        cmd.Parameters.AddWithValue("id_factura", 0);

                        var returnParameter = cmd.Parameters.Add("@id_factura", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        cmd.ExecuteNonQuery();
                        var result = returnParameter.Value;

                        idFactura = int.Parse(result.ToString());
                    }
                    if (idFactura != 0)
                    {
                        nroFactura.Text = idFactura.ToString();
                        montoFactura.Text = monto.ToString();
                        cargarTablaResultados();
                    }
                    else
                    {
                        nroFactura.Text = idFactura.ToString();
                        montoFactura.Text = monto.ToString();
                        MessageBox.Show("NO HAY OFERTAS QUE FACTURAR", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void seleccionarProveedor(string id,string razonSocial) 
        {
            idProveedor = id;
            proveedor.Text = razonSocial;
        }


        private void seleccionar_Click(object sender, EventArgs e)
        {
            errorProveedor.Clear();
            (new CrearOferta.ListadoProveedores(this.seleccionarProveedor)).Show();
        }


        private void cargarTablaResultados()
        {
             string consultaOfertasFacturas =
                    string.Format(
                        "SELECT * FROM NO_LO_TESTEAMOS_NI_UN_POCO.obtener_ofertas_factura({0})", nroFactura.Text);
            
            SqlDataAdapter proveedoresDataAdapter = new SqlDataAdapter(consultaOfertasFacturas, Helper.dbOfertas);
            proveedoresDataAdapter.Fill(cuponesDataSet);
            tablaDeResultados.DataSource = cuponesDataSet.Tables[0];
        }


        private void obtenerMontoFactura()
        {
            string consultaMonto =
                string.Format(
                    "SELECT factura_importe FROM NO_LO_TESTEAMOS_NI_UN_POCO.Factura WHERE factura_id={0}", idFactura);

            SqlCommand obtenerMontoFactura = new SqlCommand(consultaMonto,Helper.dbOfertas);
            SqlDataReader dataReaderFactura = Helper.realizarConsultaSQL(obtenerMontoFactura);
            if (dataReaderFactura != null)
            {
                if (dataReaderFactura.Read())
                {
                    monto = decimal.Parse(dataReaderFactura.GetValue(0).ToString());
                    dataReaderFactura.Close();
                }
                dataReaderFactura.Close();
            }
            dataReaderFactura.Close();
        }

        private void cuponObligatorio()
        {
            if (proveedor.Text == string.Empty)
            {
                errorProveedor.SetError(proveedor, "Campo Obligatorio");
                camposOk = false;
            }
            else
                camposOk = true;
        }
    }
}
