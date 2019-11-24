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


        protected bool validacionCampos()
        {
            bool camposOk = true;

            if (string.IsNullOrWhiteSpace(nombre.Text))
            {
                errorNombre.SetError(nombre, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(apellido.Text))
            {
                errorApellido.SetError(apellido, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(dni.Text))
            {
                errorDni.SetError(dni, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(mail.Text))
            {
                errorMail.SetError(mail, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(telefono.Text))
            {
                errorTelefono.SetError(telefono, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(calle.Text))
            {
                errorDireccion.SetError(calle, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(localidad.Text))
            {
                errorLocalidad.SetError(localidad, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(codigoPostal.Text))
            {
                errorCodigoPostal.SetError(codigoPostal, "Campo Obligatorio");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(nombre.Text) && Regex.IsMatch(nombre.Text, @"[^a-zA-Z ]"))
            {
                errorNombre.SetError(nombre, "Ingresar caracteres alfabeticos");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(apellido.Text) && Regex.IsMatch(apellido.Text, @"[^a-zA-Z ]"))
            {
                errorApellido.SetError(apellido, "Ingresar caracteres alfabeticos");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(dni.Text) && Regex.IsMatch(dni.Text, @"[^0-9]"))
            {
                errorDni.SetError(dni, "Ingresar caracteres numericos");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(mail.Text) && !Regex.IsMatch(mail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {
                errorMail.SetError(mail, "Ingresar mail valido");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(telefono.Text) && Regex.IsMatch(telefono.Text, @"[^0-9]"))
            {
                errorTelefono.SetError(telefono, "Ingresar caracteres numericos");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(calle.Text) && Regex.IsMatch(calle.Text, @"[^A-Za-z\s0-9]"))
            {
                errorDireccion.SetError(calle, "Ingresar caracteres alfanumericos");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(piso.Text) && Regex.IsMatch(piso.Text, @"[^0-9]"))
            {
                errorDireccion.SetError(piso, "Ingresar caracteres numericos");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(depto.Text) && Regex.IsMatch(depto.Text, @"[^a-zA-Z ]"))
            {
                errorDireccion.SetError(depto, "Ingresar caracteres alfabetico");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(localidad.Text) && Regex.IsMatch(localidad.Text, @"[^A-Za-z\s0-9]"))
            {
                errorLocalidad.SetError(localidad, "Ingresar caracteres alfanumerico");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(codigoPostal.Text) && Regex.IsMatch(codigoPostal.Text, @"[^0-9]"))
            {
                errorCodigoPostal.SetError(codigoPostal, "Ingresar caracteres numericos");
                camposOk = false;
            }

            return camposOk;
        }


        protected void desactivarErrores()
        {
            errorNombre.Clear();
            errorApellido.Clear();
            errorDni.Clear();
            errorMail.Clear();
            errorTelefono.Clear();
            errorDireccion.Clear();
            errorLocalidad.Clear();
            errorCodigoPostal.Clear();
        }

        protected virtual void confirmarCliente_Click(object sender, EventArgs e) { }

        //
    }
}

