using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class CrearTareaDTO
    {
        public string? Descripcion { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Estado { get; set; }
        public Guid? EmpleadoId { get; set; }
    }
}
