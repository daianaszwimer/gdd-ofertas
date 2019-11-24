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

namespace FrbaOfertas.CragaCredito
{
    public partial class Form1 : BarraDeOpciones
    {
        string idCliente;
        string sqlFormattedDate;
        List<List<string>> tarjetas = new List<List<string>>();

        public Form1(string idTarjeta)
        {
            InitializeComponent();
            sqlFormattedDate = Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff");
            cargarTiposDePago();

            if (Helper.rolesActuales.Contains("cliente"))
            {
                labelCliente.Visible = false;
                cliente.Visible = false;
                seleccionarCliente.Visible = false;
                idCliente = Helper.obtenerIdCliente();
                cargarTarjetas();
            }
            else
            {
                labelCliente.Visible = true;
                seleccionarCliente.Visible = true;
            }
        }

        private void cargarTiposDePago()
        {
            SqlCommand seleccionarTiposDePago =
                new SqlCommand("SELECT tipo_pago_id, tipo_pago_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Tipo_Pago", Helper.dbOfertas);

            SqlDataReader dataReader = Helper.realizarConsultaSQL(seleccionarTiposDePago);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    string tipoDePagoString = dataReader.GetValue(1).ToString();
                    tipoDePago.Items.Add(tipoDePagoString);
                }

                dataReader.Close();
            }
        }

        private void cargarTarjetas()
        {
            SqlCommand seleccionarTarjetas =
                new SqlCommand("SELECT tarjeta_id, tarjeta_numero FROM NO_LO_TESTEAMOS_NI_UN_POCO.Tarjeta " +
                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito ON carga_credito_id_tarjeta = tarjeta_id " +
                    "WHERE carga_credito_id_cliente=" + idCliente +
                    " AND tarjeta_fecha_venc > '" + sqlFormattedDate + "'", Helper.dbOfertas);

            SqlDataReader dataReader2 = Helper.realizarConsultaSQL(seleccionarTarjetas);
            if (dataReader2 != null)
            {
                while (dataReader2.Read())
                {
                    string idTarjeta = dataReader2.GetValue(0).ToString();
                    string numeroTarjeta = dataReader2.GetValue(1).ToString();
                    var tarjeta = new List<string>();
                    tarjeta.Add(idTarjeta);
                    tarjeta.Add(numeroTarjeta);
                    tarjetaComboBox.Items.Add(numeroTarjeta);
                    tarjetas.Add(tarjeta);
                }
                dataReader2.Close();
            }
        }

        private void cargarCredito_Click(object sender, EventArgs e)
        {
            var idTarjeta = tarjetas.Find(tarjeta => tarjeta[1].Equals(tarjetaComboBox.SelectedItem.ToString()))[0];

            SqlCommand insertarCredito =
            new SqlCommand(string.Format(
                "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito " +
                "(carga_credito_id_cliente, carga_credito_id_tipo_pago, carga_credito_id_tarjeta, carga_credito_fecha, " +
                "carga_credito_monto) VALUES ('{0}','{1}','{2}','{3}','{4}')",
                    idCliente, tipoDePago.SelectedIndex, idTarjeta, sqlFormattedDate, monto.Text), Helper.dbOfertas);

            SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarCredito);
            if (dataReader != null)
            {
                if (dataReader.RecordsAffected > 0)
                {
                    MessageBox.Show("Carga de credito realizada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo cargar el credito correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataReader.Close();
            }
            (new Menu()).Show();
            this.Close();

        }

        private void nuevaTarjeta_Click(object sender, EventArgs e)
        {
            (new CragaCredito.AgregarTarjeta(this.agregarNuevaTarjeta)).Show();
        }

        public void agregarNuevaTarjeta(string id, string numero)
        {
            tarjetaComboBox.Items.Add(numero);
            var tarjeta = new List<string>();
            tarjeta.Add(id);
            tarjeta.Add(numero);
            tarjetas.Add(tarjeta);
            tarjetaComboBox.SelectedValue = numero;
        }

        private void seleccionarCliente_Click(object sender, EventArgs e)
        {
            (new ComprarOferta.ListadoClientes(this.agregarClienteSeleccionado)).Show();
        }

        public void agregarClienteSeleccionado(string id, string dni)
        {
            idCliente = id;
            cliente.Text = dni;
        }
    }
}
