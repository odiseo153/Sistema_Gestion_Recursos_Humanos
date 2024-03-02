using System;
using System.Collections.Generic;

namespace Modelos.Modelos
{
    public partial class TareasProyecto
    {
        public Guid TareaId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Estado { get; set; }
        public Guid? EmpleadoId { get; set; }

        public virtual Empleado? Empleado { get; set; }
    }
}
