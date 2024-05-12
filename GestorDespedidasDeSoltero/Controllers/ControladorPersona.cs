using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorPersona : Controller
    {

        [HttpGet("ObtenerPersonas")]
        public IActionResult Get()
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            return Ok(sPersonas.ObtenerPersonas());
        }

        [HttpGet("ObtenerIdPersona/{IdPersona:int}")]

        public IActionResult GetId(int IdPersona)
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            Personas personas = sPersonas.ObtenerIdPersona(IdPersona);

            if (personas == null)
                return NotFound(); 
            else 
                return Ok(personas);

        }

        [HttpPost("AgregarNuevaPersona")]
        public IActionResult AgregarPersona([FromBody] Personas personas)
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            sPersonas.AgregarPersona(personas);
            return Ok();
        }

        [HttpPut("ModificarPersna/{IdPersona:int}")]
        public IActionResult ModificarPersona(int IdPersona, Personas personas)
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            sPersonas.ModificarPersona(IdPersona, personas);
            return Ok();
        }

        [HttpPatch("BorradoLogicoPersona/{IdPersona:int}")]
        public IActionResult BorradoLogicoPersona(int IdPersona)
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            sPersonas.BorradoLogicoPersona(IdPersona);
            return Ok();
        }

        [HttpPatch("DesacerBorradoLogicoPersona/{IdPersona:int}")]
        public IActionResult DesacerBorradoLogicoPersona(int IdPersona)
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            sPersonas.DesacerBorradoLogicoPersona(IdPersona);
            return Ok();
        }

        [HttpDelete("BorradoFisicoPersona/{IdPersona:int}")]
        public IActionResult BorradoFisicoPersona(int IdPersona)
        {
            ServicioPersonas sPersonas = new ServicioPersonas();
            sPersonas.BorradoFisicoPersona(IdPersona);
            return Ok();
        }
    }
}
