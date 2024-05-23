using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: ControladorServicios
        public ActionResult Index()
        {
            ServicioDeServicios sServicios = new ServicioDeServicios();
            return View(sServicios.ObtenerServicios());
        }

        // GET: ControladorServicios/Details/5
        public ActionResult Details(int id)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            return View(sServicio.ObtenerServicioId(id));
        }

        // GET: ControladorServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControladorServicios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                ServicioDeServicios sServicios = new ServicioDeServicios();
                Servicio servicio = new Servicio();

                servicio.Descripcion = collection["Descripcion"].ToString();
                servicio.PrecioServicio = decimal.Parse(collection["PrecioServicio"].ToString());

                sServicios.AgregarServicio(servicio);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ControladorServicios/Edit/5
        public ActionResult Edit(int id)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();
            return View(sServicio.ObtenerServicioId(id));
        }

        // POST: ControladorServicios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ServicioDeServicios sServicios = new ServicioDeServicios();
                Servicio servicio = new Servicio();

                servicio.IdServicio = int.Parse(collection["IdServicio"].ToString());
                servicio.Descripcion = collection["Descripcion"].ToString();
                servicio.PrecioServicio = decimal.Parse(collection["PrecioServicio"].ToString());

                sServicios.ModificarServicio(id,servicio);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ControladorServicios/Delete/5
        public ActionResult Delete(int id)
        {
            ServicioDeServicios sServicio = new ServicioDeServicios();

            Servicio servicio = sServicio.ObtenerServicioId(id);

            return View(servicio);
        }

        // POST: ControladorServicios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ServicioDeServicios sServicio = new ServicioDeServicios();
                sServicio.BorradoLogicoServicio(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
