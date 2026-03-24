
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using API_Consumer;
using Modelos_LIS;
using LIS.Servicios;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using LIS.Servicios.Interfaces;
using LIS.API;

namespace LIS.Servicios
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Login(string email, string password)
        {
            var usuarios = Crud<Medicos>.GetAll();

            foreach (var usuario in usuarios)
            {
                if (usuario.med_correo == email)
                {
                    //BCrypt compara el texto plano con el Hash de la base de datos
                    if (BCrypt.Net.BCrypt.Verify(password, usuario.med_password))
                    {
                        var datosUsuario = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.med_nombres),
                        new Claim(ClaimTypes.Email, usuario.med_correo),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    };

                        var credencialDigital = new ClaimsIdentity(datosUsuario, "Cookies");
                        var usuarioAutenticado = new ClaimsPrincipal(credencialDigital);

                        await _httpContextAccessor.HttpContext.SignInAsync("Cookies", usuarioAutenticado);
                        return true;
                    }
                }
            }
            return false;
        }



        public async Task<bool> Register( Medicos medicos)
        {
            //Verificamos duplicados con endpoints específicos
            var usuarioExistente = Crud<Medicos>.GetAll()
                 .FirstOrDefault(u => u.med_correo == medicos.med_correo);

            if (usuarioExistente != null)
            {
                Console.WriteLine("Error: El correo ya está registrado.");
                return false;
            }


            try
            {
               
                Crud<Medicos>.Create(medicos);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }
    }
}