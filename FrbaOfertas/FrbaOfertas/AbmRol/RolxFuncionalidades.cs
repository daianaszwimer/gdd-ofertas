using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.AbmRol
{
    public class RolxFuncionalidades
    {
        public int id { get; set; }
        public string rol { get; set; }
        public bool habilitado { get; set; }
        public List<string> funcionalidades { get; set; }

        public RolxFuncionalidades()
        {
            funcionalidades = new List<string>();
        }
    }
}
