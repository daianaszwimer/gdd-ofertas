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

namespace FrbaOfertas.EntregaDeOferta
{
    public partial class Form1 : BarraDeOpciones
    {
        string idProveedor;
        bool camposOk = true;
        DataSet cuponesDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            obtenerIdProveedor();
            bajaCupon.Enabled = false;
            seleccionar.Enabled = false;
            if (Helper.rolesActuales.Contains("proveedor"))
            {
                bajaCupon.Enabled = true;
                seleccionar.Enabled = true;
            }
        }

        private void bajaCupon_Click(object sender, EventArgs e)
        {
            if (Helper.rolesActuales.Contains("proveedor"))
            {
                errorCodCupon.Clear();
                errorDniCliente.Clear();
                cuponObligatorio();

                if (camposOk)
                {
                    DateTime myDateTime = Helper.obtenerFechaActual();
                    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    try
                    {
                        using (SqlCommand cmd = Helper.dbOfertas.CreateCommand())
                        {
                            cmd.CommandText = "NO_LO_TESTEAMOS_NI_UN_POCO.proveedor_entrega_oferta";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("fecha_consumo", sqlFormattedDate);
                            cmd.Parameters.AddWithValue("id_proveedor", idProveedor);
                            cmd.Parameters.AddWithValue("dni_cliente", clienteDni.Text);
                            cmd.Parameters.AddWithValue("codigo_cup", codigo.Text);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void obtenerIdProveedor()
        {
            SqlCommand obtenerIdProveedor = new SqlCommand("SELECT proveedor_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = proveedor_id_usuario WHERE usuario_username='" + Helper.usuarioActual + "'", Helper.dbOfertas);
            SqlDataReader dataReaderProveedor = Helper.realizarConsultaSQL(obtenerIdProveedor);
            if (dataReaderProveedor != null)
            {
                if (dataReaderProveedor.Read())
                {
                    idProveedor = dataReaderProveedor.GetValue(0).ToString();
                    dataReaderProveedor.Close();
                }
                dataReaderProveedor.Close();
            }
            dataReaderProveedor.Close();
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
                cuponesDataSet.Clear();
                string consultaCupon = string.Format("SELECT * FROM NO_LO_TESTEAMOS_NI_UN_POCO.obtener_codigos_cupones({0})", idProveedor);
                SqlDataAdapter cuponesDataAdapter = new SqlDataAdapter(consultaCupon, Helper.dbOfertas);
                cuponesDataAdapter.Fill(cuponesDataSet);
                (new EntregaDeOferta.ListadoCupon(this.agregarCuponSeleccionado, cuponesDataSet)).Show();
        }

        public void agregarCuponSeleccionado(string codigoCupon)
        {
            codigo.Text = codigoCupon;
        }


        private void cuponObligatorio()
        {
            if (codigo.Text == string.Empty)
            {
                errorCodCupon.SetError(codigo, "Campo Obligatorio");
                camposOk = false;
            }
            if (clienteDni.Text == string.Empty)
            {
                errorDniCliente.SetError(clienteDni, "Campo Obligatorio");
                camposOk = false;
            }
        }

    }
}
