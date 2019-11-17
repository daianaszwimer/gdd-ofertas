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
                new SqlCommand("SELECT f.descripcion FROM rol r " +
	                                "JOIN funcionalidadxrol fr ON fr.rol_id = r.rol_id " +
	                                "JOIN funcionalidad f ON f.id = fr.funcionalidad_id " +
	                                "JOIN rolxusuario ru ON ru.rol_id = r.rol_id " +
                                    "JOIN usuario u ON u.usuario_username = ru.username " +
                                    "WHERE u.usuario_username ='" + usuario + "'", Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(seleccionarFuncionalidades);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    string funcionalidad = dataReader.GetValue(0).ToString();
                    funcionalidades.Add(funcionalidad);
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
                /*var rectangulo = new Rectangle();
                rectangulo.Width = */
                var buttonFuncionalidad = new Button();
                buttonFuncionalidad.Text = funcionalidad;
                agregarEventoOnClick(buttonFuncionalidad);
                buttonFuncionalidad.Dock = DockStyle.Fill;
                buttonFuncionalidad.Height = 100;
                tableLayoutPanel.Controls.Add(buttonFuncionalidad);
            }
        }

        private void agregarEventoOnClick(Button buttonFuncionalidad)
        {
            switch (buttonFuncionalidad.Text)
            {
                case "ABM Rol": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new AbmRol.Form1()).Show(); }; break;
                case "ABM Cliente": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new AbmCliente.Form1()).Show(); }; break;
                case "ABM Proveedor": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new AbmProveedor.Form1()).Show(); }; break;
                case "Carga de credito": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new CragaCredito.Form1("")).Show(); }; break;
                case "Confeccion y publicacion de Ofertas": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new CrearOferta.Form1()).Show(); }; break;
                case "Compra de oferta": buttonFuncionalidad.Click += (object sender, EventArgs e) => {(new ComprarOferta.Form1("","","0","0","0")).Show(); }; break;
                case "Entrega/Consumo de oferta": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new EntregaDeOferta.Form1()).Show(); }; break;
                case "Facturacion a Proveedor": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new Facturar.Form1()).Show(); }; break;
                case "Listado Estadistico": buttonFuncionalidad.Click += (object sender, EventArgs e) => { (new ListadoEstadistico.Form1()).Show(); }; break;
            }
            
        }
    }
}
