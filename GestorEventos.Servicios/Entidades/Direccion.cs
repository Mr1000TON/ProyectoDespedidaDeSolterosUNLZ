using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Direccion
    {

        public string IdDireccion { get; set; }
        public string DireccionCalle { get; set; }
        public int DireccionNumero { get; set; }
        public int DireccionPiso { get; set; }
        public int DireccionDepartamento { get; set; }
        public bool Borrado { get; set; }


    }
}
