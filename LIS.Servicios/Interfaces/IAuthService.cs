using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.Servicios.Interfaces
{
    public interface IAuthService
    {

        Task<bool> Login(string email, string password);
        Task<bool> Register(
            int Id,
            string med_cedula,
            string med_nombres,
            string med_apellidos,
            string med_telefono,
            string med_correo,
            string med_password
            );
    }
}
