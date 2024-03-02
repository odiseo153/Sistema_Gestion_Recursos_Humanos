using System;
using System.Collections.Generic;

namespace Modelos.Modelos
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public Guid DepartamentoId { get; set; }
        public string? NombreDepartamento { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
