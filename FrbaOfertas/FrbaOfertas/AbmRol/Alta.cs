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

namespace FrbaOfertas.AbmRol
{
    public partial class Alta : AltaYModificacion
    {
        public Alta()
        {
            InitializeComponent();
            buscarFuncionalidadesEnBaseDeDatos();
            habilitado.Visible = false;
            confirmar.Text = "Crear";
            desactivarErrores();
        }

        private bool crearRol()
        {
            SqlCommand insertarNuevoRol =
                new SqlCommand(
                    string.Format(
                        "INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Rol (rol_nombre) VALUES ('{0}'); SELECT SCOPE_IDENTITY()", 
                        nombre.Text), Helper.dbOfertas);

            SqlDataReader dataReader = Helper.realizarConsultaSQL(insertarNuevoRol);
            if (dataReader != null)
            {
                if (dataReader.Read())
                {
                    string idRol = dataReader.GetValue(0).ToString();
                    dataReader.Close();
                    SqlDataReader dataReaderFuncionalidades = insertarFuncionalidadesParaRol(idRol);
                    if (dataReaderFuncionalidades != null)
                    {
                        if (dataReaderFuncionalidades.RecordsAffected > 0)
                        {
                            dataReaderFuncionalidades.Close();
                            return true;
                        }
                        else
                        {
                            dataReaderFuncionalidades.Close();
                            return false;
                        }
                    }
                    else
                        return false;
                }
                else
                {
                    dataReader.Close();
                    return false;
                }
            }
            else
                return false;
        }

        private bool rolNoExiste()
        {
            SqlCommand chequearExistenciaDeRol =
                new SqlCommand(
                    string.Format(
                        "SELECT rol_id FROM NO_LO_TESTEAMOS_NI_UN_POCO.Rol " +
                        "WHERE rol_nombre='{0}'", nombre.Text), Helper.dbOfertas);
            SqlDataReader dataReader = Helper.realizarConsultaSQL(chequearExistenciaDeRol);
            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    dataReader.Close();
                    return false;
                }
                else
                {
                    dataReader.Close();
                    return true;
                }
            }
            else
                return false;
        }

        override protected void confirmar_Click(object sender, EventArgs e)
        {
            desactivarErrores();
            if (validacionCampos())
            {
                if (rolNoExiste())
                {
                    if (crearRol())
                    {
                        MessageBox.Show("El rol se creo exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido crear el rol correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("El rol ya existe", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
