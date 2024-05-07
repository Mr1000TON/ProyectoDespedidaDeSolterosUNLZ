using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Localidad
    {
        public int IdLocalidad {  get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal {  get; set; }
        public bool Visible { get; set; }


    }
}
