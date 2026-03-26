using API_Consumer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos_LIS;

namespace LIS.MVC.Controllers
{
    [Authorize]
    public class PacientesController : Controller
    {
        // GET: PacientesController
        public ActionResult Index()
        {
            var paciente = Crud<Pacientes>.GetAll();
            return View(paciente);
        }

        // GET: PacientesController/Details/5
        public ActionResult Details(int id)
        {
            var paciente = Crud<Pacientes>.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pacientes paciente)
        {
            try
            {
                Crud<Pacientes>.Create(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paciente);
            }
        }

        // GET: PacientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var paciente = Crud<Pacientes>.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: PacientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pacientes paciente)
        {
            try
            {
                Crud<Pacientes>.Update(id, paciente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paciente);
            }
        }

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var paciente = Crud<Pacientes>.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: PacientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pacientes paciente)
        {
            try
            {
                Crud<Pacientes>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paciente);
            }
        
        }
    }
}
