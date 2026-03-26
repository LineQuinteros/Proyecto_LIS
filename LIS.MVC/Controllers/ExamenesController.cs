using API_Consumer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos_LIS;

namespace LIS.MVC.Controllers
{
    public class ExamenesController : Controller
    {
        [Authorize]
        // GET: ExamenesController
        public ActionResult Index()
        {
            var examen = Crud<Examenes>.GetAll();
            return View(examen);
        }

        // GET: ExamenesController/Details/5
        public ActionResult Details(int id)
        {
            var examen = Crud<Examenes>.GetById(id);
            if (examen == null)
            {
                return NotFound();
            }
            return View(examen);
        }

        // GET: ExamenesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamenesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Examenes examen)
        {
            try
            {
                Crud<Examenes>.Create(examen);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(examen);
            }
        }

        // GET: ExamenesController/Edit/5
        public ActionResult Edit(int id)
        {
            var examen = Crud<Examenes>.GetById(id);
            if (examen == null)
            {
                return NotFound();
            }
            return View(examen);
        }

        // POST: ExamenesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Examenes examen)
        {
            try
            {
                Crud<Examenes>.Update(id, examen);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(examen);
            }
        }

        // GET: ExamenesController/Delete/5
        public ActionResult Delete(int id)
        {
            var examen = Crud<Examenes>.GetById(id);
            if (examen == null)
            {
                return NotFound();
            }
            return View(examen);
        }

        // POST: ExamenesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Examenes examen)
        {
            try
            {
                Crud<Examenes>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(examen);
            }
        }
    }
}
