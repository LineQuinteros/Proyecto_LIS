using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos_LIS
{
    public class Examenes
    {

        [Key] public int Id     { get; set; }
        public string exam_nombre { get; set; }
        public string exam_unidad { get; set; }
        public string exam_referencia { get; set; }


        List<Resultados>? Resultados { get; set; } = new List<Resultados>();
    }
}
