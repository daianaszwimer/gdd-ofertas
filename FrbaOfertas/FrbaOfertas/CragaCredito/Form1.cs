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
        string idTarjeta;

        public Form1(string idTarjeta)
        {
            InitializeComponent();
            tarjeta.Text = idTarjeta;
            cargarTiposDePago();
            this.idTarjeta = idTarjeta;
        }

        private void cargarTiposDePago()
        {
            SqlCommand seleccionarTiposDePago = new SqlCommand("SELECT id, tipo_pago_nombre FROM tipoDePago", Helper.dbOfertas);
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

        private void insertarDatosTarjeta_Click(object sender, EventArgs e)
        {
            (new CragaCredito.DatosTarjeta()).Show();
            this.Hide();
        }

        private void cargarCredito_Click(object sender, EventArgs e)
        {
            string sqlFormattedDate = Helper.obtenerFechaActual().ToString("yyyy-dd-MM HH:mm:ss.fff");
            SqlCommand obtenerIdCliente =
                new SqlCommand("SELECT cliente_id FROM cliente c " +
                                    "JOIN usuario u ON c.username = u.username WHERE u.username='" 
                                        + Helper.usuarioActual + "'", Helper.dbOfertas);

            SqlDataReader dataReader = Helper.realizarConsultaSQL(obtenerIdCliente);
            if (dataReader != null)
            {
                if (dataReader.Read())
                {
                    string idCliente = dataReader.GetValue(0).ToString();
                    SqlCommand insertarCredito =
                    new SqlCommand(string.Format(
                        "INSERT INTO cargaDeCredito (idCliente, idTipoDePago, idTarjeta, carga_credito_fecha, carga_credito_monto) " +
                            "VALUES ('{0}','{1}','{2}','{3}','{4}')", idCliente, tipoDePago.SelectedIndex, idTarjeta, sqlFormattedDate, monto), Helper.dbOfertas);

                    SqlDataReader dataReader2 = Helper.realizarConsultaSQL(insertarCredito);
                    if (dataReader2 != null)
                    {
                        if (dataReader2.Read())
                        {
                            MessageBox.Show("Carga de credito realizada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo cargar el credito correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        dataReader2.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo cargar el credito correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataReader.Close();
                this.Hide();
            }
        }
    }
}
