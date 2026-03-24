using Modelos_LIS;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.Servicios.Interfaces
{
    public interface IAuthService
    {

        Task<bool> Login(string email, string password);
        Task<bool> Register(Medicos medicos);
    }
}
