using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class ActualizarEvaluacionDTO
    {
        public Guid? EvaluacionId { get; set; }
        public string? CompetenciasEvaluadas { get; set; }
        public string? Resultados { get; set; }
    }
}
