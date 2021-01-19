using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T04R.Models
{
    public class EmpleadoViewModel
    {
        public Tipo Tipo { get; set; }
        public Departamento Departamento { get; set; }   
        public Nomina Nomina { get; set; }
        public Empleado Empleado { get; set; }

        public ICollection<Tipo> Tipos { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
        public ICollection<Nomina> Nominas { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}