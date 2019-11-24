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

namespace FrbaOfertas.EntregaDeOferta
{
    public partial class Form1 : BarraDeOpciones
    {
        string idProveedor;
        bool camposOk;
        DataSet cuponesDataSet = new DataSet();
        

        public Form1() 
        {
            InitializeComponent();
            if (Helper.rolesActuales.Contains("proveedor"))
            {
                labelProveedor.Visible = false;
                proveedor.Visible = false;
                seleccionarProveedor.Visible = false;
                string idProveedor = Helper.obtenerIdProveedor();
            }
            else
            {
                labelProveedor.Visible = true;
                proveedor.Visible = true;
                seleccionarProveedor.Visible = true;
            }
        }

        private void bajaCupon_Click(object sender, EventArgs e) //TODO: NO FUNCIONA
        {
                errorDniCliente.Clear();
                camposOk = campoObligatorio();

                if (camposOk)
                {
                    DateTime myDateTime = Helper.obtenerFechaActual();
                    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    try
                    {
                        using (SqlCommand cmd = Helper.dbOfertas.CreateCommand())
                        {
                            cmd.CommandText = "NO_LO_TESTEAMOS_NI_UN_POCO.proveedor_entrega_oferta";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("fecha_consumo", sqlFormattedDate);
                            cmd.Parameters.AddWithValue("id_proveedor", idProveedor);
                            cmd.Parameters.AddWithValue("dni_cliente", clienteDni.Text);
                            cmd.Parameters.AddWithValue("codigo_cup", codigo.Text);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void seleccionarCupon_Click(object sender, EventArgs e)
        {
            try
            {
                cuponesDataSet.Clear();
                string consultaCupon = string.Format("SELECT * FROM NO_LO_TESTEAMOS_NI_UN_POCO.obtener_codigos_cupones({0})", idProveedor);
                SqlDataAdapter cuponesDataAdapter = new SqlDataAdapter(consultaCupon, Helper.dbOfertas);
                cuponesDataAdapter.Fill(cuponesDataSet);
                errorCodCupon.Clear();
                (new EntregaDeOferta.ListadoCupon(this.agregarCuponSeleccionado, cuponesDataSet)).Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Seleccionar un proveedor", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        public void agregarCuponSeleccionado(string codigoCupon)
        {
            codigo.Text = codigoCupon;
        }


        private void seleccionarProveedor_Click(object sender, EventArgs e)
        {
            errorProveedor.Clear();
            (new CrearOferta.ListadoProveedores(this.agregarProveedorSeleccionado)).Show(); //TODO:{M} SACAR LISTADO
        }

        public void agregarProveedorSeleccionado(string id, string razonSocial)
        {
            proveedor.Text = razonSocial;
            idProveedor = id;
        }


        protected bool campoObligatorio()
        {
            camposOk = true;
            if (!Helper.rolesActuales.Contains("proveedor") && proveedor.Text == string.Empty)
            {
                errorProveedor.SetError(proveedor, "Campo Obligatorio");
                camposOk = false;
            }
            if (codigo.Text == string.Empty)
            {
                errorCodCupon.SetError(codigo, "Campo Obligatorio");
                camposOk = false;
            }
            if (clienteDni.Text == string.Empty)
            {
                errorDniCliente.SetError(clienteDni, "Campo Obligatorio");
                camposOk = false;
            }
            if (Regex.IsMatch(clienteDni.Text, @"[^0-9]"))
            {
                errorDniCliente.SetError(clienteDni, "Ingresar solo numeros");
                camposOk = false;
            }
            return camposOk;
        }


       

    }
}
