using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelos_LIS
{
    public class Ordenes
    {
        [Key] public int Id { get; set; }
        [Display(Name = "FECHA")]
        public DateTime orden_fecha { get; set; }
        public bool orden_estado { get; set; }

        [ForeignKey("MedicoId")]
        public int MedicoId { get; set; }
        public Medicos? Medico { get; set; }

        [ForeignKey("PacienteId")]
        public int PacienteId { get; set; }
        public Pacientes? Paciente { get; set; }

        List<Resultados>? Resultados {  get; set; } = new List<Resultados>();
    }
}
