using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioLocalidad
    {

        IEnumerable<Localidad> Localidad { get; set; }

        public ServicioLocalidad()
        {

            Localidad = new List<Localidad>
            {

                new Localidad
                {
                    IdLocalidad = 1
                },
                new Localidad
                {
                    IdLocalidad = 2
                }

            };


        }


        public IEnumerable<Localidad> Get()
        {
            return Localidad;
        }

        public Localidad GetLocalidadId(int IdLocalidad)
        {
            try
            {
                Localidad localidad = Localidad.Where(x => x.IdLocalidad == IdLocalidad).First();
                return localidad; 
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
