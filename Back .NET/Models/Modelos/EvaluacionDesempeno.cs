using System;
using System.Collections.Generic;

namespace Modelos.Modelos
{
    public partial class EvaluacionDesempeno
    {
        public Guid EvaluacionId { get; set; }
        public Guid? EmpleadoId { get; set; }

        public string? CompetenciasEvaluadas { get; set; }
        public string? Resultados { get; set; }
        public DateTime? FechaEvaluacion { get; set; }

        public virtual Empleado? Empleado { get; set; }
    }
}
