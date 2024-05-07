using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ControladorServicio : Controller
    {


        [HttpGet("ObtenerServicio")]
        public IActionResult Get()
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            return Ok(sServicio.Get());
        }

        [HttpGet("ObtenerIdServicio/{IdServicio:int}")]

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

        [HttpPut("ModificarServicio/{IdServicio:int}")]
        public IActionResult PutNuevoServicio(int IdServicio,[FromBody] Servicios servicios)
        {
            ServicioDeServicios sServicios = new ServicioDeServicios();
            bool resultado = sServicios.modificarServicio(IdServicio, servicios);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity();
        }

        [HttpDelete("EliminarServicio/{IdServicio:int}")]
        public IActionResult DeleteServicio(int IdServicio)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            bool resultado = sServicio.eliminarServicio(IdServicio);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity(); 
        }
    }
}
