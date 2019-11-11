using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class Listado : Utils
    {
        DataTable table = new DataTable();
        List<Clientes> clientesSeleccionados = new List<Clientes>();

        public Listado()
        {
            InitializeComponent();
            conectarseABaseDeDatosOfertas();
            

            // Se crean las columnas
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Apellido", typeof(string));
            table.Columns.Add("DNI", typeof(string));
            table.Columns.Add("Mail", typeof(string));
            table.Columns.Add("Telefono", typeof(string));
            table.Columns.Add("Direccion", typeof(string));
            table.Columns.Add("Fecha de nacimiento", typeof(string)); // TODO: {M} QUILOMBO CON EL FORMATO FECHA
            table.Columns.Add("Habilitado", typeof(bool));
            

            tablaDeResultados.DataSource = table; // Binding de table con el dataGridView tablaDeResultados
            tablaDeResultados.CellContentClick += tablaDeResultados_CellContentClick; // Evento para modificar y borrar

            // Se agrega columna modificar
            // (no se puede agregar al data table del binding un button)
            DataGridViewButtonColumn columnaModificar = new DataGridViewButtonColumn();
            columnaModificar.HeaderText = "Modificar";
            tablaDeResultados.Columns.Add(columnaModificar);

            // Se agrega columna eliminar
            // (no se puede agregar al data table del binding un button)
            DataGridViewButtonColumn columnaEliminar = new DataGridViewButtonColumn();
            columnaEliminar.HeaderText = "Eliminar";
            tablaDeResultados.Columns.Add(columnaEliminar);
        }

        // Evento para modificar y borrar
        private void tablaDeResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(tablaDeResultados[2, e.RowIndex].Value);

            if (e.ColumnIndex == 0) // Si es un boton de modificar
            {
                
                var Cliente = clientesSeleccionados.Find(cliente => cliente.cliente_id == id);
                (new AbmCliente.Modificacion(Cliente)).Show();
                buscarCliente();
            }

            if (e.ColumnIndex == 1)
            {
                eliminarRol(id);
            }
        }

        private void eliminarRol(int id)
        {
            SqlCommand eliminarRol = new SqlCommand("UPDATE cliente SET cliente_eliminado = 1 WHERE cliente_id=" + id.ToString(), dbOfertas);
            SqlDataReader dataReader = eliminarRol.ExecuteReader();

            if (dataReader.RecordsAffected != 0)
            {
                MessageBox.Show("Cliente eliminado exitosamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                table.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el cliente ", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataReader.Close();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            table.Clear();
        }

        private void buscar_Click(object sender, EventArgs e) {
            buscarCliente();
        }

        //private void buscar_Click(object sender, EventArgs e)
        //{
        //    table.Clear();
        //    string consultaRoles =
        //        "SELECT c.cliente_id, c.cliente_nombre, c.cliente_apellido, c.cliente_dni, c.cliente_mail, c.cliente_telefono, " +
        //                "d.domicilio_id, d.domicilio_calle, d.domicilio_piso, d.domicilio_depto, d.domicilio_codpostal, " +
        //                "l.localidad_id, l.localidad_nombre, c.cliente_fechaNacimiento, c.cliente_habilitado " +
        //        "FROM cliente c JOIN domicilio d ON c.idDomicilio = d.domicilio_id " +
        //                       "JOIN localidad l ON d.idLocalidad = l.localidad_id " +
        //        "WHERE c.cliente_eliminado = 0";

        //    string nombreAFiltrar = nombre.Text;
        //    string apellidoAFiltrar = apellido.Text;
        //    string dniAFiltrar = dni.Text;
        //    string mailAFiltrar = mail.Text;

        //    if (!string.IsNullOrWhiteSpace(nombreAFiltrar))
        //    {
        //        consultaRoles += string.Format(" AND c.cliente_nombre LIKE '%{0}%'", nombreAFiltrar);//EXACTO '{0}'
        //    }
        //    if (!string.IsNullOrWhiteSpace(apellidoAFiltrar))
        //    {
        //        consultaRoles += string.Format(" AND c.cliente_apellido LIKE '%{0}%'", apellidoAFiltrar);//LIBRE '%{0}%'
        //    }
        //    if (!string.IsNullOrWhiteSpace(dniAFiltrar))
        //    {
        //        consultaRoles += string.Format(" AND c.cliente_dni LIKE '{0}'", dniAFiltrar);//LIBRE '%{0}%'
        //    }
        //    if (!string.IsNullOrWhiteSpace(mailAFiltrar))
        //    {
        //        consultaRoles += string.Format(" AND c.cliente_mail LIKE '%{0}%'", mailAFiltrar);//LIBRE '%{0}%'
        //    }

        //    SqlCommand seleccionarRoles = new SqlCommand(consultaRoles, dbOfertas);
        //    SqlDataReader dataReader = seleccionarRoles.ExecuteReader();

        //    //// Se guarda en clientes la respuesta al SELECT 
        //    //// (en formato List<Clientes> para que sea mas facil acceder y filtrar elementos)
        //    clientesSeleccionados = convertirSelectAListaClientes(dataReader);

        //    dataReader.Close();

        //    foreach (var cli in clientesSeleccionados)
        //    {
        //        table.Rows.Add(cli.cliente_id,cli.cliente_nombre, cli.cliente_apellido, cli.cliente_dni, cli.cliente_mail, cli.cliente_telefono, cli.domicilio_calle + " " + cli.domicilio_piso + " " + cli.domicilio_depto + " - " + cli.localidad_nombre, cli.cliente_fechaNacimiento, cli.cliente_habilitado); // Se agrega una fila a la tabla
        //        tablaDeResultados.Rows[table.Rows.Count - 1].Cells[0].Value = "..."; // Boton de modificar
        //    }
        //}

        // TODO: {M} IMPACTAR MODIFICACION EN LA TABLA
        public void buscarCliente()
        {
            table.Clear();
            string consultaRoles =
                "SELECT c.cliente_id, c.cliente_nombre, c.cliente_apellido, c.cliente_dni, c.cliente_mail, c.cliente_telefono, " +
                        "d.domicilio_id, d.domicilio_calle, d.domicilio_piso, d.domicilio_depto, d.domicilio_codpostal, " +
                        "l.localidad_id, l.localidad_nombre, c.cliente_fechaNacimiento, c.cliente_habilitado " +
                "FROM cliente c JOIN domicilio d ON c.idDomicilio = d.domicilio_id " +
                               "JOIN localidad l ON d.idLocalidad = l.localidad_id " +
                "WHERE c.cliente_eliminado = 0";

            string nombreAFiltrar = nombre.Text;
            string apellidoAFiltrar = apellido.Text;
            string dniAFiltrar = dni.Text;
            string mailAFiltrar = mail.Text;

            if (!string.IsNullOrWhiteSpace(nombreAFiltrar))
            {
                consultaRoles += string.Format(" AND c.cliente_nombre LIKE '%{0}%'", nombreAFiltrar);//EXACTO '{0}'
            }
            if (!string.IsNullOrWhiteSpace(apellidoAFiltrar))
            {
                consultaRoles += string.Format(" AND c.cliente_apellido LIKE '%{0}%'", apellidoAFiltrar);//LIBRE '%{0}%'
            }
            if (!string.IsNullOrWhiteSpace(dniAFiltrar))
            {
                consultaRoles += string.Format(" AND c.cliente_dni LIKE '{0}'", dniAFiltrar);//LIBRE '%{0}%'
            }
            if (!string.IsNullOrWhiteSpace(mailAFiltrar))
            {
                consultaRoles += string.Format(" AND c.cliente_mail LIKE '%{0}%'", mailAFiltrar);//LIBRE '%{0}%'
            }

            SqlCommand seleccionarRoles = new SqlCommand(consultaRoles, dbOfertas);
            SqlDataReader dataReader = seleccionarRoles.ExecuteReader();

            //// Se guarda en clientes la respuesta al SELECT 
            //// (en formato List<Clientes> para que sea mas facil acceder y filtrar elementos)
            clientesSeleccionados = convertirSelectAListaClientes(dataReader);

            dataReader.Close();

            foreach (var cli in clientesSeleccionados)
            {
                table.Rows.Add(cli.cliente_id, cli.cliente_nombre, cli.cliente_apellido, cli.cliente_dni, cli.cliente_mail, cli.cliente_telefono, cli.domicilio_calle + " " + cli.domicilio_piso + " " + cli.domicilio_depto + " - " + cli.localidad_nombre, cli.cliente_fechaNacimiento, cli.cliente_habilitado); // Se agrega una fila a la tabla
                tablaDeResultados.Rows[table.Rows.Count - 1].Cells[0].Value = "..."; // Boton de modificar
            }
        }


        private List<Clientes> convertirSelectAListaClientes(SqlDataReader dataReader)
        {
            List<Clientes> listaDeClientes = new List<Clientes>();

            while (dataReader.Read())
            {
                Clientes cliente = new Clientes();
                cliente.cliente_id = (int) dataReader.GetValue(0);
                cliente.cliente_nombre = dataReader.GetValue(1).ToString();
                cliente.cliente_apellido = dataReader.GetValue(2).ToString();
                cliente.cliente_dni = (int)dataReader.GetValue(3);
                cliente.cliente_mail = dataReader.GetValue(4).ToString();
                cliente.cliente_telefono = (int)dataReader.GetValue(5);
                cliente.domicilio_id = (int)dataReader.GetValue(6);
                cliente.domicilio_calle = dataReader.GetValue(7).ToString();
                cliente.domicilio_piso = (int)dataReader.GetValue(8);
                cliente.domicilio_depto = dataReader.GetValue(9).ToString();
                cliente.domicilio_codigoPostal = (int)dataReader.GetValue(10);
                cliente.localidad_id = (int)dataReader.GetValue(11);
                cliente.localidad_nombre = dataReader.GetValue(12).ToString();
                cliente.cliente_fechaNacimiento = DateTime.Parse(dataReader.GetValue(13).ToString());
                cliente.cliente_habilitado = (bool) dataReader.GetValue(14);

                listaDeClientes.Add(cliente);
            }

            return listaDeClientes;
        }
     
    }
}
