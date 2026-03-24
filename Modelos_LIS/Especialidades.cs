using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos_LIS
{
    public class Especialidades
    {
        [Key] public int Id { get; set; }
        public string espe_nombre {  get; set; }
        public string espe_descripcion {  get; set; }

        List<Medicos> Medicos { get; set; } = new List<Medicos>();
    }
}
