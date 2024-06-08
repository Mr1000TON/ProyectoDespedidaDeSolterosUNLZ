using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebUsuario.Controllers
{
    [Authorize]
    public class EventosController : Controller
    {
        private IServicioEventos eventoService;
        private IPersonaService personaService;

        public EventosController(IServicioEventos _eventoService, IPersonaService _personaService)
        {
            this.eventoService = _eventoService;
            this.personaService = _personaService;
        }

        // GET: EventosController
        public ActionResult Index()
        {
            var eventos = this.eventoService.GetAllEventosViewModel();

            return View(eventos);
        }

        // GET: EventosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: EventosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        } 

            // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                /*
                 provincia
                 localidad
                 Codigopostal 
                 Calle --> KM28 Segundo camino al fondo
                -numero  -- 
                 piso opcional 
                 depto opcional 

                 */


                Persona personaAgasajada = new Persona();
                personaAgasajada.Nombre = collection["Nombre"].ToString();
                personaAgasajada.Apellido = collection["Apellido"].ToString();
                personaAgasajada.Email = collection["Email"].ToString();
                personaAgasajada.Telefono = collection["Telefono"].ToString();
                personaAgasajada.Borrado = false;
                personaAgasajada.Direccion = collection["Direccion"].ToString();

                int IdPersonaAgasajada = personaService.AgregarNuevaPersona(personaAgasajada);
                

                
                
                Evento eventoNuevo = new Evento();
                eventoNuevo.IdPersonaAgasajada = IdPersonaAgasajada;

                eventoNuevo.CantidadPersonas = int.Parse(collection["CantidadPersonas"].ToString());
                eventoNuevo.Visible = true;
                eventoNuevo.IdUsuario = int.Parse(HttpContext.User.Claims.First(x=> x.Type=="usuarioSolterout").Value); // HttpContext.User.Identity.Id;
                eventoNuevo.FechaEvento = DateTime.Parse(collection["FechaEvento"].ToString());
                eventoNuevo.IdTipoEvento = int.Parse(collection["IdTipoEvento"].ToString());
                eventoNuevo.NombreEvento = collection["NombreEvento"].ToString();
                eventoNuevo.IdEstadoEvento = 2; //Pendiente de Aprobacion


                this.eventoService.PostNuevoEvento(eventoNuevo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        

        // POST: EventosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
