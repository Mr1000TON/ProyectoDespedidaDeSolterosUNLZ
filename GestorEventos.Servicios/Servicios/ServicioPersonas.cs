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
                    Visible = true
                },
                new Personas{ IdPersona = 2,
                    Nombre = "Manuel" ,
                    Apellido = "Perez" ,
                    Email = "Manuel777Gamer@gmail.com" ,
                    Telefono = "+2",
                    Visible = true
                }
            };
        }
        public IEnumerable<Personas> GetPersonas()
        {
            return this.Personas.Where(x=>x.Visible == true); 
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

        public bool AgregarPersona(Personas personas)
        {
            try
            {
                List<Personas> lista = Personas.ToList();

                return true; 
            }
            catch(Exception ex)
            {
                return false;
            }
        }


    }
}
