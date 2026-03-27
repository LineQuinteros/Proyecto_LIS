using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos_LIS
{
    public class Examenes
    {

        [Key] public int Id     { get; set; }
        [Display(Name = "EXAMEN")]
        public string exam_nombre { get; set; }
        [Display(Name = "UNIDADES")]
        public string exam_unidad { get; set; }
        [Display(Name = "REFERENCIAS")]
        public string exam_referencia { get; set; }


        List<Resultados>? Resultados { get; set; } = new List<Resultados>();
    }
}
