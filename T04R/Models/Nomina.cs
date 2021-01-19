using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T04R.Models
{
    public class Nomina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Sueldo")]
        public double Sueldo { get; set; }
        [Display(Name = "Tiempo trabajado")]
        public string TiempoTrabajo { get; set; }
        [Display(Name = "Bono")]
        public double Bono { get; set; }
        [Display(Name = "Impuestos")]
        public double IVA { get; set; }
        [Display(Name = "Fecha")]
        public ICollection<Empleado> Empleados { get; set; }
    }
}