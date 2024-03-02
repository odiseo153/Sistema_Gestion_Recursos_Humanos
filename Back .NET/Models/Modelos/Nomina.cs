using System;
using System.Collections.Generic;

namespace Modelos.Modelos
{
    public partial class Nomina
    {
        public Nomina()
        {
            HistorialPagos = new HashSet<HistorialPago>();
        }

        public Guid NominaId { get; set; }
        public Guid? EmpleadoId { get; set; }
        public string? PeriodoPago { get; set; }
        public decimal? CalculosSalariales { get; set; }
        public decimal? Deducciones { get; set; }
        public decimal? Bonificaciones { get; set; }
        public decimal? TotalPagar { get; set; }
        public DateTime? FechaGeneracion { get; set; }

        public virtual Empleado? Empleado { get; set; }
        public virtual ICollection<HistorialPago> HistorialPagos { get; set; }
    }
}
