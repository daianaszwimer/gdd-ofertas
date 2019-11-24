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
    public partial class Modificacion : AltaYModificacion
    {
        private object[] proveedor;
        string queModificarDelProveedor = "";
        string queModificarDeDomicilio = "";

        public Modificacion(object[] proveedor)
        {
            InitializeComponent();
            desactivarErrores();
            razonSocial.Text = proveedor[1].ToString();
            CUIT.Text = proveedor[2].ToString();
            localidad.Text = proveedor[5].ToString();
            calle.Text = proveedor[6].ToString();
            piso.Text = proveedor[7].ToString();
            depto.Text = proveedor[8].ToString();
            codigoPostal.Text = proveedor[9].ToString();
            telefono.Text = proveedor[10].ToString();
            mail.Text = proveedor[11].ToString();
            rubro.Text = proveedor[13].ToString();
            nombre.Text = proveedor[14].ToString();
            habilitado.Checked = bool.Parse(proveedor[15].ToString());

            this.proveedor = proveedor;
        }

        private bool modificarProveedor()
        {
            //MODIFICACION DE PROVEEDOR
            if (controlDeModificacionEnProveedor())
            {
                string modificarProveedorString =
                    string.Format(
                    "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor SET {0} WHERE proveedor_id={1}; ", queModificarDelProveedor, proveedor[0]);

                SqlCommand modificarProveedor = new SqlCommand(modificarProveedorString, Helper.dbOfertas);
                SqlDataReader modificarProveedorDataReader = modificarProveedor.ExecuteReader();
                if (modificarProveedorDataReader.RecordsAffected <= 0)
                {
                    modificarProveedorDataReader.Close();
                    return false;
                }
                modificarProveedorDataReader.Close();
            }

            //MODIFICACION ROL DEL PROVEEDOR
            if (!rubro.Text.Equals(proveedor[13].ToString()))
            {
                SqlCommand chequearRubro =
                new SqlCommand(
                    string.Format("SELECT rubro_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Rubro WHERE rubro_descripcion='{0}'",
                    rubro.Text), Helper.dbOfertas);

                SqlDataReader dataReaderRubro = Helper.realizarConsultaSQL(chequearRubro);
                if (dataReaderRubro != null)
                {
                    if (dataReaderRubro.HasRows) // Rubro ya existe
                    {
                        dataReaderRubro.Read();
                        string idRubro = dataReaderRubro.GetValue(0).ToString();
                        dataReaderRubro.Close();

                        SqlCommand modificarProveedor =
                            new SqlCommand(
                                string.Format(
                                    "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor SET proveedor_id_rubro='{0}' WHERE proveedor_id={1};",
                                    idRubro, proveedor[0]), Helper.dbOfertas);

                        SqlDataReader modificarProveedorDataReader = modificarProveedor.ExecuteReader();
                        if (modificarProveedorDataReader.RecordsAffected <= 0)
                        {
                            modificarProveedorDataReader.Close();
                            return false;
                        }
                        modificarProveedorDataReader.Close();

                    }
                    else
                    {
                        dataReaderRubro.Close();
                        SqlCommand insertarNuevoRubro =
                            new SqlCommand(
                                string.Format("INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Rubro (rubro_descripcion) VALUES ('{0}'); " +
                                                "SELECT SCOPE_IDENTITY()", rubro.Text), Helper.dbOfertas);

                        SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoRubro);
                        if (dataReader != null)
                        {
                            if (dataReader.Read())
                            {
                                string idRubro = dataReader.GetValue(0).ToString();
                                dataReader.Close();
                                SqlCommand modificarProveedor =
                                        new SqlCommand(
                                               string.Format(
                                                    "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor SET proveedor_id_rubro='{0}' WHERE proveedor_id={1};",
                                                        idRubro, proveedor[0]), Helper.dbOfertas);

                                SqlDataReader modificarProveedorDataReader = modificarProveedor.ExecuteReader();
                                if (modificarProveedorDataReader.RecordsAffected <= 0)
                                {
                                    modificarProveedorDataReader.Close();
                                    return false;
                                }
                                modificarProveedorDataReader.Close();
                            }
                            else
                            {
                                //MessageBox.Show("Error al guardar el domicilio");
                                dataReader.Close();
                            }
                        }
                    }
                }
            }

            //MODIFICACION LOCALIDAD DEL PROVEEDOR
            if (!localidad.Text.Equals(proveedor[5].ToString()))
            {
                SqlCommand chequearLocalidad =
                new SqlCommand(
                    string.Format(
                        "SELECT localidad_id,localidad_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Localidad WHERE localidad_nombre='{0}'",
                        localidad.Text), Helper.dbOfertas);

                SqlDataReader dataReaderLocalidad = Helper.realizarConsultaSQL(chequearLocalidad);
                if (dataReaderLocalidad != null)
                {
                    if (dataReaderLocalidad.HasRows) // Localidad ya existe
                    {
                        dataReaderLocalidad.Read();
                        string idLocalidad = dataReaderLocalidad.GetValue(0).ToString();
                        dataReaderLocalidad.Close();

                        SqlCommand modificarProveedor =
                                        new SqlCommand(
                                               string.Format(
                                                    "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor SET proveedor_id_localidad='{0}' WHERE proveedor_id={1};",
                                                        idLocalidad, proveedor[0]), Helper.dbOfertas);

                        SqlDataReader modificarProveedorDataReader = modificarProveedor.ExecuteReader();
                        if (modificarProveedorDataReader.RecordsAffected <= 0)
                        {
                            modificarProveedorDataReader.Close();
                            return false;
                        }
                        modificarProveedorDataReader.Close();
                    }
                    else
                    {
                        dataReaderLocalidad.Close();
                        SqlCommand insertarNuevaLocalidad =
                            new SqlCommand(
                                string.Format(
                                    "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Localidad (localidad_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()",
                                    localidad.Text), Helper.dbOfertas);

                        SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevaLocalidad);
                        if (dataReader != null)
                        {
                            if (dataReader.Read())
                            {
                                string idLocalidad = dataReader.GetValue(0).ToString();
                                dataReader.Close();
                                SqlCommand modificarProveedor =
                                        new SqlCommand(
                                               string.Format(
                                                    "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor SET proveedor_id_localidad='{0}' WHERE proveedor_id={1};",
                                                        idLocalidad, proveedor[0]), Helper.dbOfertas);

                                SqlDataReader modificarProveedorDataReader = modificarProveedor.ExecuteReader();
                                if (modificarProveedorDataReader.RecordsAffected <= 0)
                                {
                                    modificarProveedorDataReader.Close();
                                    return false;
                                }
                                modificarProveedorDataReader.Close();
                            }
                            else
                            {
                                //MessageBox.Show("Error al guardar la localidad");
                                dataReader.Close();
                            }
                        }
                    }
                }
            }

            //MODIFICACION DOMICILIO DEL PROVEEDOR
            if (controlDeModificacionEnDomicilio())
            {
                string idDomicilio = proveedor[3].ToString();
                string modificarDomicilioString =
                    string.Format(
                        "UPDATE NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio SET {0} WHERE domicilio_id={1}; ", 
                        queModificarDeDomicilio, idDomicilio);

                SqlCommand modificarDomicilio = new SqlCommand(modificarDomicilioString, Helper.dbOfertas);
                SqlDataReader modificarDomicilioDataReader = modificarDomicilio.ExecuteReader();
                if (modificarDomicilioDataReader.RecordsAffected <= 0)
                {
                    modificarDomicilioDataReader.Close();
                    return false;
                }
                modificarDomicilioDataReader.Close();
            }
            return true;
        }

        private bool controlDeModificacionEnProveedor()
        {
            bool seModificoAlgoDeProveedor = false;
            if (!razonSocial.Text.Equals(proveedor[1].ToString()))
            {
                queModificarDelProveedor += ("proveedor_razon_social = '" + razonSocial.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!CUIT.Text.Equals(proveedor[2].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_cuit = '" + CUIT.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!telefono.Text.Equals(proveedor[10].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_telefono = '" + telefono.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!mail.Text.Equals(proveedor[11].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_mail = '" + mail.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (!nombre.Text.Equals(proveedor[14].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_nombre_contacto = '" + nombre.Text + "'");
                seModificoAlgoDeProveedor = true;
            }

            if (habilitado.Checked != bool.Parse(proveedor[15].ToString()))
            {
                if (seModificoAlgoDeProveedor)
                    queModificarDelProveedor += ", ";
                queModificarDelProveedor += ("proveedor_habilitado = '" + (habilitado.Checked ? "1" : "0") + "'");
                seModificoAlgoDeProveedor = true;
            }
            return seModificoAlgoDeProveedor;
        }

        private bool controlDeModificacionEnDomicilio()
        {
            bool seModificoAlgoDeDomicilio = false;

            if (!calle.Text.Equals(proveedor[6].ToString()))
            {
                queModificarDeDomicilio += ("domicilio_calle = '" + calle.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!piso.Text.Equals(proveedor[7].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDeDomicilio += ", ";
                queModificarDeDomicilio += ("domicilio_numero_piso = '" + piso.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!depto.Text.Equals(proveedor[8].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDeDomicilio += ", ";
                queModificarDeDomicilio += ("domicilio_departamento = '" + depto.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }

            if (!codigoPostal.Text.Equals(proveedor[9].ToString()))
            {
                if (seModificoAlgoDeDomicilio)
                    queModificarDeDomicilio += ", ";
                queModificarDeDomicilio += ("domicilio_codigo_postal = '" + codigoPostal.Text + "'");
                seModificoAlgoDeDomicilio = true;
            }
            return seModificoAlgoDeDomicilio;
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                if (modificarProveedor())
                {
                    MessageBox.Show("El proveedor se modifico exitosamente");
                    this.Hide();
                }
                else
                    MessageBox.Show("No se ha podido modificar el proveedor correctamente");
            }
        }
    }
}
