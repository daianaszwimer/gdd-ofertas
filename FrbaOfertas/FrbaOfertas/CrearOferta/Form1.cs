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

namespace FrbaOfertas.CrearOferta
{
    public partial class Form1 : BarraDeOpciones
    {
        string idProv;
        
        public Form1()
        {
            InitializeComponent();
            idProv = "";
            proveedor.Text = "";
            if (Helper.rolesActuales.Contains("proveedor"))
            {
                proveedor.Visible = false;
                seleccionarProveedor.Visible = false;
            }
            else
            {
                proveedor.Visible = true;
                seleccionarProveedor.Visible = true;
            }
        }

        private void crear_Click(object sender, EventArgs e)
        {
            int idProveedor;
            if (!proveedor.Visible) // es rol proveedor
            {

            }
            else
            {

            }

            string sqlFechaPublicacion = DateTime.Parse(fechaPublicacion.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlFechaVencimiento = DateTime.Parse(fechaVencimiento.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");

            /*SqlCommand crearNuevaOferta =
                new SqlCommand(
                    string.Format(
                        "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Oferta (oferta_descripcion, oferta_fecha_publicacion, oferta_fecha_venc, oferta_precio, oferta_precio_lista," + 
                                            "oferta_restriccion_compra, oferta_cantidad, oferta_id_proveedor) " +
                                            "VALUES ('{0}','{1}','{2}',{3},{4},{5},{6},{7}); SELECT SCOPE_IDENTITY()", 
                                            descripcion.Text, sqlFechaPublicacion, sqlFechaVencimiento, 
                                            (Decimal.Parse(precio.Text)* Decimal.Parse(descuento.Text) / 100).ToString(),
                                            precio.Text, restriccion.Text, stock.Text, idProveedor.ToString()), Helper.dbOfertas);

            SqlDataReader dataReader = Helper.realizarConsultaSQL(crearNuevaOferta);
            if (dataReader != null)
            {
                MessageBox.Show("La oferta se creo exitosamente");
                this.Close();
            }*/
        }

        private void seleccionarProveedor_Click(object sender, EventArgs e)
        {
            (new CrearOferta.ListadoProveedores(this.agregarProveedorSeleccionado)).Show();
        }

        public void agregarProveedorSeleccionado(string id, string cuit)
        {
            proveedor.Text = cuit;
            idProv = id;
        }
    }
}
