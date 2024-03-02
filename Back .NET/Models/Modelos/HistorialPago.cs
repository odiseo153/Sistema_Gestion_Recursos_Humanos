using System;
using System.Collections.Generic;

namespace Modelos.Modelos
{
    public partial class HistorialPago
    {
        public Guid HistorialPagoId { get; set; }
        public Guid? NominaId { get; set; }
        public string? DetallesTransaccion { get; set; }
        public DateTime? FechaPago { get; set; }

        public virtual Nomina? Nomina { get; set; }
    }
}
