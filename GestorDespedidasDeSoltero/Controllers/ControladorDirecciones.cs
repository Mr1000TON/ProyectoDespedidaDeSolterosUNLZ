using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorDirecciones : ControllerBase
    {

        [HttpGet("ObtenerDirecciones")]
        public IActionResult ObtenerDirecciones()
        {
            ServicioDireccion sDireccion = new ServicioDireccion();
            return Ok(sDireccion.Get());
        }

        [HttpGet("ObtenerIdDireccion/{IdDireccion:int}")]
        public IActionResult ObtenerIdDireccion(int IdDireccion)
        {
            ServicioDireccion sDireccion = new ServicioDireccion();
            Direccion direccion = sDireccion.GetDireccion(IdDireccion);

            if (direccion == null)
                return NotFound();
            else
                return Ok(direccion);

        }

        [HttpPost("AgregarDireccion")]
        public IActionResult AgregarDireccion([FromBody] Direccion direccion)
        {
            ServicioDireccion sDireccion = new ServicioDireccion();

            bool resultado = sDireccion.AgregarDireccion(direccion);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity();
        }

        [HttpPut("ModificarDireccion/{IdDireccion:int}")]
        public IActionResult ModificarDireccion(int IdDireccion, [FromBody] Direccion direccion)
        {
            ServicioDireccion sDireccion = new ServicioDireccion();

            bool resultado = sDireccion.ModificarDireccion(IdDireccion, direccion);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity();
        }

        [HttpDelete("BorrarDireccion/{IdDireccion:int}")]
        public IActionResult EliminarDireccion(int IdDireccion)
        {
            ServicioDireccion sDireccion = new ServicioDireccion();

            bool resultado = sDireccion.EliminarDireccion(IdDireccion);

            if (resultado)
                return Ok();
            else
                return UnprocessableEntity(); 
        }
    }
}
