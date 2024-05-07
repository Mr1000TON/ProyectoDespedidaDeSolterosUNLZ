using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorEvento : Controller
    {
        [HttpGet("ObtenerEvento")]
        public IActionResult Get()
        {
            ServicioEventos sEventos = new ServicioEventos();
            return Ok(sEventos.Get());
        }

        [HttpGet("ObtenerIdEvento/{IdEvento:int}")]
        public IActionResult GetIdEvento(int IdEvento)
        {
            ServicioEventos sEvento = new ServicioEventos();
            Evento eventos = sEvento.GetEventoId(IdEvento);

            if (eventos == null)
                return NotFound();
            else
                return Ok(eventos); 
        }

        [HttpPost("NuevoEvento")]
        public IActionResult AgregarEvento(Evento evento)
        {
            ServicioEventos sEventos = new ServicioEventos();
            bool resultado = sEventos.AgregarNuevoEvento(evento);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity(); 
        }

        [HttpPut("ModificarEvento/{IdEvento:int}")]
        public IActionResult ModificarEvento(int IdEvento, [FromBody] Evento evento)
        {

            ServicioEventos sEventos = new ServicioEventos();
            bool resultado = sEventos.ModificarEvento(IdEvento, evento);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity();

        }


        [HttpDelete("BorrarEvento/{IdEvento:int}")]
        public IActionResult BorrarEvento(int IdEvento)
        {
            ServicioEventos sEventos = new ServicioEventos();
            bool resutado = sEventos.EliminarEvento(IdEvento);

            if (resutado)
                return Ok();
            else
                return UnprocessableEntity(); 
        }

    }
}
