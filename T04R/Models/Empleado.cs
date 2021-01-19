using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T04R.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public string FechaDeNacimiento { get; set; }
        public int IDTipo { get; set; }
        [ForeignKey("IDTipo")]
        [Display(Name = "Tipo")]
        public Tipo Tipo { get; set; }
        public int IDDepartamento { get; set; }
        [ForeignKey("IDDepartamento")]
        [Display(Name = "Departamento")]
        public Departamento Departamento { get; set; }
        public int IDNomina { get; set; }
        [ForeignKey("IDNomina")]
        [Display(Name = "IDNomina")]
        public Nomina Nomina { get; set; }

        public ICollection<Tipo> Tipos { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
        public ICollection<Nomina> Nominas { get; set; }
    }
}