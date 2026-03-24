using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelos_LIS
{
    public class Medicos
    {
        [Key] public int Id { get; set; }
        public string med_cedula { get; set; }
        public string med_nombres   { get; set; }
        public string med_apellidos { get; set; }
        public string med_telefono { get; set; }
        public string med_correo { get; set; }

        public string med_password { get; set; }

        [ForeignKey("especialidadId")]
        public int especialidadId {  get; set; }
        public Especialidades? Especialidad { get; set; }


        List<Ordenes>? Ordenes { get; set; } = new List<Ordenes>();


    }
}
