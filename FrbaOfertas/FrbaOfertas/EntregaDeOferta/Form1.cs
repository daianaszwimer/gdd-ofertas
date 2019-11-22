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
        DataSet cuponesDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            obtenerIdProveedor();
        }

        private void bajaCupon_Click(object sender, EventArgs e)
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
            if (Helper.rolesActuales.Contains("proveedor"))
            {
                cuponesDataSet.Clear();
                string consultaCupon = string.Format("SELECT * FROM NO_LO_TESTEAMOS_NI_UN_POCO.obtener_codigos_cupones({0})", idProveedor);
                SqlDataAdapter cuponesDataAdapter = new SqlDataAdapter(consultaCupon, Helper.dbOfertas);
                cuponesDataAdapter.Fill(cuponesDataSet);
                (new EntregaDeOferta.ListadoCupon(this.agregarCuponSeleccionado, cuponesDataSet)).Show();
            }
            else
            {
                MessageBox.Show("DISPONIBLE SOLO PARA ROL PROVEEDOR", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: filtar por cupon y dni
        }

        public void agregarCuponSeleccionado(string codigoCupon)
        {
            codigo.Text = codigoCupon;
        }





    }
}
