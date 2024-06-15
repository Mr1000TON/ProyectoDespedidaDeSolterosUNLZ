using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Usuario
    {
        public string nombre_usuario { get; set;}
        public string clave_usuario { get; set;}

        // FALSE = No es administrador, TRUE = Es administrador
        public bool tipo_usuario { get; set;}
    }
}
