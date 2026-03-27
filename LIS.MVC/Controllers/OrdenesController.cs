using API_Consumer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos_LIS;

namespace LIS.MVC.Controllers
{
    public class OrdenesController : Controller
    {
        [Authorize]
        // GET: OrdenesController
        public async Task<ActionResult> Index()
        {
            var ordenes = Crud<Ordenes>.GetAll();
            return View(ordenes);
        }

        // GET: OrdenesController/Details/5
        public ActionResult Details(int id)
        {
            var orden = Crud<Ordenes>.GetById(id);
            if (orden == null) return NotFound();

            // Buscamos los datos adicionales usando los IDs de la orden
            var medico = Crud<Medicos>.GetById(orden.MedicoId);
            var paciente = Crud<Pacientes>.GetById(orden.PacienteId);

            // Guardamos el nombre completo (Nombres + Apellidos)
            ViewBag.NombreCompletoMedico = (medico != null)
                ? $"{medico.med_nombres} {medico.med_apellidos}"
                : "Médico no encontrado";

            ViewBag.NombreCompletoPaciente = (paciente != null)
                ? $"{paciente.pac_nombres} {paciente.pac_apellidos}"
                : "Paciente no encontrado";

            return View(orden);
        }
        private List<SelectListItem> GetMedicos()
        {
            var medicos = Crud<Medicos>.GetAll();
            return medicos.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = $"{e.Id} {e.med_nombres}"
            }).ToList();
        }
        private List<SelectListItem> GetPacientes()
        {
            var pacientes = Crud<Pacientes>.GetAll();
            return pacientes.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = $"{e.Id} {e.pac_nombres}"
            }).ToList();
        }


        private List<SelectListItem> GetExamenes()
        {
            var examenes = Crud<Examenes>.GetAll();
            return examenes.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = $"{e.Id} {e.exam_nombre}"
            }).ToList();
        }
        // GET: OrdenesController/Create
        public ActionResult Create()
        {
            ViewBag.Medicos = GetMedicos();
            ViewBag.Pacientes = GetPacientes();
            return View();
        }

        // POST: OrdenesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ordenes ordenes)
        {
            try
            {
                Crud<Ordenes>.Create(ordenes);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(ordenes);
            }
        }
        

        // GET: OrdenesController/Edit/5
        public ActionResult Edit(int id)
        {
            var orden = Crud<Ordenes>.GetById(id);

            if (orden == null)
            {
                return NotFound();
            }

            ViewBag.Medicos = GetMedicos();
            ViewBag.Pacientes = GetPacientes();

            return View(orden);
        }

        // POST: OrdenesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ordenes orden)
        {
            try
            {
                Crud<Ordenes>.Update(id, orden);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(orden);
            }
        }

        // GET: OrdenesController/Delete/5
        public ActionResult Delete(int id)
        {
            var ordenes = Crud<Ordenes>.GetById(id);

            if (ordenes == null)
            {
                return NotFound();
            }

            return View(ordenes);
        }

        // POST: OrdenesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ordenes ordenes)
        {
            try
            {
                Crud<Ordenes>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(ordenes);
            }
        }
    }
}
