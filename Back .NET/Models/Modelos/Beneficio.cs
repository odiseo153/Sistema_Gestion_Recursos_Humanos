using System;
using System.Collections.Generic;


namespace Modelos.Modelos
{
    public partial class Beneficio
    {
        public Guid BeneficioId { get; set; }
        public string? Descripcion { get; set; }
        public string? Cobertura { get; set; }
        public decimal? Costos { get; set; }
        public Guid? EmpleadoId { get; set; }

        public virtual Empleado? Empleado { get; set; }
    }
}
