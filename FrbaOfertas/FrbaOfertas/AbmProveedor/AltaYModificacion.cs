using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaYModificacion : BarraDeOpciones
    {
        public AltaYModificacion()
        {
            InitializeComponent();
        }

        protected void desactivarErrores()
        {
            errorRazonSocial.Clear();
            errorMail.Clear();
            errorTelefono.Clear();
            errorCUIT.Clear();
            errorRubro.Clear();
            errorNombre.Clear();
            errorCalle.Clear();
            errorPiso.Clear();
            errorDepto.Clear();
            errorLocalidad.Clear();
            errorCodigoPostal.Clear();
        }

        protected bool validacionCampos()
        {
            bool camposOk = true;

            if (string.IsNullOrWhiteSpace(razonSocial.Text))
            {
                errorRazonSocial.SetError(razonSocial, "Campo Obligatorio");
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
            if (string.IsNullOrWhiteSpace(CUIT.Text))
            {
                errorCUIT.SetError(CUIT, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(rubro.Text))
            {
                errorRubro.SetError(rubro, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(nombre.Text))
            {
                errorNombre.SetError(nombre, "Campo Obligatorio");
                camposOk = false;
            }
            if (string.IsNullOrWhiteSpace(calle.Text))
            {
                errorCalle.SetError(calle, "Campo Obligatorio");
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

            if (!string.IsNullOrWhiteSpace(CUIT.Text) && !Regex.IsMatch(CUIT.Text, @"^[0-9]{2}-[0-9]{8}-[0-9]$"))
            {
                errorCUIT.SetError(CUIT, "Se debe respetar el formato de un CUIT\nEjemplo de CUIT: \"23-41345344-5\"");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(calle.Text) && Regex.IsMatch(calle.Text, @"[^A-Za-z\s0-9]"))
            {
                errorCalle.SetError(calle, "Ingresar caracteres alfanumericos");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(piso.Text) && Regex.IsMatch(piso.Text, @"[^0-9]"))
            {
                errorPiso.SetError(piso, "Ingresar caracteres numericos");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(depto.Text) && Regex.IsMatch(depto.Text, @"[^a-zA-Z ]"))
            {
                errorDepto.SetError(depto, "Ingresar caracteres alfabeticos");
                camposOk = false;
            }

            if (!string.IsNullOrWhiteSpace(localidad.Text) && Regex.IsMatch(localidad.Text, @"[^A-Za-z\s0-9]"))
            {
                errorLocalidad.SetError(localidad, "Ingresar caracteres alfanumericos");
                camposOk = false;
            }
            if (!string.IsNullOrWhiteSpace(codigoPostal.Text) && Regex.IsMatch(codigoPostal.Text, @"[^0-9]"))
            {
                errorCodigoPostal.SetError(codigoPostal, "Ingresar caracteres numericos");
                camposOk = false;
            }

            return camposOk;
        }

        protected virtual void confirmar_Click(object sender, EventArgs e) { }

    }
}
