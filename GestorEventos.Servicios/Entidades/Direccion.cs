using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Direccion
    {
        public int IdDireccion {  get; set; }
        public string Calle { get; set; }
        public string Piso {  get; set; }
        public string Departamento {  get; set; }
        public string NumeroCalle {  get; set; }
        public bool Visible {  get; set; }
    }
}
