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
    public partial class DatosTarjeta : BarraDeOpciones
    {
        public DatosTarjeta()
        {
            InitializeComponent();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            insertarTarjeta();
        }

        private void insertarTarjeta()
        {
            SqlCommand chequearTarjeta = new SqlCommand(string.Format("SELECT id, tarjeta_cod_seguridad FROM tarjeta WHERE tarjeta_numero={0}", numero.Text), Helper.dbOfertas);
            SqlDataReader dataReaderTarjeta = Helper.realizarConsultaSQL(chequearTarjeta);
            if (dataReaderTarjeta.HasRows) // Tarjeta ya existe
            {
                dataReaderTarjeta.Read();
                string idTarjeta = dataReaderTarjeta.GetValue(0).ToString();
                string codSeguridad = dataReaderTarjeta.GetValue(1).ToString();
                if(codigoSeguridad.Text.Equals(codSeguridad))
                {
                    dataReaderTarjeta.Close();
                    MessageBox.Show("Tarjeta guardada con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (new CragaCredito.Form1(idTarjeta)).Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("La tarjeta existe pero se inserto un codigo de seguridad erroneo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataReaderTarjeta.Close();
            }
            else
            {
                dataReaderTarjeta.Close();
                string sqlFormattedDate = Convert.ToDateTime(fechaVencimiento.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
                SqlCommand insertarNuevaTarjeta = 
                    new SqlCommand(
                        string.Format("INSERT INTO tarjeta (tarjeta_numero,tarjeta_fecha_venc, tarjeta_cod_seguridad) " +
                                        "VALUES ({0},'{1}',{2}); SELECT SCOPE_IDENTITY()", numero.Text, sqlFormattedDate, codigoSeguridad.Text), Helper.dbOfertas);
                SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevaTarjeta);
                if (dataReader.Read())
                {
                    string idTarjeta = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    MessageBox.Show("Tarjeta guardada con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (new CragaCredito.Form1(idTarjeta)).Show();
                    this.Hide();
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
