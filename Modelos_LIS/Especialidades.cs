using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos_LIS
{
    public class Especialidades
    {
        [Key] public int Id { get; set; }
        [Display(Name = "ESPECIALIDAD")]
        public string espe_nombre {  get; set; }
        [Display(Name = "DESCRIPCIÓN")]
        public string espe_descripcion {  get; set; }

        List<Medicos> Medicos { get; set; } = new List<Medicos>();
    }
}
