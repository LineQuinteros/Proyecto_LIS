using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos_LIS
{
    public class Pacientes
    {
        [Key] public int Id { get; set; }

        [Display(Name = "CÉDULA")]
        public string pac_cedula {  get; set; }
        [Display(Name = "NOMBRES")]
        public string pac_nombres { get; set; }
        [Display(Name = "APELLIDOS")]
        public string pac_apellidos { get; set; }
        [Display(Name = "FECHA NACIMIENTO")]
        public DateOnly Paciente_Fecha_Nac { get; set; }
        [Display(Name = "TELÉFONO")]
        public string pac_telefono {  get; set; }
        [Display(Name = "CORREO")]
        public string pac_correo { get; set; }

        List<Ordenes>? Ordenes { get; set; } = new List<Ordenes>();


    }
}
