using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos_LIS;

namespace LIS.API.Data
{
    public class LISAPIContext : DbContext
    {
        public LISAPIContext (DbContextOptions<LISAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Modelos_LIS.Especialidades> Especialidades { get; set; } = default!;
        public DbSet<Modelos_LIS.Examenes> Examenes { get; set; } = default!;
        public DbSet<Modelos_LIS.Pacientes> Pacientes { get; set; } = default!;
        public DbSet<Modelos_LIS.Medicos> Medicos { get; set; } = default!;
        public DbSet<Modelos_LIS.Ordenes> Ordenes { get; set; } = default!;
        public DbSet<Modelos_LIS.Resultados> Resultados { get; set; } = default!;
    }
}
