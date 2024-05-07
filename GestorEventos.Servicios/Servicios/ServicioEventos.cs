using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioEventos
    {

        IEnumerable<Evento> Evento { get; set; }

        public ServicioEventos()
        {


            Evento = new List<Evento>
            {
                new Evento
                {
                    IdEvento = 1,
                    IdTipoDeDespedida = 1,
                    IdPersonaAgasajada = 1,
                    IdPersonaContacto = 1,
                    Nombre = "Juan",
                    FechaEvento = "29/4/24",
                    CantPersonas = 50,
                },
                new Evento
                {
                    IdEvento = 2,
                    IdTipoDeDespedida = 2,
                    IdPersonaAgasajada = 2,
                    IdPersonaContacto = 2,
                    Nombre = "Pepe",
                    FechaEvento = "30/4/24",
                    CantPersonas = 20
                },
            };
        }



        public IEnumerable<Evento> Get()
        {
            return Evento.Where(x=>x.Visible == true);
        }

        public Evento GetEventoId(int IdEvento)
        {
            try
            {
                Evento evento = Evento.Where(x => x.IdEvento == IdEvento).First(); 
                return evento;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AgregarNuevoEvento(Evento evento)
        {
            try
            {
                List<Evento> lista = Evento.ToList();
                lista.Add(evento);
                return true;
            }
            catch(Exception ex)
            {
                return false; 
            }
        }

        public bool ModificarEvento(int IdEvento, Evento evento)
        {
            try
            {
                var eventoAModificar = Evento.Where(x => x.IdEvento == IdEvento).First();

                eventoAModificar.IdTipoDeDespedida = evento.IdTipoDeDespedida;
                eventoAModificar.IdPersonaAgasajada = evento.IdPersonaAgasajada;
                eventoAModificar.IdPersonaContacto = evento.IdPersonaContacto;
                eventoAModificar.Nombre = evento.Nombre;
                eventoAModificar.FechaEvento = evento.FechaEvento;
                eventoAModificar.CantPersonas = evento.CantPersonas;

                return true; 
            }
            catch(Exception ex)
            {
                return false; 
            }
        }

        public bool EliminarEvento(int IdEvento)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
