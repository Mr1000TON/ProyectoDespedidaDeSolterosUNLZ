using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioProvincia
    {

        public IEnumerable<Provincia> Provincias { get; set; }

        public ServicioProvincia()
        {

            Provincias = new List<Provincia>
            {


                new Provincia
                {
                    IdProvincia = 1
                },
                new Provincia
                {
                    IdProvincia = 2
                }



            };


        }
        public IEnumerable<Provincia> Get()
        {
            return Provincias;
        }

        public Provincia GetProvinciaId(int IdProvincia)
        {
            try
            {
                Provincia provincia = Provincias.Where(x => x.IdProvincia == IdProvincia).First();
                return provincia;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
