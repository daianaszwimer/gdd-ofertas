using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
        }

        private void crearCliente_Click(object sender, EventArgs e)
        {
            AbmCliente.Form1 abmCliente = new AbmCliente.Form1();
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;

            if (validarDatosIngresados())
            {
                SqlCommand chequearExistenciaCliente = new SqlCommand(string.Format("SELECT dni FROM cliente WHERE dni='{0}'", dni.Text), dbOfertas);
                SqlDataReader dataReaderUsuario = chequearExistenciaCliente.ExecuteReader();

                if (!dataReaderUsuario.HasRows) // DNI unico
                {
                    dataReaderUsuario.Close();
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
                            //MessageBox.Show("Error al guardar la localidad");
                            dataReader.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El DNI ingresado ya se encuentra en el sistema", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataReaderUsuario.Close();
                }
                this.Hide();
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
                SqlCommand insertarNuevoDomicilio = new SqlCommand(string.Format("INSERT INTO domicilio (idLocalidad,calle,piso,depto,codpostal) VALUES ('{0}','{1}','{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()", idLocalidad, calle.Text, piso.Text, depto.Text, codigoPostal.Text), dbOfertas);
                SqlDataReader dataReader = insertarNuevoDomicilio.ExecuteReader();
                if (dataReader.Read())
                {
                    string idDomicilio = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    insertarLocalidadParaDireccion(idDomicilio);
                }
                else
                {
                    //MessageBox.Show("Error al guardar el domicilio");
                    dataReader.Close();
                }
            }
        }


        private void insertarDomicilioParaCliente(string idDomicilio)
        {
            SqlCommand insertarNuevoCliente = new SqlCommand(string.Format("INSERT INTO cliente (idDomicilio,nombre,apellido,dni,mail,telefono,fechaNacimiento) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}'); SELECT SCOPE_IDENTITY()", idDomicilio, nombre.Text, apellido.Text, dni.Text, mail.Text, telefono.Text, fechaNacimiento.Text), dbOfertas);
            SqlDataReader dataReader = insertarNuevoCliente.ExecuteReader();
            dataReader.Read();
            string idClienteNuevo = dataReader.GetValue(0).ToString();
            dataReader.Close();

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-dd-MM HH:mm:ss.fff");

            SqlCommand insertarCreditoInicial =
                new SqlCommand(string.Format("INSERT INTO cargaDeCredito (carga_credito_id_cliente, carga_credito_id_tipo_de_pago, carga_credito_id_tarjeta, carga_credito_fecha, carga_credito_monto) VALUES ('{0}','{1}','{2}','{3}','{4}')", idClienteNuevo, 1, 1, sqlFormattedDate, 200), dbOfertas);
            SqlDataReader dataReader2 = insertarCreditoInicial.ExecuteReader();
            dataReader2.Close();

            MessageBox.Show("CLIENTE REGISTRADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private bool validarDatosIngresados()
        {
            //TODO: VER CAMPO OBLIGATORIO
            bool datosOk = true;

            //Validacion y obligatorio: Nombre
            if (Regex.IsMatch(nombre.Text, @"[^a-zA-Z ]"))
            {
                label13.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Apellido
            if (Regex.IsMatch(apellido.Text, @"[^a-zA-Z ]"))
            {
                label14.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Dni
            if (Regex.IsMatch(dni.Text, @"[^0-9]"))
            {
                label15.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Mail
            if (Regex.IsMatch(mail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {
                datosOk = true;
            }
            else
            {
                label16.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Telefono
            if (Regex.IsMatch(telefono.Text, @"[^0-9]") && telefono.Text.Length < 7 && telefono.Text.Length > 8)
            {
                label17.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Calle
            if (Regex.IsMatch(calle.Text, @"[^A-Za-z\s0-9]"))
            {
                label18.Visible = true;
                datosOk = false;
            }
            //Validacion: Piso
            if (piso.Text.Length != 0)
            {
                if (Regex.IsMatch(piso.Text, @"[^0-9]"))
                {
                    label18.Visible = true;
                    datosOk = false;
                }
            }
            //Validacion: Depto
            if (localidad.Text.Length != 0)
            {
                if (Regex.IsMatch(localidad.Text, @"[^a-zA-Z ]"))
                {
                    label18.Visible = true;
                    datosOk = false;
                }
            }
            //Validacion: Localidad
            if (depto.Text.Length != 0)
            {
                if (Regex.IsMatch(depto.Text, @"[^A-Za-z\s0-9]"))
                {
                    label19.Visible = true;
                    datosOk = false;
                }
            }
            //Validacion y obligatorio: CodigoPostal
            if (Regex.IsMatch(codigoPostal.Text, @"[^0-9]"))
            {
                label20.Visible = true;
                datosOk = false;
            }
            return datosOk;
        }
 
    //
    }
}

