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

namespace FrbaOfertas.AbmProveedor
{
    public partial class Alta : AltaYModificacion
    {
        public Alta() : base()
        {
            habilitado.Visible = false;
            confirmar.Text = "Crear";
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            // TODO: Validaciones
            // TODO: chequeo que no haya 2 con misma razon social y cuit
            insertarLocalidadParaDireccion();
        }

        private void insertarLocalidadParaDireccion()
        {
            SqlCommand chequearLocalidad = new SqlCommand(string.Format("SELECT localidad_id,localidad_nombre FROM localidad WHERE localidad_nombre='{0}'", localidad.Text), dbOfertas);
            SqlDataReader dataReaderLocalidad = chequearLocalidad.ExecuteReader();

            if (dataReaderLocalidad.HasRows) // Localidad ya existe
            {
                dataReaderLocalidad.Read();
                string idLocalidad = dataReaderLocalidad.GetValue(0).ToString();
                dataReaderLocalidad.Close();
                insertarDomicilioParaDireccion(idLocalidad);
            }
            else
            {
                dataReaderLocalidad.Close();
                SqlCommand insertarNuevaLocalidad = new SqlCommand(string.Format("INSERT INTO localidad (localidad_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", localidad.Text), dbOfertas);
                SqlDataReader dataReader = insertarNuevaLocalidad.ExecuteReader();
                if (dataReader.Read())
                {
                    string idLocalidad = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    insertarDomicilioParaDireccion(idLocalidad);
                }
                else
                {
                    //MessageBox.Show("Error al guardar la localidad");
                    dataReader.Close();
                }
            }
        }

        private void insertarDomicilioParaDireccion(string idLocalidad)
        {
            SqlCommand chequearDomicilio = new SqlCommand(string.Format("SELECT domicilio_id, domicilio_calle, domicilio_piso, domicilio_depto FROM domicilio WHERE domicilio_calle='{0}' AND domicilio_piso='{1}'AND domicilio_depto='{2}'", calle.Text, piso.Text, depto.Text), dbOfertas);
            SqlDataReader dataReaderDomicilio = chequearDomicilio.ExecuteReader();
            if (dataReaderDomicilio.HasRows) // Domicilio ya existe
            {
                dataReaderDomicilio.Read();
                string idDomicilio = dataReaderDomicilio.GetValue(0).ToString();
                dataReaderDomicilio.Close();
                insertarRubro(idDomicilio);
            }
            else
            {
                dataReaderDomicilio.Close();
                SqlCommand insertarNuevoDomicilio = new SqlCommand(string.Format("INSERT INTO domicilio (idLocalidad,domicilio_calle,domicilio_piso,domicilio_depto,domicilio_codpostal) VALUES ('{0}','{1}','{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()", idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text), dbOfertas);
                SqlDataReader dataReader = insertarNuevoDomicilio.ExecuteReader();
                if (dataReader.Read())
                {
                    string idDomicilio = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    insertarDomicilioParaDireccion(idDomicilio);
                }
                else
                {
                    //MessageBox.Show("Error al guardar el domicilio");
                    dataReader.Close();
                }
            }
        }

        private void insertarRubro(string idDomicilio)
        {
            SqlCommand chequearRubro = new SqlCommand(string.Format("SELECT rubro_id FROM rubro WHERE rubro_descripcion='{0}'", rubro.Text), dbOfertas);
            SqlDataReader dataReaderRubro = chequearRubro.ExecuteReader();
            if (dataReaderRubro.HasRows) // Rubro ya existe
            {
                dataReaderRubro.Read();
                string idRubro = dataReaderRubro.GetValue(0).ToString();
                dataReaderRubro.Close();
                insertarProveedor(idDomicilio, idRubro);
            }
            else
            {
                dataReaderRubro.Close();
                SqlCommand insertarNuevoRubro = new SqlCommand(string.Format("INSERT INTO rubro (rubro_descripcion) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", rubro.Text), dbOfertas);
                SqlDataReader dataReader = insertarNuevoRubro.ExecuteReader();
                if (dataReader.Read())
                {
                    string idRubro = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    insertarProveedor(idDomicilio, idRubro);
                }
                else
                {
                    //MessageBox.Show("Error al guardar el domicilio");
                    dataReader.Close();
                }
            }
        }

        private void insertarProveedor(string idDomicilio, string idRubro)
        {
            SqlCommand insertarNuevoProveedor = 
                new SqlCommand(
                    string.Format("INSERT INTO proveedor (proveedor_razon_social, proveedor_id_domicilio," +
                    "proveedor_cuit, proveedor_telefono, proveedor_mail, proveedor_id_rubro, proveedor_nombre_contacto) " +
                    "VALUES ('{0}',{1},'{2}','{3}','{4}',{5},'{6}'); SELECT SCOPE_IDENTITY()", 
                    razonSocial.Text, idDomicilio, CUIT.Text, telefono.Text, mail.Text, idRubro, nombre.Text), dbOfertas);
            SqlDataReader dataReader = insertarNuevoProveedor.ExecuteReader();
            if (dataReader.RecordsAffected == 0)
            {
                MessageBox.Show("Error al crear proveedor", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Proveedor REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }
    }
}
