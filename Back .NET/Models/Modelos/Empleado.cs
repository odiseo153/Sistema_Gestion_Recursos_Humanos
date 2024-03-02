using System;
using System.Collections.Generic;

namespace Modelos.Modelos
{
    public partial class Empleado
    {
        public Empleado()
        {
            Beneficios = new HashSet<Beneficio>();
            EvaluacionDesempenos = new HashSet<EvaluacionDesempeno>();
            Nominas = new HashSet<Nomina>();
            TareasProyectos = new HashSet<TareasProyecto>();
        }

        public Guid EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public Guid? DepartamentoId { get; set; }


        public virtual Departamento? Departamento { get; set; }
        public virtual ICollection<Beneficio> Beneficios { get; set; }
        public virtual ICollection<EvaluacionDesempeno> EvaluacionDesempenos { get; set; }
        public virtual ICollection<Nomina> Nominas { get; set; }
        public virtual ICollection<TareasProyecto> TareasProyectos { get; set; }
    }
}
