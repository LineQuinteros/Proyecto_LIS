using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos_LIS
{
    public class Pacientes
    {
        [Key] public int Id { get; set; }
        public string pac_cedula {  get; set; }
        public string pac_nombres { get; set; }
        public string pac_apellidos { get; set; }
        public DateOnly Paciente_Fecha_Nac { get; set; }
        public string pac_telefono {  get; set; }
        public string pac_correo { get; set; }

        List<Ordenes>? Ordenes { get; set; } = new List<Ordenes>();


    }
}
