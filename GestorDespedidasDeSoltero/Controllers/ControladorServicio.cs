using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ControladorServicio : Controller
    {


        [HttpGet]
        public IActionResult Get()
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            return Ok(sServicio.Get());
        }

        [HttpGet("{IdServicio:int}")]

        public IActionResult GetServicioId(int IdServicio)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            Servicios servicios = sServicio.GetServiciosId(IdServicio);

            if (servicios == null)
                return NotFound();
            else
                return Ok(servicios);

        }

        [HttpPost("NuevoServicio")]
        public IActionResult PostNuevoServicio([FromBody] Servicios nServicio)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            sServicio.agregarServicio(nServicio);

            return Ok();
        }


    }
}
