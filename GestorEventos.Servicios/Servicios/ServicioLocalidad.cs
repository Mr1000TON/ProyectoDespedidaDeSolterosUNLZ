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
                    IdLocalidad = 1,
                    Nombre = "Coronel Suarez",
                    CodigoPostal = 7540,
                    Visible = true
                },
                new Localidad
                {
                    IdLocalidad = 2,
                    Nombre = "Pigue",
                    CodigoPostal = 8170,
                    Visible = true
                }

            };


        }


        public IEnumerable<Localidad> Get()
        {
            return Localidad.Where(x=>x.Visible == true);
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

        public bool AgregarLocalidad(Localidad localidad)
        {
            try
            {
                List<Localidad> lista = Localidad.ToList();
                lista.Add(localidad);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool ModificarLocalidad(int IdLocalidad, Localidad localidad)
        {
            try
            {
                var localidadAModificar = Localidad.Where(x => x.IdLocalidad == IdLocalidad).First();

                localidadAModificar.Nombre = localidad.Nombre;
                localidadAModificar.CodigoPostal = localidad.CodigoPostal;


                return true;
            }
            catch(Exception ex)
            {
                return false; 
            }
        }

        public bool EliminarLocalidad(int IdLocalidad)
        {
            try
            {
                var localidadAEliminar = Localidad.Where(x=>x.IdLocalidad == IdLocalidad).First();
                localidadAEliminar.Visible = false;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }


        }

    }
}
