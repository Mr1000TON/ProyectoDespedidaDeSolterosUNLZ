using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Evento
    {

        public int IdEvento { get; set; }
        public int IdTipoDeDespedida { get; set; }
        public int IdPersonaAgasajada {  get; set; }
        public int IdPersonaContacto {  get; set; }
        public string Nombre {  get; set; } 
        public string FechaEvento {  get; set; }
        public int CantPersonas { get; set; }


    }
}
