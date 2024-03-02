using System;
using System.Collections.Generic;

namespace Modelos.Modelos
{
    public partial class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ClaveAcceso { get; set; }
        public string? Rol { get; set; }
    }
}
