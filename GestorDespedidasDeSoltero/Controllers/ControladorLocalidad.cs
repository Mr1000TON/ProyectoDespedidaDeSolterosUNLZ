using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ControladorLocalidad : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            ServicioLocalidad sLocalidad = new ServicioLocalidad();
            return Ok(sLocalidad.Get());

        }

        [HttpGet("{IdLocalidad:int}")]
        public IActionResult GetLocalidadId(int IdLocalidad)
        {
            ServicioLocalidad sLocalidad = new ServicioLocalidad(); 
            Localidad localidad = sLocalidad.GetLocalidadId(IdLocalidad);


            if (localidad == null) 
                return NotFound();
            else 
                return Ok(localidad);


        }

    }
}
