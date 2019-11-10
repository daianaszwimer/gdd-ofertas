using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.AbmCliente
{
    public class Clientes
    {
        public int cliente_id;
	    public string cliente_nombre;
	    public string cliente_apellido;
	    public int cliente_dni;
	    public string cliente_mail;
	    public int cliente_telefono;
        public int domicilio_id;
        public string domicilio_calle;
	    public int domicilio_piso;
	    public string domicilio_depto;
	    public int domicilio_codigoPostal;
        public int localidad_id;
        public string localidad_nombre;
        public DateTime cliente_fechaNacimiento;
        public bool cliente_habilitado;

    }
}
