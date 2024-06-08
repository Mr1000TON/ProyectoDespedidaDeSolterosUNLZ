using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorEvento : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            ServicioEventos sEventos = new ServicioEventos();
            return Ok(sEventos.Get());
        }

        [HttpGet("{IdEvento:int}")]
        public IActionResult GetIdEvento(int IdEvento)
        {
            ServicioEventos sEvento = new ServicioEventos();
            Evento eventos = sEvento.GetEventoId(IdEvento);

            if (eventos == null)
                return NotFound();
            else
                return Ok(eventos);

        }




    }
}
