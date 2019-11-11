using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.AbmProveedor
{
    public class Proveedores
    {
        public int id {get; set;}
        public string razonSocial {get; set;}
        public int idDomicilio {get; set;}
        public string domicilio_calle { get; set; }
        public int domicilio_piso { get; set; }
        public string domicilio_depto { get; set; }
        public int domicilio_codpostal { get; set; }
        public int localidad_id { get; set; }
        public string localidad_nombre { get; set; }
        public string cuit {get; set;}
        public int telefono {get; set;}
        public string mail {get; set;}
        public int idRubro {get; set;}
        public string rubro { get; set; }
        public string nombreContacto {get; set;}
        public bool habilitado { get; set; }
    }
}
