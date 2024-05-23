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
            Servicio servicios = sServicio.ObtenerServicioId(IdServicio);

            if (servicios == null)
                return NotFound();
            else
                return Ok(servicios);

        }

        [HttpPost("NuevoServicio")]
        public IActionResult NuevoServicio([FromBody] Servicio servicios)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            sServicio.AgregarServicio(servicios);

            return Ok();
        }

        [HttpPut("ModificarServicio/{IdServicio:int}")]
        public IActionResult ModificarServicio(int IdServicio, [FromBody] Servicio servicios)
        {
            ServicioDeServicios sServicios = new ServicioDeServicios();
            sServicios.ModificarServicio(IdServicio,servicios);
            return Ok();
        }

        [HttpPatch("BorradoLogicoServicio/{IdServicio:int}")]
        public IActionResult BorradoLogicoPersona(int IdServicio)
        {
            ServicioDeServicios sServicios = new ServicioDeServicios();
            sServicios.BorradoLogicoServicio(IdServicio);
            return Ok(); 
        }

        [HttpPatch("DesacerBorradoLogicoServicio/{IdServicio:int}")]
        public IActionResult DesacerBorradoLogicoServicio(int IdServicio)
        {
            ServicioDeServicios sServicios = new ServicioDeServicios();
            sServicios.DesacerBorradoLogicoServicio(IdServicio);
            return Ok(); 
        }


        [HttpDelete("BorrardoFisicoServicio/{IdServicio:int}")]
        public IActionResult BorrarServicio(int IdServicio)
        {
            ServicioDeServicios sServicios = new ServicioDeServicios();
            sServicios.BorradoFisicoServicio(IdServicio);
            return Ok();
        }
        
    }
}
