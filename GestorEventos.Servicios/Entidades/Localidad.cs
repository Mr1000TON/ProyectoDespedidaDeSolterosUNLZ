using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Localidad
    {

        public string CodigoPostal {  get; set; }
        public string Nombre { get; set; }
        public int IdLocalidad { get; set; }
        public bool Borrado { get; set; }



    }
}
