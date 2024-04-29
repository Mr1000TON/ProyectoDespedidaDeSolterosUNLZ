using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{

    //Definiendo a una entidad que represente a las personas del sistema
    public class Personas
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string DireccionCalle { get; set; }
        public int DireccionNumero { get; set; }
        public int DireccionPiso  { get; set; }
        public int DireccionDepartamento  { get; set; }
        public string DireccionLocalidad { get; set; }
        public string DireccionProvincia { get; set; }
        public int DireccionCodigoPostal { get; set; }
        public string Telefono {  get; set; }
        public string Email {  get; set; }
    }


}
