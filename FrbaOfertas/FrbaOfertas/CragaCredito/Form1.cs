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
        string idTarjeta;
        string sqlFormattedDate;
        List<List<string>> tarjetas = new List<List<string>>();

        public Form1()
        {
            InitializeComponent();
            desactivarErrores();
            tipoDePago.SelectedIndexChanged += tipoDePago_SelectedIndexChanged;
            sqlFormattedDate = Helper.obtenerFechaActual().ToString("yyyy-MM-dd HH:mm:ss.fff");
            cargarTiposDePago();

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

        private void tipoDePago_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tipoDePago.Text.Equals("efectivo"))
            {
                nuevaTarjeta.Enabled = false;
                tarjetaTextBox.Clear();
                idTarjeta = "";
            }
            else
            {
                nuevaTarjeta.Enabled = true;
            }
        }

        private void desactivarErrores()
        {
            errorTipoDePago.Clear();
            errorMonto.Clear();
            errorTarjeta.Clear();
            errorCliente.Clear();
        }

        private bool validacionCampos()
        {
            bool camposOk = true;
            if (string.IsNullOrWhiteSpace(tipoDePago.Text))
            {
                errorTipoDePago.SetError(tipoDePago, "Campo Obligatorio");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(tipoDePago.Text) && tipoDePago.SelectedIndex == -1)
            {
                errorTipoDePago.SetError(tipoDePago, "Debe seleccionarse un valor de los definidos");
                camposOk = false;
            }

            if (string.IsNullOrWhiteSpace(monto.Text))
            {
                errorMonto.SetError(monto, "Campo Obligatorio");
                camposOk = false;
            }

            int numeroInt;
            if (!string.IsNullOrWhiteSpace(monto.Text) && !int.TryParse(monto.Text, out numeroInt))
            {
                errorMonto.SetError(monto, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(monto.Text) && int.TryParse(monto.Text, out numeroInt) && numeroInt <= 0)
            {
                errorMonto.SetError(monto, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            if(!tipoDePago.Text.Equals("efectivo"))
            {
                if (string.IsNullOrWhiteSpace(tarjetaTextBox.Text))
                {
                    errorTarjeta.SetError(nuevaTarjeta, "Campo Obligatorio");
                    camposOk = false;
                }
            }

            if (!Helper.rolesActuales.Contains("3"))
            {
                if (string.IsNullOrWhiteSpace(cliente.Text))
                {
                    errorCliente.SetError(seleccionarCliente, "Campo Obligatorio");
                    camposOk = false;
                }
            }   
            
            return camposOk;
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

        private void cargarCredito_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                SqlCommand insertarCredito;
                string montoString = monto.Text;

                if (tipoDePago.Text.Equals("efectivo"))
                {
                    insertarCredito =
                        new SqlCommand(string.Format(
                            "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito " +
                            "(carga_credito_id_cliente, carga_credito_id_tipo_pago, carga_credito_fecha, " +
                            "carga_credito_monto) VALUES ('{0}','{1}','{2}','{3}')",
                             idCliente, tipoDePago.SelectedIndex + 1, sqlFormattedDate, montoString), Helper.dbOfertas);
                }
                else
                {
                    insertarCredito =
                        new SqlCommand(string.Format(
                            "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito " +
                            "(carga_credito_id_cliente, carga_credito_id_tipo_pago, carga_credito_id_tarjeta, carga_credito_fecha, " +
                            "carga_credito_monto) VALUES ('{0}','{1}','{2}','{3}','{4}')",
                            idCliente, tipoDePago.SelectedIndex + 1, idTarjeta, sqlFormattedDate, montoString), Helper.dbOfertas);
                }

                SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarCredito);
                if (dataReader != null)
                {
                    if (dataReader.RecordsAffected > 0)
                    {
                        dataReader.Close();
                        if (actualizarCreditoCliente(montoString))
                            MessageBox.Show("Carga de credito realizada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se pudo cargar el credito correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private bool actualizarCreditoCliente(string dinero)
        {
            string consultaModificarCliente = string.Format("UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Cliente SET cliente_credito = cliente_credito + {0} WHERE cliente_id={1}; ", dinero, idCliente);
            SqlCommand modificarCliente = new SqlCommand(consultaModificarCliente, Helper.dbOfertas);
            SqlDataReader modificarClienteDataReader = modificarCliente.ExecuteReader();
            if (modificarClienteDataReader != null)
            {
                if (modificarClienteDataReader.RecordsAffected <= 0)
                {
                    modificarClienteDataReader.Close();
                    return false;
                }
                modificarClienteDataReader.Close();
                return true;
            }
            else
                return false;
        }

        private void nuevaTarjeta_Click(object sender, EventArgs e)
        {
            errorTarjeta.Clear();
            tarjetaTextBox.Clear();
            (new CragaCredito.AgregarTarjeta(this.agregarNuevaTarjeta)).Show();
        }

        public void agregarNuevaTarjeta(string id, string numero)
        {
            idTarjeta = id;
            tarjetaTextBox.Text = numero;
        }

        private void seleccionarCliente_Click(object sender, EventArgs e)
        {
            errorCliente.Clear();
            cliente.Clear();
            (new ComprarOferta.ListadoClientes(this.agregarClienteSeleccionado)).Show();
        }

        public void agregarClienteSeleccionado(string id, string dni)
        {
            idCliente = id;
            cliente.Text = dni;
        }
    }
}
