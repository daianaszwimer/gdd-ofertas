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
        int cantidadOferta;
        string codigoCompra;
        bool camposOk;

        public Form1()
        {
            InitializeComponent();
            if (Helper.rolesActuales.Contains("3"))
            {
                labelCliente.Visible = false;
                cliente.Visible = false;
                seleccionarCliente.Visible = false;
                idCliente = Helper.obtenerIdCliente();
            }
            else
            {
                labelCliente.Visible = true;
                seleccionarCliente.Visible = true;
            }
        }

        private void comprar_Click(object sender, EventArgs e)
        {
            errorCantidad.Clear();
            camposOk = cuponObligatorio();

            DateTime myDateTime = Helper.obtenerFechaActual();
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            if (camposOk)
            {
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

                        codigoCompra = result.ToString();
                    }
                    MessageBox.Show(codigoCompra, "Codigo de compra", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void seleccionarOferta_Click(object sender, EventArgs e)
        {
            try
            {
                errorOferta.Clear();
                ofertasDataSet.Clear();
                SqlDataAdapter ofertasDataAdapter =
                    new SqlDataAdapter(
                        string.Format(
                            "SELECT oferta_id, oferta_descripcion, oferta_precio_lista, oferta_cantidad, oferta_restriccion_compra " +
                                  "FROM NO_LO_TESTEAMOS_NI_UN_POCO.Oferta " +
                                  "WHERE oferta_fecha_venc >= '{0}' AND oferta_fecha_publicacion >= '{0}' AND oferta_cantidad > 0",
                                  Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff")), Helper.dbOfertas);

                ofertasDataAdapter.Fill(ofertasDataSet);
                (new ComprarOferta.ListadoOfertas(this.agregarCuponSeleccionado, ofertasDataSet)).Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Seleccionar un cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void agregarCuponSeleccionado(string id, string descrip, string cantidad, string restric)
        {
            idOferta = id;
            descripcionOferta.Text = descrip;
            cantidadOferta = int.Parse(cantidad);
            unidadDeOferta.Maximum = Decimal.Parse(restric);
        }


        private void seleccionarCliente_Click(object sender, EventArgs e)
        {
            errorCliente.Clear();
            (new ComprarOferta.ListadoClientes(this.agregarClienteSeleccionado)).Show();
        }

        public void agregarClienteSeleccionado(string id, string dni)
        {
            idCliente = id;
            cliente.Text = dni;
        }


        protected bool cuponObligatorio()
        {
            camposOk = true;
            if (!Helper.rolesActuales.Contains("3") && cliente.Text == string.Empty)
            {
                errorCliente.SetError(cliente, "Campo Obligatorio");
                camposOk = false;
            }
            if (descripcionOferta.Text == string.Empty)
            {
                errorOferta.SetError(descripcionOferta, "Campo Obligatorio");
                camposOk = false;
            }
            if (unidadDeOferta.Value == 0)
            {
                errorCantidad.SetError(unidadDeOferta, "Campo Obligatorio");
                camposOk = false;
            }
            return camposOk;
        }

    }
}
