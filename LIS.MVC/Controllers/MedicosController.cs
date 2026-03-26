using API.Consumer;
using API_Consumer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos_LIS;

namespace LIS.MVC.Controllers
{
    [Authorize]
    public class MedicosController : Controller
    {
        // GET: MedicosController
        public ActionResult Index()
        {
            var medico = Crud<Medicos>.GetAll();
            return View(medico);
        }

        // GET: MedicosController/Details/5
        public ActionResult Details(int id)
        {
            var medico = Crud<Medicos >.GetById(id);
            if (medico == null)
            {
                return NotFound();
            }
            return View(medico);
        }


        private List<SelectListItem> GetEspecialidades()
        {
            var especialidad = Crud<Especialidades>.GetAll();
            return especialidad.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = $"{e.Id} {e.espe_nombre}"
            }).ToList();
        }

        // GET: MedicosController/Create
        public ActionResult Create()
        {
            ViewBag.Especialidades = GetEspecialidades();
            return View();
        }

        // POST: MedicosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicos medico)
        {
            try
            {
                Crud<Medicos>.Create(medico);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(medico);
            }
        }

        // GET: MedicosController/Edit/5
        public ActionResult Edit(int id)
        {
            var medico = Crud<Medicos>.GetById(id);

            if (medico == null)
            {
                return NotFound();
            }

            ViewBag.Especialidades = GetEspecialidades();

            return View(medico);
        }

        // POST: MedicosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Medicos medico)
        {
            try
            {
                Crud <Medicos>.Update(id, medico);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(medico);
            }
        }

        // GET: MedicosController/Delete/5
        public ActionResult Delete(int id)
        {
            var medico = Crud<Ordenes>.GetById(id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: MedicosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Medicos medico)
        {
            try
            {
                Crud<Ordenes>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(medico);
            }
        }
    }
}
