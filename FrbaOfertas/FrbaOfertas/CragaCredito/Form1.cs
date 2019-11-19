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
        bool esCliente;
        string idCliente;
        string sqlFormattedDate;
        List<List<string>> tarjetas = new List<List<string>>();

        public Form1(string idTarjeta)
        {
            //TODO: [D] alguien que no sea cliente no puede cargar credito
            InitializeComponent();
            sqlFormattedDate = Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff");
            cargarTiposDePago();
            cargarTarjetas();
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
            SqlCommand obtenerIdCliente =
                new SqlCommand(
                    "SELECT cliente_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente " +
                     "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = cliente_id_usuario WHERE usuario_username='"
                      + Helper.usuarioActual + "'", Helper.dbOfertas);

            SqlDataReader dataReader = Helper.realizarConsultaSQL(obtenerIdCliente);
            if (dataReader != null)
            {
                if (dataReader.Read())
                {
                    esCliente = true;
                    idCliente = dataReader.GetValue(0).ToString();
                    dataReader.Close();

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
                else
                {
                    esCliente = false;
                    dataReader.Close();
                }
            }
        }

        private void cargarCredito_Click(object sender, EventArgs e)
        {
            if (esCliente)
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
            else
                MessageBox.Show("Debe ser cliente para poder cargar credito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nuevaTarjeta_Click(object sender, EventArgs e)
        {
            if (esCliente)
                (new CragaCredito.AgregarTarjeta(this.agregarNuevaTarjeta)).Show();
            else
                MessageBox.Show("Debe ser cliente para poder cargar una tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
