using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorPersona : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            return Ok(sPersonas.GetPersonas());
        }

        [HttpGet("{IdPersona:int}")]

        public IActionResult GetId(int IdPersona)
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            Personas personas = sPersonas.GetPersonasId(IdPersona);

            if (personas == null)
                return NotFound(); 
            else 
                return Ok(personas);

        } 

    }
}
