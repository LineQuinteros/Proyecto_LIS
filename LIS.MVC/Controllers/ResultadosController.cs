using API_Consumer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos_LIS;

namespace LIS.MVC.Controllers
{
    [Authorize]
    public class ResultadosController : Controller
    {
        // GET: ResultadosController
        public ActionResult Index()
        {
            var resultado = Crud<Resultados>.GetAll();
            return View(resultado);
        }

        // GET: ResultadosController/Details/5
        public ActionResult Details(int id)
        {
            var resultado = Crud<Resultados>.GetById(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }


        private List<SelectListItem> GetOrdenes()
        {
            var orden = Crud<Ordenes>.GetAll();
            return orden.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = $"{o.Id}"
            }).ToList();
        }

        private List<SelectListItem> GetExamenes()
        {
            var examenes = Crud<Examenes>.GetAll();
            return examenes.Select(ex => new SelectListItem
            {
                Value = ex.Id.ToString(),
                Text = $"{ex.Id}{ex.exam_nombre}"
            }).ToList();
        }

        // GET: ResultadosController/Create
        public ActionResult Create()
        {
            ViewBag.Ordenes = GetOrdenes();
            ViewBag.Examenes = GetExamenes();
            return View();
        }

        // POST: ResultadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resultados resultado)
        {
            try
            {
                Crud<Resultados>.Create(resultado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(resultado);
            }
        }

        // GET: ResultadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var resultado = Crud<Resultados>.GetById(id);

            if (resultado == null)
            {
                return NotFound();
            }

            ViewBag.Ordenes = GetOrdenes();
            ViewBag.Examenes = GetExamenes();

            return View(resultado);
        }

        // POST: ResultadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Resultados resultados)
        {
            try
            {
                Crud<Resultados>.Update(id, resultados);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(resultados);
            }
        }

        // GET: ResultadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var resultado = Crud<Resultados>.GetById(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // POST: ResultadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Resultados resultados)
        {
            try
            {
                Crud<Resultados>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(resultados);
            }
        }
    }
}
