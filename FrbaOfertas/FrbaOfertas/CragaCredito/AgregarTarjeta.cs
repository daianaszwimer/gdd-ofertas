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
    public partial class AgregarTarjeta : BarraDeOpciones
    {
        Action<string, string> agregarNuevaTarjeta;

        public AgregarTarjeta(Action<string, string> agregarNuevaTarjeta)
        {
            InitializeComponent();
            desactivarErrores();
            this.agregarNuevaTarjeta = agregarNuevaTarjeta;
        }

        private void desactivarErrores()
        {
            errorNumero.Clear();
            errorFecha.Clear();
            errorCodigo.Clear();
        }

        private bool validacionCampos()
        {
            bool camposOk = true;
            if (string.IsNullOrWhiteSpace(numero.Text))
            {
                errorNumero.SetError(numero, "Campo Obligatorio");
                camposOk = false;
            }

            int numeroInt;
            if (!string.IsNullOrWhiteSpace(numero.Text) && !int.TryParse(numero.Text, out numeroInt))
            {
                errorNumero.SetError(numero, "Se debe insertar un numero entero");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(numero.Text) && int.TryParse(numero.Text, out numeroInt) && numeroInt < 0)
            {
                errorNumero.SetError(numero, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            if (string.IsNullOrWhiteSpace(codigoSeguridad.Text))
            {
                errorCodigo.SetError(codigoSeguridad, "Campo Obligatorio");
                camposOk = false;
            }

            int codigoSeguridadInt;
            if (!string.IsNullOrWhiteSpace(codigoSeguridad.Text) && !int.TryParse(codigoSeguridad.Text, out codigoSeguridadInt))
            {
                errorCodigo.SetError(codigoSeguridad, "Se debe insertar un numero entero");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(codigoSeguridad.Text) && int.TryParse(codigoSeguridad.Text, out codigoSeguridadInt) && codigoSeguridadInt < 0)
            {
                errorCodigo.SetError(codigoSeguridad, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            if (DateTime.Parse(fechaVencimiento.Text) < Helper.obtenerFechaActual())
            {
                errorFecha.SetError(fechaVencimiento, "La fecha debe ser mayor a la actual");
                camposOk = false;
            }
            return camposOk;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            insertarTarjeta();
        }

        private void insertarTarjeta()
        {
            desactivarErrores();
            if (validacionCampos())
            {
                SqlCommand chequearTarjeta =
                    new SqlCommand(
                        string.Format(
                            "SELECT tarjeta_id, tarjeta_cod_seguridad FROM NO_LO_TESTEAMOS_NI_UN_POCO.Tarjeta WHERE tarjeta_numero={0};",
                            numero.Text), Helper.dbOfertas);

                SqlDataReader dataReaderTarjeta = Helper.realizarConsultaSQL(chequearTarjeta);
                if (dataReaderTarjeta != null)
                {
                    if (dataReaderTarjeta.HasRows) // Tarjeta ya existe
                    {
                        dataReaderTarjeta.Read();
                        string idTarjeta = dataReaderTarjeta.GetValue(0).ToString();
                        string codSeguridad = dataReaderTarjeta.GetValue(1).ToString();

                        if (codSeguridad.Equals(codigoSeguridad.Text))
                        {
                            MessageBox.Show("Se selecciono la tarjeta ya cargada\nde numero: " + numero.Text, "Elegir tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataReaderTarjeta.Close();
                            agregarNuevaTarjeta(idTarjeta.ToString(), numero.Text);
                        }
                        else
                        {
                            MessageBox.Show("La tarjeta: " + numero.Text + " existe pero\nel codigo de seguridad es erroneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataReaderTarjeta.Close();
                        }
                        this.Close();
                    }
                    else
                    {
                        dataReaderTarjeta.Close();
                        string sqlFormattedDate = Convert.ToDateTime(fechaVencimiento.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
                        SqlCommand insertarNuevaTarjeta =
                            new SqlCommand(
                                string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Tarjeta (tarjeta_numero,tarjeta_fecha_venc, tarjeta_cod_seguridad) " +
                                                "VALUES ({0},'{1}',{2}); SELECT SCOPE_IDENTITY()", numero.Text, sqlFormattedDate, codigoSeguridad.Text), Helper.dbOfertas);

                        SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevaTarjeta);
                        if (dataReader != null)
                        {
                            if (dataReader.Read())
                            {
                                string idTarjeta = dataReader.GetValue(0).ToString();
                                dataReader.Close();
                                MessageBox.Show("Tarjeta guardada con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                agregarNuevaTarjeta(idTarjeta.ToString(), numero.Text);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo crear la tarjeta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dataReader.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
