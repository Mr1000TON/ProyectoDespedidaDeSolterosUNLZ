using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ControladorLocalidad : Controller
    {
        [HttpGet("ObtenerLocalidad")]
        public IActionResult Index()
        {

            ServicioLocalidad sLocalidad = new ServicioLocalidad();
            return Ok(sLocalidad.Get());

        }

        [HttpGet("ObtenerIdLocalidad/{IdLocalidad:int}")]
        public IActionResult GetLocalidadId(int IdLocalidad)
        {
            ServicioLocalidad sLocalidad = new ServicioLocalidad(); 
            Localidad localidad = sLocalidad.GetLocalidadId(IdLocalidad);


            if (localidad == null) 
                return NotFound();
            else 
                return Ok(localidad);
        }

        [HttpPost("AgregarLocalidad")]
        public IActionResult AgregarLocalidad([FromBody] Localidad localidad)
        {
            ServicioLocalidad sLocalidad = new ServicioLocalidad();

            bool resultado = sLocalidad.AgregarLocalidad(localidad);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity(); 
        }

        [HttpPut("ModificarLocalidad/{IdLocalidad:int}")]
        public IActionResult ModificarLocalidad(int IdLocalidad, [FromBody] Localidad localidad)
        {
            ServicioLocalidad sLocalidad = new ServicioLocalidad();

            bool resultado = sLocalidad.ModificarLocalidad(IdLocalidad, localidad);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity(); 

        }

        [HttpDelete("EliminarLocalidad/{IdLocalidad:int}")]
        public IActionResult EliminarLocalidad(int IdLocalidad)
        {
            ServicioLocalidad sLocalidad = new ServicioLocalidad();
            bool resultado = sLocalidad.EliminarLocalidad(IdLocalidad);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity(); 
        }
    }
}
