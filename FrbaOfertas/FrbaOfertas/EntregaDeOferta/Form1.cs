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
        string idCupon;
        string dniCliente;
        DataSet cuponesDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            obtenerIdProveedor();
        }

        private void bajaCupon_Click(object sender, EventArgs e)
        {

            //if (Helper.rolesActuales.Contains("proveedor"))
            //{
            //    DateTime myDateTime = Helper.obtenerFechaActual();
            //    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            //    SqlCommand obtenerIdCliente = new SqlCommand("SELECT cliente_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente " +
            //        "WHERE cliente_dni= " + clienteDni.Text, Helper.dbOfertas);
            //    SqlDataReader dataReaderCliente = Helper.realizarConsultaSQL(obtenerIdCliente);

            //    if (dataReaderCliente != null)
            //    {
            //        if (dataReaderCliente.Read())
            //        {
            //            string idCliente = dataReaderCliente.GetValue(0).ToString();
            //            dataReaderCliente.Close();
            //            try
            //            {
            //                using (SqlCommand cmd = Helper.dbOfertas.CreateCommand())
            //                {
            //                    cmd.CommandText = "NO_LO_TESTEAMOS_NI_UN_POCO.proveedor_entrega_oferta";
            //                    cmd.CommandType = CommandType.StoredProcedure;
            //                    cmd.Parameters.AddWithValue("fecha_consumo", sqlFormattedDate);
            //                    cmd.Parameters.AddWithValue("id_proveedor", idProveedor);
            //                    cmd.Parameters.AddWithValue("id_cliente", idCliente);
            //                    //cmd.Parameters.AddWithValue("codigo_cup", codigoCupon.Text);

            //                    cmd.ExecuteNonQuery();
            //                }
            //            }
            //            catch (SqlException ex)
            //            {
            //                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("DISPONIBLE SOLO PARA ROL PROVEEDOR", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
            }
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {

            cuponesDataSet.Clear();
            string consultaCupon = string.Format("SELECT * FROM NO_LO_TESTEAMOS_NI_UN_POCO.obtener_codigos_cupones({0})",idProveedor);
            SqlDataAdapter cuponesDataAdapter = new SqlDataAdapter(consultaCupon, Helper.dbOfertas);
            cuponesDataAdapter.Fill(cuponesDataSet);
            (new EntregaDeOferta.ListadoCupon(this.agregarCuponSeleccionado, cuponesDataSet)).Show();

            //TODO: QUE LA FUNCION DEVUELVA CUPON Y CLIENTE
            //Asi puuedo filtar por cupon y dni
        }

        public void agregarCuponSeleccionado(string id, string codigoCupon, string dniCliente)
        {
            idCupon = id;
            codigo.Text = codigoCupon;
            clienteDni.Text = dniCliente;
        }

        

        

    }
}
