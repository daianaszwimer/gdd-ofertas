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
        string idOferta;
        string descripcion;
        decimal precioOferta;
        int cantidadOferta;

        public Form1(string id,string descripcion, string precio, string cantidad, string restriccion)
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
                new SqlDataAdapter(string.Format("SELECT oferta_id, oferta_descripcion, oferta_precio_lista, oferta_cantidad, oferta_restriccion_compra " +
                                                 "FROM Oferta "+
                                                 "WHERE oferta_fecha_venc >= '{0}' AND oferta_cantidad > 0", Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff")), Helper.dbOfertas);
            ofertasDataAdapter.Fill(ofertasDataSet);
            (new ComprarOferta.OfertasDisponibles(ofertasDataSet)).Show();
            this.Close();
           
        }

        private void comprar_Click(object sender, EventArgs e)
        {
            //TODO: {M} VALIDAR ROL CLIENTE Y NO ADMINISTRADOR GENERAL (Desabilitar boton)
            if (saldoSuficiente(precioOferta) && cantidadSuficiente(cantidadOferta))
            {
                SqlCommand restarOferta = new SqlCommand(string.Format("UPDATE Oferta SET oferta_cantidad = oferta_cantidad-1 WHERE oferta_id=" + idOferta), Helper.dbOfertas);
                SqlDataReader dataReader = Helper.realizarConsultaSQL(restarOferta);
                if (dataReader != null)
                {
                    MessageBox.Show("DATOS DE COMPRA", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ofertasDataSet.Clear();
                    dataReader.Close();
                }
                dataReader.Close();
            }
            else
            {
                MessageBox.Show("SALDO INSUFICIENTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool cantidadSuficiente(int cantidad)
        {
            return unidadDeOferta.Value <= cantidad;
        }

        private bool saldoSuficiente(decimal precio)
        {
            string idActual = Helper.usuarioActual;
            return creditoCliente(idActual) > precio;
        }

        private decimal creditoCliente(string idActual)
        {
            SqlCommand saldoCliente = new SqlCommand(string.Format("SELECT cliente_credito FROM cliente WHERE cliente_id_usuario='{0}'",idActual), Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(saldoCliente);
            if (dataReader != null)
            {
                decimal saldo = dataReader.GetDecimal(1);
                ofertasDataSet.Clear();
                dataReader.Close();
                return saldo;
            }
            dataReader.Close();
            return 0;
        }

    }
}
