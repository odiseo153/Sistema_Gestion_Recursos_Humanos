using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class CrearUsuarioDTO
    {
        public string? NombreUsuario { get; set; }
        public string? ClaveAcceso { get; set; }
        public string? Rol { get; set; }
    }
}
