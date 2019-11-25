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
            desactivarErrores();
            idProv = "";
            proveedor.Text = "";
            if (Helper.rolesActuales.Contains("2"))
            {
                labelProveedor.Visible = false;
                proveedor.Visible = false;
                seleccionarProveedor.Visible = false;
                idProv = Helper.obtenerIdProveedor();
            }
            else
            {
                proveedor.Visible = true;
                seleccionarProveedor.Visible = true;
            }
        }

        private void desactivarErrores()
        {
            errorDescripcion.Clear();
            errorFechaPublicacion.Clear();
            errorFechaVencimiento.Clear();
            errorPrecio.Clear();
            errorDescuento.Clear();
            errorStock.Clear();
            errorRestriccionUnidades.Clear();
            errorTiempoCupon.Clear();
            errorProveedor.Clear();
        }

        private bool validacionCampos()
        {
            bool camposOk = true;

            // Error descripcion
            if (string.IsNullOrWhiteSpace(descripcion.Text))
            {
                errorDescripcion.SetError(descripcion, "Campo Obligatorio");
                camposOk = false;
            }

            // Errores fechas
            if (DateTime.Parse(fechaPublicacion.Text) < Helper.obtenerFechaActual())
            {
                errorFechaPublicacion.SetError(fechaPublicacion, "La fecha de publicacion debe ser\nmayor o igual a la actual");
                camposOk = false;
            }

            if (DateTime.Parse(fechaVencimiento.Text) < DateTime.Parse(fechaPublicacion.Text))
            {
                errorFechaVencimiento.SetError(fechaVencimiento, "La fecha de vencimiento debe ser mayor\no igual a la de publicacion");
                camposOk = false;
            }

            // Errores precio de lista
            if (string.IsNullOrWhiteSpace(precio.Text))
            {
                errorPrecio.SetError(precio, "Campo Obligatorio");
                camposOk = false;
            }

            decimal numeroDecimal;
            if (!string.IsNullOrWhiteSpace(precio.Text) && !decimal.TryParse(precio.Text, out numeroDecimal))
            {
                errorPrecio.SetError(precio, "Se debe insertar un numero decimal positivo");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(precio.Text) && decimal.TryParse(precio.Text, out numeroDecimal) && numeroDecimal < 0)
            {
                errorPrecio.SetError(precio, "Se debe insertar un numero decimal positivo");
                camposOk = false;
            }

            // Errores descuento
            if (string.IsNullOrWhiteSpace(descuento.Text))
            {
                errorDescuento.SetError(descuento, "Campo Obligatorio");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(descuento.Text) && !decimal.TryParse(descuento.Text, out numeroDecimal))
            {
                errorDescuento.SetError(descuento, "Se debe insertar un numero decimal entre 0 y 100");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(descuento.Text) && decimal.TryParse(descuento.Text, out numeroDecimal) && (numeroDecimal < 0 || numeroDecimal > 100))
            {
                errorDescuento.SetError(descuento, "Se debe insertar un numero decimal entre 0 y 100");
                camposOk = false;
            }

            // Errores Stock
            if (string.IsNullOrWhiteSpace(stock.Text))
            {
                errorStock.SetError(stock, "Campo Obligatorio");
                camposOk = false;
            }

            int numeroInt;
            if (!string.IsNullOrWhiteSpace(stock.Text) && !int.TryParse(stock.Text, out numeroInt))
            {
                errorStock.SetError(stock, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(stock.Text) && int.TryParse(stock.Text, out numeroInt) && numeroInt < 0)
            {
                errorStock.SetError(stock, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            // Errores Restriccion
            if (string.IsNullOrWhiteSpace(restriccion.Text))
            {
                errorRestriccionUnidades.SetError(restriccion, "Campo Obligatorio");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(restriccion.Text) && !int.TryParse(restriccion.Text, out numeroInt))
            {
                errorRestriccionUnidades.SetError(restriccion, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(restriccion.Text) && int.TryParse(restriccion.Text, out numeroInt) && numeroInt < 0)
            {
                errorRestriccionUnidades.SetError(restriccion, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            // Errores Validez cupon
            if (string.IsNullOrWhiteSpace(validezCupon.Text))
            {
                errorTiempoCupon.SetError(validezCupon, "Campo Obligatorio");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(validezCupon.Text) && !int.TryParse(validezCupon.Text, out numeroInt))
            {
                errorTiempoCupon.SetError(validezCupon, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(validezCupon.Text) && int.TryParse(validezCupon.Text, out numeroInt) && numeroInt < 0)
            {
                errorTiempoCupon.SetError(validezCupon, "Se debe insertar un numero entero positivo");
                camposOk = false;
            }

            // Error Proveedor
            if (!Helper.rolesActuales.Contains("2"))
            {
                if (string.IsNullOrWhiteSpace(proveedor.Text))
                {
                    errorProveedor.SetError(seleccionarProveedor, "Campo Obligatorio");
                    camposOk = false;
                }
            }

            return camposOk;
        }

        private void crear_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                string sqlFechaPublicacion = DateTime.Parse(fechaPublicacion.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlFechaVencimiento = DateTime.Parse(fechaVencimiento.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string precioConDescuento = (Decimal.Parse(precio.Text) * (1 - decimal.Parse(descuento.Text) / 100)).ToString();
                string precioSinDescuento = precio.Text;

                if (precioConDescuento.Contains(","))
                    precioConDescuento = precioConDescuento.Replace(',', '.');

                if (precioSinDescuento.Contains(","))
                    precioSinDescuento = precioSinDescuento.Replace(',', '.');

                SqlCommand crearNuevaOferta =
                    new SqlCommand(
                        string.Format(
                            "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Oferta (oferta_descripcion, oferta_fecha_publicacion, oferta_fecha_venc, oferta_precio, oferta_precio_lista," +
                                                "oferta_restriccion_compra, oferta_cantidad, oferta_id_proveedor, oferta_tiempo_validez_cupon) " +
                                                "VALUES ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8});",
                                                descripcion.Text, sqlFechaPublicacion, sqlFechaVencimiento,
                                                precioConDescuento,
                                                precioSinDescuento, restriccion.Text, stock.Text, idProv, validezCupon.Text), Helper.dbOfertas);

                SqlDataReader dataReader = Helper.realizarConsultaSQL(crearNuevaOferta);
                if (dataReader != null)
                {
                    if (dataReader.RecordsAffected != 0)
                        MessageBox.Show("La oferta se creo exitosamente", "Crear Oferta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error al crear oferta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataReader.Close();
                    (new Menu()).Show();
                    this.Close();
                }
            }
        }

        private void seleccionarProveedor_Click(object sender, EventArgs e)
        {
            errorProveedor.Clear();
            proveedor.Clear();
            (new CrearOferta.ListadoProveedores(this.agregarProveedorSeleccionado)).Show();
        }

        public void agregarProveedorSeleccionado(string id, string cuit)
        {
            proveedor.Text = cuit;
            idProv = id;
        }
    }
}
