using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using Modelos.Modelos;
using Negocio.Logistica;

namespace SistemaDeGestiónDeRecursosHumanos.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioControlador usuarioControlador;

        public UsuarioController(UsuarioControlador user)
        {
            usuarioControlador = user;

        }

        [HttpPost("/Login")]
        public IActionResult Login(string usuario,string clave)
        {
            return usuarioControlador.Login(usuario,clave);
        }

        [HttpPost("/usuario")]
        public IActionResult CrearUsuario([FromBody]CrearUsuarioDTO user) 
        {
            return usuarioControlador.CrearUsuario(user);
        }

        [HttpGet("/usuarios")]
        public IActionResult Usuarios()
        {
            return usuarioControlador.Uses();
        }

        [HttpGet("/usuario/{id}")]
        public IActionResult GetById(string id)
        {
            return usuarioControlador.UserById(id);
        }

        [HttpPut("/usuario")]
        public IActionResult Update(Usuario user)
        {
            return usuarioControlador.ActualizarUsuario(user);
        }

        [HttpDelete("/usuario")]
        public IActionResult Delete(string id)
        {
            return usuarioControlador.Delete(id);
        }
    }
}
