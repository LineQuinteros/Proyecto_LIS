using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Consumer;

namespace LIS.MVC.Controllers
{
    public class MedicosController : Controller
    {
        // GET: MedicosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MedicosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicosController/Edit/5
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

        // GET: MedicosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicosController/Delete/5
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
