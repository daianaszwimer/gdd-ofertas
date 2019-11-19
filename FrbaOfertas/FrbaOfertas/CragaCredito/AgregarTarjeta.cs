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

        public AgregarTarjeta(Action<string,string> agregarNuevaTarjeta)
        {
            InitializeComponent();
            this.agregarNuevaTarjeta = agregarNuevaTarjeta;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            insertarTarjeta();
        }

        private void insertarTarjeta()
        {
            SqlCommand chequearTarjeta = 
                new SqlCommand(
                    string.Format(
                        "SELECT tarjeta_id, tarjeta_cod_seguridad FROM NO_LO_TESTEAMOS_NI_UN_POCO.Tarjeta WHERE tarjeta_numero={0}", 
                        numero.Text), Helper.dbOfertas);

            SqlDataReader dataReaderTarjeta = Helper.realizarConsultaSQL(chequearTarjeta);
            if (dataReaderTarjeta != null)
            {
                if (dataReaderTarjeta.HasRows) // Tarjeta ya existe
                {
                    MessageBox.Show("Ya existe una tarjeta con ese numero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataReaderTarjeta.Close();
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
