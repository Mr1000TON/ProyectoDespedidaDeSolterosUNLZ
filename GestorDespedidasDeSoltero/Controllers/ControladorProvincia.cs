using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorProvincia : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            ServicioProvincia sPorvincia = new ServicioProvincia(); 
            return Ok(sPorvincia.Get());
        }

        [HttpGet("{IdProvincia:int}")]
        public IActionResult GetProvinciaId(int IdProvincia)
        {
            ServicioProvincia sProvincia = new ServicioProvincia();
            Provincia provincia = sProvincia.GetProvinciaId(IdProvincia);

            if (provincia == null)
                return NotFound();
            else
                return Ok(provincia); 

        }

    }
}
