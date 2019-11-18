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
        public Menu()
        {
            InitializeComponent();
            List<String> funcionalidades = obtenerFuncionalidadesSegunUsuario(Helper.usuarioActual);
            mostrarListadoDeFuncionalidades(funcionalidades);
        }

        private List<String> obtenerFuncionalidadesSegunUsuario(String usuario)
        {
            List<String> funcionalidades = new List<string>();
            SqlCommand seleccionarFuncionalidades =
                new SqlCommand("SELECT funcionalidad_descripcion, rol_nombre FROM NO_LO_TESTEAMOS_NI_UN_POCO.Rol " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol ON funcionalidadxrol_id_rol = rol_id " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad ON funcionalidad_id = funcionalidadxrol_id_funcionalidad " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario ON rolesxusuario_id_rol = rol_id " +
                                    "JOIN NO_LO_TESTEAMOS_NI_UN_POCO.Usuario ON usuario_username = rolesxusuario_id_usuario " +
                                    "WHERE usuario_username ='" + usuario + "'", Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(seleccionarFuncionalidades);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    string funcionalidad = dataReader.GetValue(0).ToString();
                    string rol = dataReader.GetValue(1).ToString();
                    funcionalidades.Add(funcionalidad);

                    if (!Helper.rolesActuales.Contains(rol))
                        Helper.rolesActuales.Add(rol);
                }
                dataReader.Close();
            }
            return funcionalidades;
        }

        private void mostrarListadoDeFuncionalidades(List<String> funcionalidades) 
        {
            int columnas = 2;
            int filas = (int)Math.Ceiling((double)(funcionalidades.Count / 2));
            tableLayoutPanel.ColumnCount = columnas;
            tableLayoutPanel.RowCount = filas;
            tableLayoutPanel.Dock = DockStyle.Fill;

            foreach (var funcionalidad in funcionalidades)
            {
                var buttonFuncionalidad = new Button();
                buttonFuncionalidad.Text = funcionalidad;
                agregarEventoOnClick(buttonFuncionalidad);
                buttonFuncionalidad.Dock = DockStyle.Fill;
                buttonFuncionalidad.Height = 100;
                tableLayoutPanel.Controls.Add(buttonFuncionalidad);
            }

            var buttonCambiarConstrasenia = new Button();
            buttonCambiarConstrasenia.Text = "Cambiar Contraseña";
            agregarEventoOnClick(buttonCambiarConstrasenia);
            buttonCambiarConstrasenia.Dock = DockStyle.Fill;
            buttonCambiarConstrasenia.Height = 100;
            tableLayoutPanel.Controls.Add(buttonCambiarConstrasenia);
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
                case "Carga de Credito": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new CragaCredito.Form1("")).Show(); this.Close(); }; break;
                case "Confeccion y Publicacion de Ofertas": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new CrearOferta.Form1()).Show(); this.Close(); }; break;
                case "Compra de Ofertas": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new ComprarOferta.Form1("", "", "0", "0", "0")).Show(); this.Close(); }; break;
                case "Entrega/Consumo de Ofertas": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new EntregaDeOferta.Form1()).Show(); this.Close(); }; break;
                case "Cambiar Contraseña": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new CambiarPassword.Form1()).Show(); this.Close(); }; break;
            }
            
        }
    }
}
