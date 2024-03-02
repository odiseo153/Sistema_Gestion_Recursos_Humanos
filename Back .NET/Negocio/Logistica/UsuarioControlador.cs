
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using Modelos.Modelos;
using Negocio.Context;

namespace Negocio.Logistica
{
    public class UsuarioControlador
    {
        private GestionDatabaseContext context;
        private IMapper mapper;

        public UsuarioControlador(IMapper mapper,GestionDatabaseContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult UserById(string id)
        {
            var user = context.Usuarios.Find(Guid.Parse(id));
            if (user == null) {

                return new JsonResult(new
                {
                    message = "no se encontro usuario con ese id",
                    Code = StatusCodes.Status404NotFound
                });
            }

            return new JsonResult(user);
        }

        public IActionResult Uses()
        {

            return new JsonResult(context.Usuarios.ToList());
        }


        public IActionResult Login(string usuario,string clave)
        {
            var user = context.Usuarios.FirstOrDefault(x => x.ClaveAcceso.Equals(clave) && x.NombreUsuario.Equals(usuario));
            if (user == null)
            {

                return new JsonResult(new
                {
                    message = "no se encontro usuario con esas credenciales",
                    Code = StatusCodes.Status404NotFound
                });
            }

            return new JsonResult(new
            {
                message = "Bienvenido",
                Code = StatusCodes.Status200OK
            });
        }

        public IActionResult CrearUsuario(CrearUsuarioDTO user)
        {
            var usuario = mapper.Map<Usuario>(user);

            var usuarioExistente = context.Usuarios.FirstOrDefault(x => 
            x.NombreUsuario.ToLower().Equals(user.NombreUsuario) &&
            x.ClaveAcceso.Equals(user.ClaveAcceso));

            if(usuarioExistente != null) {
                return new JsonResult(new
                {
                    message = "ya existe un usuario con ese correo y clave",
                    Code = StatusCodes.Status201Created
                });
            }

            usuario.UsuarioId = Guid.NewGuid();
            context.Usuarios.Add(usuario);
            context.SaveChanges();


            return new JsonResult(new
            {
                message = "El usuario fue creado con exito",
                Code = StatusCodes.Status201Created
            });
        }

        public IActionResult ActualizarUsuario(Usuario NewUser)
        {
            var user = context.Usuarios.Find(NewUser.UsuarioId);
            
            if(user == null)
            {
                return new JsonResult(new
                {
                    message = "El usuario con ese id no existe",
                    Code = StatusCodes.Status201Created
                });
            }
            string nombreUser = user.NombreUsuario;

            user.NombreUsuario = NewUser.NombreUsuario ?? user.NombreUsuario;
            user.ClaveAcceso = NewUser.ClaveAcceso ?? user.ClaveAcceso;
            user.Rol = NewUser.Rol ?? user.Rol;

            context.SaveChanges();

            return new JsonResult(new
            {
                message = $"El usuario {nombreUser} a sido actualizado con exito",
                Code = StatusCodes.Status201Created
            });
        }

        public IActionResult Delete(string id)
        {
            var user = context.Usuarios.Find(Guid.Parse(id));

            if(user == null)
            {
                return new JsonResult(new
                {
                    message = "El usuario con ese id no existe",
                    Code = StatusCodes.Status201Created
                });
            }
            string nombreUser = user.NombreUsuario;

            context.Usuarios.Remove(user);
            context.SaveChanges();

            return new JsonResult(new
            {
                message = $"El usuario {nombreUser} a sido eliminado con exito",
                Code = StatusCodes.Status201Created
            });
        }


    }
}
