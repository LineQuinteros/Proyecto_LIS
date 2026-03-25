using API_Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos_LIS;

namespace LIS.MVC.Controllers
{
    public class EspecialidadesController : Controller
    {
        // GET: EspecialidadesController
        public ActionResult Index()
        {
            var especialidad = Crud<Especialidades>.GetAll();
            return View(especialidad);
        }

        // GET: EspecialidadesController/Details/5
        public ActionResult Details(int id)
        {
            var especialidad = Crud<Especialidades>.GetById(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // GET: EspecialidadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especialidades especialidad)
        {
            try
            {
                Crud<Especialidades>.Create(especialidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(especialidad);
            }
        }

        // GET: EspecialidadesController/Edit/5
        public ActionResult Edit(int id)
        {
            var especialidad = Crud<Especialidades>.GetById(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // POST: EspecialidadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Especialidades especialidad)
        {
            try
            {
                Crud<Especialidades>.Update(id, especialidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(especialidad);
            }
        }
        

        // GET: EspecialidadesController/Delete/5
        public ActionResult Delete(int id)
        {
            var especialidad = Crud<Especialidades>.GetById(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // POST: EspecialidadesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Especialidades especialidad)
        {
            try
            {
                Crud<Especialidades>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(especialidad);
            }
        }
    }
}
