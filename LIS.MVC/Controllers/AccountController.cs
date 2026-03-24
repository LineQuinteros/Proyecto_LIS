using API.Consumer;
using Modelos_LIS;
using LIS.Servicios.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using API_Consumer;

namespace Libreria.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: Account
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            email = email.Trim().ToLower();

            if (await _authService.Login(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email o contraseña incorrectos.";
                return View("Index");
            }
        }

        private List<SelectListItem> GetEspecialidades()
        {
            var especialidades = Crud<Especialidades>.GetAll();
            return especialidades.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.espe_nombre
            }).ToList();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Especialidades = GetEspecialidades();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Medicos medicos)
        {
            medicos.med_correo = medicos.med_correo.Trim().ToLower();
            

            var usuario = Crud<Medicos>.GetAll()
                .FirstOrDefault(usuario => usuario.med_correo.ToLower() == medicos.med_correo);

            if (usuario != null)
            {
                ViewBag.ErrorMessage = "Esta cuenta ya está asociada a este correo";
                return View();
            }

            if (await _authService.Register(medicos))
            {
                return RedirectToAction("Index", "Account");
            }

            ViewBag.ErrorMessage = "Error al crear el usuario";
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            // Elimina la cookie de autenticación
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Account");
        }


    }
}
