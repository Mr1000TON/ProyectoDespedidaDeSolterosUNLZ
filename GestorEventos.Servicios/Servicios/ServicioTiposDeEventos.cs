using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioTiposDeEventos
    {


        public IEnumerable<TipoEvento> TipoEventos { get; set;}

        public ServicioTiposDeEventos()
        {
            TipoEventos = new List<TipoEvento>
            {
                new TipoEvento
                {
                    IdTipoEvento = 1,
                    Descripcion = "Despedida de Solteros"
                },

                new TipoEvento
                {
                    IdTipoEvento = 2,
                    Descripcion = "Despedida de Solteras"
                }
            };
        }


        public IEnumerable<TipoEvento> GetTipoEventos()
        {
            return this.TipoEventos; 
        }

        public TipoEvento GetTipoEventoId(int IdEvento)
        {
            try
            {
                TipoEvento evento = TipoEventos.Where(x => x.IdTipoEvento == IdEvento).First(); 
                return evento;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
