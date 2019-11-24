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

namespace FrbaOfertas.AbmCliente
{

    public partial class AltaYModificacion : BarraDeOpciones
    {
        public AltaYModificacion()
        {
            InitializeComponent();
        }


        //errorUsername.SetError(username, "Campo Obligatorio");
        protected bool camposObligatorios()
        {
            return true;
        }


        protected bool validarDatosIngresados()
        {
            //TODO: {M} VER CAMPO OBLIGATORIO
            //TODO: {M} VER ERROR PRIVIDER
            bool datosOk = true;

            //Validacion y obligatorio: Nombre
            if (Regex.IsMatch(nombre.Text, @"[^a-zA-Z ]"))
            {
                errorNombre.SetError(nombre, "Ingresar caracteres alfabeticos");
                datosOk = false;
            }
            //Validacion y obligatorio: Apellido
            if (Regex.IsMatch(apellido.Text, @"[^a-zA-Z ]"))
            {
                errorApellido.SetError(apellido, "Ingresar caracteres alfabeticos");
                datosOk = false;
            }
            //Validacion y obligatorio: Dni
            if (Regex.IsMatch(dni.Text, @"[^0-9]"))
            {
                errorDni.SetError(dni, "Ingresar caracteres numericos");
                datosOk = false;
            }
            //Validacion y obligatorio: Mail
            if (Regex.IsMatch(mail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {
                datosOk = true;
            }
            else
            {
                errorMail.SetError(mail, "Ingresar mail valido");
                datosOk = false;
            }
            //Validacion y obligatorio: Telefono
            if (Regex.IsMatch(telefono.Text, @"[^0-9]") && telefono.Text.Length < 7 && telefono.Text.Length > 8)
            {
                errorTelefono.SetError(telefono, "Ingresar caracteres numericos");
                datosOk = false;
            }
            //Validacion y obligatorio: Calle
            if (Regex.IsMatch(calle.Text, @"[^A-Za-z\s0-9]"))
            {
                errorDireccion.SetError(calle, "Ingresar caracteres alfanumericos");
                datosOk = false;
            }
            //Validacion: Piso
            if (piso.Text.Length != 0)
            {
                if (Regex.IsMatch(piso.Text, @"[^0-9]"))
                {
                    errorDireccion.SetError(piso, "Ingresar caracteres numericos");
                    datosOk = false;
                }
            }
            //Validacion: Depto

            if (Regex.IsMatch(depto.Text, @"[^a-zA-Z ]"))
            {
                errorDireccion.SetError(depto, "Ingresar caracteres numericos");
                datosOk = false;
            }


            //Validacion: Localidad
            if (Regex.IsMatch(localidad.Text, @"[^A-Za-z\s0-9]"))
            {
                errorLocalidad.SetError(localidad, "Ingresar caracteres numericos");
                datosOk = false;
            }

            //Validacion y obligatorio: CodigoPostal
            if (Regex.IsMatch(codigoPostal.Text, @"[^0-9]"))
            {
                errorCodigoPostal.SetError(codigoPostal, "Ingresar caracteres numericos");
                datosOk = false;
            }
            return datosOk;
        }


        protected virtual void confirmarCliente_Click(object sender, EventArgs e) { }


        //
    }
}

