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

namespace FrbaOfertas.AbmCliente
{
    public partial class Alta : Utils
    {
        public Alta()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
        }

        private void crearCliente_Click(object sender, EventArgs e)
        {
            AbmCliente.Form1 abmCliente = new AbmCliente.Form1();
            //TODO: BUSCAR USUARIO REPETIDO POR DNI

            SqlCommand chequearLocalidad = new SqlCommand(string.Format("SELECT id,nombre FROM localidad WHERE nombre='{0}'", localidad.Text), dbOfertas);
            SqlDataReader dataReaderLocalidad = chequearLocalidad.ExecuteReader();
            
            if (dataReaderLocalidad.HasRows) // Localidad ya existe
            {
                dataReaderLocalidad.Read();
                string idLocalidad = dataReaderLocalidad.GetValue(0).ToString();
                dataReaderLocalidad.Close();
                insertarLocalidadParaDireccion(idLocalidad);
            }
            else
            {
                dataReaderLocalidad.Close();
                SqlCommand insertarNuevaLocalidad = new SqlCommand(string.Format("INSERT INTO localidad (nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", localidad.Text), dbOfertas);
                SqlDataReader dataReader = insertarNuevaLocalidad.ExecuteReader();
                if (dataReader.Read())
                {
                    string idLocalidad = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    insertarLocalidadParaDireccion(idLocalidad);
                }
                else
                {
                    MessageBox.Show("Error al guardar la localidad");
                    dataReader.Close();
                }
            }
        }



        private void insertarLocalidadParaDireccion(string idLocalidad)
        {
            SqlCommand chequearDomicilio = new SqlCommand(string.Format("SELECT id,calle, piso, depto FROM domicilio WHERE calle='{0}' AND piso='{1}'AND depto='{2}'", calle.Text, piso.Text, depto.Text), dbOfertas);
            SqlDataReader dataReaderDomicilio = chequearDomicilio.ExecuteReader();
            if (dataReaderDomicilio.HasRows) // Domicilio ya existe
            {
                dataReaderDomicilio.Read();
                string idDomicilio = dataReaderDomicilio.GetValue(0).ToString();
                dataReaderDomicilio.Close();
                insertarDomicilioParaCliente(idDomicilio);
            }
            else
            {
                dataReaderDomicilio.Close();
                SqlCommand insertarNuevoDomicilio = new SqlCommand(string.Format("INSERT INTO domicilio (idLocalidad,calle,piso,depto,codpostal) VALUES ('{0}','{1}','{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()",idLocalidad, calle.Text, piso.Text, depto.Text,codigoPostal.Text), dbOfertas);
                SqlDataReader dataReader = insertarNuevoDomicilio.ExecuteReader();
                if (dataReader.Read())
                {
                    string idDomicilio = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    insertarLocalidadParaDireccion(idDomicilio);
                }
                else
                {
                    MessageBox.Show("Error al guardar el domicilio");
                    dataReader.Close();
                }
            }
        }


        private void insertarDomicilioParaCliente(string idDomicilio)
        {
            SqlCommand insertarNuevoCliente = new SqlCommand(string.Format("INSERT INTO cliente (idDomicilio,nombre,apellido,dni,mail,telefono,fechaNacimiento) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", idDomicilio, nombre.Text, apellido.Text, dni.Text, mail.Text, telefono.Text, fechaNacimiento.Text), dbOfertas);
            SqlDataReader dataReader = insertarNuevoCliente.ExecuteReader();
            dataReader.Close();   
        }


    } 
}

