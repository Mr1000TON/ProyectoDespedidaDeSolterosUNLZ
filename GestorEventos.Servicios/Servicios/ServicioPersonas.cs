using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioPersonas
    {
        //IEnumerable se utiliza para generar una lista de objetos

        public IEnumerable<Personas> Personas { get; set; }
        
        public ServicioPersonas() {

            Personas = new List<Personas>{

                new Personas{ IdPersona = 1,
                    Nombre = "Jorgelito" ,
                    Apellido = "Garcia" ,
                    Email = "JorgelitoGarciaGamer@gmail.com" ,
                    Telefono = "+1",
                    DireccionProvincia = "Provincia1",
                    DireccionLocalidad = "Localidad1",
                    DireccionDepartamento = 0,
                    DireccionPiso = 0,
                    DireccionCalle = "Calle1",
                    DireccionNumero = 111,
                    DireccionCodigoPostal = 1111
                },
                new Personas{ IdPersona = 2,
                    Nombre = "Manuel" ,
                    Apellido = "Perez" ,
                    Email = "Manuel777Gamer@gmail.com" ,
                    Telefono = "+2",
                    DireccionProvincia = "Provincia2",
                    DireccionLocalidad = "Localidad2",
                    DireccionDepartamento = 0,
                    DireccionPiso = 0,
                    DireccionCalle = "Calle2",
                    DireccionNumero = 222,
                    DireccionCodigoPostal = 2222
                }
            };
        }
            public IEnumerable<Personas> GetPersonas()
            {
                return this.Personas; 
            }

            public Personas? GetPersonasId(int IdPersona)
            {

                try
                {
                    Personas personas = Personas.Where(x => x.IdPersona == IdPersona).First();
                    return personas;
                }
                catch(Exception ex)
                {
                    return null; 
                }

            }

    }
}
