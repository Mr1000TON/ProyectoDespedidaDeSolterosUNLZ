using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ControladorServicio : Controller
    {


        [HttpGet("ObtenerServicios")]
        public IActionResult Servicios()
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            return Ok(sServicio.ObtenerServicios());
        }

        [HttpGet("ObtenerServicio/{IdServicio:int}")]

        public IActionResult ServicioId(int IdServicio)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            Servicios servicios = sServicio.ObtenerServicioId(IdServicio);

            if (servicios == null)
                return NotFound();
            else
                return Ok(servicios);

        }

        [HttpPost("NuevoServicio")]
        public IActionResult NuevoServicio([FromBody] Servicios servicios)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            sServicio.AgregarServicio(servicios);

            return Ok();
        }

        [HttpPut("ModificarServicio/{IdServicio:int}")]
        public IActionResult ModificarServicio([FromBody] Servicios servicios)
        {
            return Ok();
        }

        [HttpPatch("ModificarDatoServicio{IdServicio:int}")]
        public IActionResult ModificarDatoServicio(int IdServicio)
        {
            return Ok();
        }

        [HttpDelete("BorrarServicio/{IdServicio:int}")]
        public IActionResult BorrarServicio(int IdServicio)
        {
            return Ok();
        }
        
    }
}
