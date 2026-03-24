using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelos_LIS
{
    public class Resultados
    {
        [Key] public int Id { get; set; }
        public string res_valor {  get; set; }
        public string res_comentario { get; set; }

        [ForeignKey("OrdenId")]
        public int OrdenId { get; set; }
        public Ordenes? Orden { get; set; }

        [ForeignKey("ExamenId")]
        public int ExamenId { get; set; }
        public Examenes? Examen { get; set; }
    }
}
