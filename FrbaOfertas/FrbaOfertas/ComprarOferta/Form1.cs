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

namespace FrbaOfertas.ComprarOferta
{
    public partial class Form1 : BarraDeOpciones
    {
        DataSet ofertasDataSet = new DataSet();
        string idCliente;
        string idOferta;
        string descripcion;
        decimal precioOferta;
        int cantidadOferta;

        public Form1(string id, string descripcion, string precio, string cantidad, string restriccion)
        {
            InitializeComponent();
            idOferta = id;
            descripcionOferta.Text = descripcion;
            this.descripcion = descripcion;
            precioOferta = Decimal.Parse(precio);
            cantidadOferta = int.Parse(cantidad);
            habilitarCompra();
            unidadDeOferta.Maximum = Decimal.Parse(restriccion);
        }

        public void habilitarCompra()
        {
            if (idOferta != "")
                comprar.Visible = true;
            else
                comprar.Visible = false;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            ofertasDataSet.Clear();
            SqlDataAdapter ofertasDataAdapter =
                new SqlDataAdapter(
                    string.Format(
                        "SELECT oferta_id, oferta_descripcion, oferta_precio_lista, oferta_cantidad, oferta_restriccion_compra " +
                              "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Oferta " +
                              "WHERE oferta_fecha_venc >= '{0}' AND oferta_cantidad > 0",
                              Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff")), Helper.dbOfertas);

            ofertasDataAdapter.Fill(ofertasDataSet);
            (new ComprarOferta.OfertasDisponibles(ofertasDataSet)).Show();
            this.Close();
        }

        private void comprar_Click(object sender, EventArgs e)
        {

            if (Helper.rolesActuales.Contains("cliente"))
            {
                DateTime myDateTime = Helper.obtenerFechaActual();
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                SqlCommand obtenerIdCliente = new SqlCommand( "SELECT cliente_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente " +
                     "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = cliente_id_usuario WHERE usuario_username='" + Helper.usuarioActual + "'", Helper.dbOfertas);
                SqlDataReader dataReader = Helper.realizarConsultaSQL(obtenerIdCliente);
                if (dataReader != null)
                {
                    if (dataReader.Read())
                    {
                        idCliente = dataReader.GetValue(0).ToString();
                        dataReader.Close();
                        try
                        {
                            using (SqlCommand cmd = Helper.dbOfertas.CreateCommand())
                            {
                                cmd.CommandText = "NO_LO_TESTEAMOS_NI_UN_POCO.cliente_comprar_oferta";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("id_cliente", idCliente);
                                cmd.Parameters.AddWithValue("id_oferta", idOferta);
                                cmd.Parameters.AddWithValue("fecha", sqlFormattedDate);
                                cmd.Parameters.AddWithValue("cantidad", unidadDeOferta.Value);
                                cmd.Parameters.AddWithValue("codigo", "");

                                var returnParameter = cmd.Parameters.Add("@codigo", SqlDbType.Int);
                                returnParameter.Direction = ParameterDirection.ReturnValue;

                                cmd.ExecuteNonQuery();
                                var result = returnParameter.Value;
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                comprar.Enabled = false;
                MessageBox.Show("DISPONIBLE SOLO PARA ROL CLIENTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
