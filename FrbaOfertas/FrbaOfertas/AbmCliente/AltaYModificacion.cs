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
    
    public abstract partial class AltaYModificacion : BarraDeOpciones
    {
        protected Clientes clienteAux;
        public AltaYModificacion()
        {
            InitializeComponent();
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
        }

        

        protected bool validarDatosIngresados()
        {
            //TODO: {M} VER CAMPO OBLIGATORIO
            //TODO: {M} VER ERROR PRIVIDER
            bool datosOk = true;

            //Validacion y obligatorio: Nombre
            if (Regex.IsMatch(nombre.Text, @"[^a-zA-Z ]"))
            {
                label13.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Apellido
            if (Regex.IsMatch(apellido.Text, @"[^a-zA-Z ]"))
            {
                label14.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Dni
            if (Regex.IsMatch(dni.Text, @"[^0-9]"))
            {
                label15.Visible = true;
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
                label16.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Telefono
            if (Regex.IsMatch(telefono.Text, @"[^0-9]") && telefono.Text.Length < 7 && telefono.Text.Length > 8)
            {
                label17.Visible = true;
                datosOk = false;
            }
            //Validacion y obligatorio: Calle
            if (Regex.IsMatch(calle.Text, @"[^A-Za-z\s0-9]"))
            {
                label18.Visible = true;
                datosOk = false;
            }
            //Validacion: Piso
            if (piso.Text.Length != 0)
            {
                if (Regex.IsMatch(piso.Text, @"[^0-9]"))
                {
                    label18.Visible = true;
                    datosOk = false;
                }
            }
            //Validacion: Depto
            if (localidad.Text.Length != 0)
            {
                if (Regex.IsMatch(localidad.Text, @"[^a-zA-Z ]"))
                {
                    label18.Visible = true;
                    datosOk = false;
                }
            }
            //Validacion: Localidad
            if (depto.Text.Length != 0)
            {
                if (Regex.IsMatch(depto.Text, @"[^A-Za-z\s0-9]"))
                {
                    label19.Visible = true;
                    datosOk = false;
                }
            }
            //Validacion y obligatorio: CodigoPostal
            if (Regex.IsMatch(codigoPostal.Text, @"[^0-9]"))
            {
                label20.Visible = true;
                datosOk = false;
            }
            return datosOk;
        }


        abstract protected void confirmarCliente_Click(object sender, EventArgs e);
 
    //
    }
}

