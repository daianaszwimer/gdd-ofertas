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

namespace FrbaOfertas
{
    public partial class Menu : Form
    {
        bool tieneRolEliminado;
        bool clienteEliminado;
        bool clienteHabilitado;
        bool proveedorEliminado;
        bool proveedorHabilitado;
        bool esCliente;
        bool esProveedor;

        public Menu()
        {
            InitializeComponent();
            tieneRolEliminado = false;
            esCliente = false;
            esProveedor = false;
            clienteEliminado = false;
            clienteHabilitado = false;
            proveedorEliminado = false;
            proveedorHabilitado = false;

            List<String> funcionalidades = obtenerFuncionalidadesSegunUsuario(Helper.usuarioActual);
            if (Helper.rolesActuales.Contains("2")) // Es proveedor
            {
                esProveedor = true;
                SqlCommand obtenerIdProveedor = new SqlCommand("SELECT proveedor_eliminado, proveedor_habilitado FROM NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = proveedor_id_usuario WHERE usuario_username='" + Helper.usuarioActual + "'", Helper.dbOfertas);
                SqlDataReader dataReaderProveedor = Helper.realizarConsultaSQL(obtenerIdProveedor);
                if (dataReaderProveedor != null)
                {
                    if (dataReaderProveedor.HasRows)
                    {
                        dataReaderProveedor.Read();
                        proveedorEliminado = bool.Parse(dataReaderProveedor.GetValue(0).ToString());
                        proveedorHabilitado = bool.Parse(dataReaderProveedor.GetValue(1).ToString());
                        dataReaderProveedor.Close();
                        if (proveedorEliminado)
                        {
                            MessageBox.Show("No puede acceder a ninguna funcionalidad\nporque usted como proveedor fue eliminado.\nContacte al administrador", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            funcionalidades = new List<string>();
                        }
                    }
                    else
                        dataReaderProveedor.Close();
                }
                else
                    funcionalidades = new List<string>();
            }

            if (Helper.rolesActuales.Contains("3")) // Es cliente
            {
                esCliente = true;
                string consultaCliente = string.Format("SELECT cliente_eliminado, cliente_habilitado FROM NO_LO_TESTEAMOS_NI_UN_POCO.Cliente " +
                                                        "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = cliente_id_usuario " +
                                                        "WHERE usuario_username='{0}'", Helper.usuarioActual);
                SqlCommand obtenerIdCliente = new SqlCommand(consultaCliente, Helper.dbOfertas);
                SqlDataReader dataReader = Helper.realizarConsultaSQL(obtenerIdCliente);
                if (dataReader != null)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        clienteEliminado = bool.Parse(dataReader.GetValue(0).ToString());
                        clienteHabilitado = bool.Parse(dataReader.GetValue(1).ToString());
                        dataReader.Close();
                        if (clienteEliminado)
                        {
                            MessageBox.Show("No puede acceder a ninguna funcionalidad\nporque usted como cliente fue eliminado.\nContacte al administrador", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            funcionalidades = new List<string>();
                        }
                    }
                    else
                        dataReader.Close();
                }
                else
                    funcionalidades = new List<string>();
            }
            mostrarListadoDeFuncionalidades(funcionalidades);
        }

        private List<String> obtenerFuncionalidadesSegunUsuario(String usuario)
        {
            List<String> funcionalidades = new List<string>();
            SqlCommand seleccionarFuncionalidades =
                new SqlCommand("SELECT funcionalidad_descripcion, rol_nombre, rol_id, rol_eliminado FROM NO_LO_TESTEAMOS_NI_UN_POCO.Rol " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol ON funcionalidadxrol_id_rol = rol_id " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad ON funcionalidad_id = funcionalidadxrol_id_funcionalidad " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario ON rolesxusuario_id_rol = rol_id " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = rolesxusuario_id_usuario " +
                                    "WHERE usuario_username ='" + usuario + "'", Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(seleccionarFuncionalidades);
            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string funcionalidad = dataReader.GetValue(0).ToString();
                        string rol = dataReader.GetValue(1).ToString();
                        string idRol = dataReader.GetValue(2).ToString();
                        bool rolEliminado = bool.Parse(dataReader.GetValue(3).ToString());

                        if (rolEliminado)
                            tieneRolEliminado = true;

                        funcionalidades.Add(funcionalidad);

                        if (!Helper.rolesActuales.Contains(idRol))
                            Helper.rolesActuales.Add(idRol);
                    }
                    dataReader.Close();
                    if (tieneRolEliminado)
                    {
                        MessageBox.Show("No puede acceder a ninguna funcionalidad\nporque su rol fue eliminado.\nContacte al administrador", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return new List<string>();
                    }
                }
                else
                {
                    MessageBox.Show("No puede acceder a ninguna funcionalidad\nporque no tiene un rol asignado.\nContacte al administrador", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<string>();
                }
            }
            return funcionalidades;
        }

        private void mostrarListadoDeFuncionalidades(List<String> funcionalidades) 
        {
            int columnas;
            int filas;

            if (funcionalidades.Count <= 2)
            {
                columnas = 2;
                filas = (int)Math.Ceiling((double)(funcionalidades.Count / 2));
            }
            else
            {
                columnas = 3;
                filas = (int)Math.Ceiling((double)(funcionalidades.Count / 3));
            }

            tableLayoutPanel.ColumnCount = columnas;
            tableLayoutPanel.RowCount = filas;
            //tableLayoutPanel.Dock = DockStyle.Fill;

            foreach (var funcionalidad in funcionalidades)
            {
                var buttonFuncionalidad = new Button();
                buttonFuncionalidad.Text = funcionalidad;
                agregarEventoOnClick(buttonFuncionalidad);
                buttonFuncionalidad.Dock = DockStyle.Fill;
                buttonFuncionalidad.Height = 100;
                buttonFuncionalidad.BackColor = Color.SandyBrown;
                buttonFuncionalidad.FlatStyle = FlatStyle.Popup;
                buttonFuncionalidad.Font = new Font("Segoe UI", 10f);
                tableLayoutPanel.Controls.Add(buttonFuncionalidad);
            }

            var buttonCambiarConstrasenia = new Button();
            buttonCambiarConstrasenia.Text = "Cambiar Contraseña";
            agregarEventoOnClick(buttonCambiarConstrasenia);
            buttonCambiarConstrasenia.Dock = DockStyle.Fill;
            buttonCambiarConstrasenia.Height = 100;
            buttonCambiarConstrasenia.BackColor = Color.SandyBrown;
            buttonCambiarConstrasenia.FlatStyle = FlatStyle.Popup;
            buttonCambiarConstrasenia.Font = new Font("Segoe UI", 10f);
            tableLayoutPanel.Controls.Add(buttonCambiarConstrasenia);

            var buttonCerrarSesion = new Button();
            buttonCerrarSesion.Text = "Cerrar Sesion";
            agregarEventoOnClick(buttonCerrarSesion);
            buttonCerrarSesion.Dock = DockStyle.Fill;
            buttonCerrarSesion.Height = 100;
            buttonCerrarSesion.BackColor = Color.SandyBrown;
            buttonCerrarSesion.FlatStyle = FlatStyle.Popup;
            buttonCerrarSesion.Font = new Font("Segoe UI", 10f);
            tableLayoutPanel.Controls.Add(buttonCerrarSesion);
        }

        private void agregarEventoOnClick(Button buttonFuncionalidad)
        {
            switch (buttonFuncionalidad.Text)
            {
                case "ABM Rol": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new AbmRol.Form1()).Show(); this.Close(); }; break;
                case "ABM Cliente": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new AbmCliente.Form1()).Show(); this.Close(); }; break;
                case "ABM Proveedor": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new AbmProveedor.Form1()).Show(); this.Close(); }; break;
                case "Listado Estadistico": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new ListadoEstadistico.Form1()).Show(); this.Close(); }; break;
                case "Facturacion a Proveedor": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new Facturar.Form1()).Show(); this.Close(); }; break;
                case "Baja y Modificacion Usuario": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new BajaYModificacionUsuario.Form1()).Show(); this.Close(); }; break;
                case "Carga de Credito": buttonFuncionalidad.Click += (object sender, EventArgs e) => 
                {
                    if (esCliente)
                    {
                        if (!clienteHabilitado)
                        {
                            MessageBox.Show("No puede cargarse credito porque usted como\ncliente se encuentra inhabilitado.\nContacte al administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            (new Menu()).Show();
                        }
                        else
                            (new CragaCredito.Form1()).Show(); this.Close();
                    }
                    else
                        (new CragaCredito.Form1()).Show(); this.Close();
                }; break;
                case "Confeccion y Publicacion de Ofertas": buttonFuncionalidad.Click += (object sender, EventArgs e) => 
                {
                    if (esProveedor)
                    {
                        if (!proveedorHabilitado)
                        {
                            MessageBox.Show("No puede crear ofertas porque usted como\nproveedor se encuentra inhabilitado.\nContacte al administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            (new Menu()).Show();
                        }
                        else
                            (new CrearOferta.Form1()).Show(); this.Close(); 
                    }
                    else
                        (new CrearOferta.Form1()).Show(); this.Close(); 
                }; break;
                case "Compra de Ofertas": buttonFuncionalidad.Click += (object sender, EventArgs e) => 
                {
                    if (esCliente)
                    {
                        if (!clienteHabilitado)
                        {
                            MessageBox.Show("No puede comprar ofertas porque usted como\ncliente se encuentra inhabilitado.\nContacte al administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            (new Menu()).Show();
                        }
                        else
                            (new ComprarOferta.Form1()).Show(); this.Close();
                    }
                    else
                        (new ComprarOferta.Form1()).Show(); this.Close(); 
                }; break;
                case "Entrega/Consumo de Ofertas": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new EntregaDeOferta.Form1()).Show(); this.Close(); }; break;
                case "Cambiar Contraseña": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new CambiarPassword.Form1()).Show(); this.Close(); }; break;
                case "Cerrar Sesion": buttonFuncionalidad.Click += (object sender, EventArgs e) => { Helper.cerrarSesion(); }; break;
            }
            
        }
    }
}
