using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioDeServicios
    {

        public IEnumerable<Entidades.Servicios> Servicios { get; set; }

        public ServicioDeServicios()
        {

            Servicios = new List<Entidades.Servicios>
            {

                new Entidades.Servicios
                {
                    IdServicios = 1,
                    Descripcion = "Bar Hopping",
                    PrecioServicio = 25000
                },
                new Entidades.Servicios
                {
                    IdServicios = 2,
                    Descripcion = "Servicio de Transporte",
                    PrecioServicio = 20000
                },
                new Entidades.Servicios
                {
                    IdServicios = 3,
                    Descripcion = "Entradas de boliches incluidas",
                    PrecioServicio = 10000
                }
            };

        }


        public IEnumerable<Entidades.Servicios> Get()
        {
            return Servicios.Where(x=>x.Visible == true);
        }

        public Entidades.Servicios GetServiciosId(int IdServicio)
        {
            try
            {
                Entidades.Servicios servicio = Servicios.Where(x => x.IdServicios == IdServicio).First();
                return servicio;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool agregarServicio(Entidades.Servicios servicios)
        {
            try
            {
                List<Entidades.Servicios> lista = Servicios.ToList();
                lista.Add(servicios);
                return true; 
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public bool modificarServicio(int IdServicio, Entidades.Servicios servicios)
        {
            try
            {
                var servicioAModificar = Servicios.Where(x => x.IdServicios == IdServicio).First();

                servicioAModificar.Descripcion = servicios.Descripcion;
                servicioAModificar.PrecioServicio = servicios.PrecioServicio;
                servicioAModificar.PrecioServicio = servicios.PrecioServicio;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public bool eliminarServicio(int IdServicio)
        {
            try
            {
                var servicioAEliminar = Servicios.Where(x => x.IdServicios == IdServicio).First();

                servicioAEliminar.Visible = false;

                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
