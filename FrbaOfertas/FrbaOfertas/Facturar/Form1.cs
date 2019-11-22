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

namespace FrbaOfertas.Facturar
{
    public partial class Form1 : BarraDeOpciones
    {
        string idProveedor;

        public Form1()
        {
            InitializeComponent();
            //proveedor.DataSource = obtenerProveedoresPosibles();
            proveedor.Text = "";
            //obtenerIdProveedor();
        }

        private void facturar_Click(object sender, EventArgs e)
        {
            int id;
            //if (Helper.rolesActuales.Contains("administrativo")) TDO: {M} Controlar validacion
            //{
            try
            {
                using (SqlCommand cmd = Helper.dbOfertas.CreateCommand())
                {
                    cmd.CommandText = "NO_LO_TESTEAMOS_NI_UN_POCO.facturacion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("fecha_inicio", desde);
                    cmd.Parameters.AddWithValue("fecha_fin", hasta);
                    cmd.Parameters.AddWithValue("id_proveedor", idProveedor);
                    cmd.Parameters.AddWithValue("id_factura", 0);

                    var returnParameter = cmd.Parameters.Add("@id_factura", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    id = int.Parse(returnParameter.ToString());
                }
                nroFactura.Text = id.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
            //else
            //{
            //    MessageBox.Show("DISPONIBLE SOLO PARA ROL PROVEEDOR", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }


        //private void obtenerIdProveedor()
        //{
        //    SqlCommand obtenerIdProveedor = new SqlCommand("SELECT proveedor_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor WHERE proveedor_razon_social='" + proveedor + "'", Helper.dbOfertas);
        //    SqlDataReader dataReaderProveedor = Helper.realizarConsultaSQL(obtenerIdProveedor);
        //    if (dataReaderProveedor != null)
        //    {
        //        if (dataReaderProveedor.Read())
        //        {
        //            idProveedor = dataReaderProveedor.GetValue(0).ToString();
        //            dataReaderProveedor.Close();
        //        }
        //    }
        //}

        private void seleccionarProveedor(string id,string razonSocial) 
        {
            idProveedor = id;
            proveedor.Text = razonSocial;
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            (new CrearOferta.ListadoProveedores(this.seleccionarProveedor)).Show();
        }


        //private List<String> obtenerProveedoresPosibles() 
        //{
        //    List<String> proveedoresPosibles = new List<string>();
        //    SqlCommand seleccionarProveedoresPosibles =
        //        new SqlCommand(string.Format("SELECT proveedor_razon_social FROM NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor WHERE proveedor_habilitado=1 AND proveedor_eliminado=0"), Helper.dbOfertas);
        //    SqlDataReader dataReader = Helper.realizarConsultaSQL(seleccionarProveedoresPosibles);
        //    if (dataReader != null)
        //    {
        //        proveedoresPosibles.Add("");
        //        while (dataReader.Read())
        //        {
        //            string rol = dataReader.GetValue(0).ToString();
        //            proveedoresPosibles.Add(rol);
        //        }
        //        dataReader.Close();
        //    }
        //    return proveedoresPosibles;
        //}
    }
}
