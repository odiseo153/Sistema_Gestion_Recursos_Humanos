using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.DTO;
using Modelos.Modelos;
using Negocio.Context;

namespace Negocio.Logistica
{
    public class EmpleadoControlador
    {
        private GestionDatabaseContext context;
        private IMapper mapper;

        public EmpleadoControlador(IMapper mapper,GestionDatabaseContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public IActionResult CrearEmpleado(CrearEmpleadoDTO empleado)
        {
            if(empleado == null)
            {
                return new JsonResult(new
                {
                    message = "no puede mandar datos vacios",
                    code = StatusCodes.Status201Created
                });
            }

            var empleado_ = mapper.Map<Empleado>(empleado);

            empleado_.EmpleadoId = Guid.NewGuid();

            context.Empleados.Add(empleado_);
            context.SaveChanges();

            return new JsonResult(new
            {
                message = "Empleado creado con exito",
                code = StatusCodes.Status201Created
            });

        }

        public IActionResult Empleados()
        {
            return new JsonResult(context.Empleados.Select(x => new
            {
                EmpleadoId=x.EmpleadoId,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                FechaNacimiento=x.FechaNacimiento,
                Genero=x.Genero,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                CorreoElectronico = x.CorreoElectronico,
                FechaContratacion = x.FechaContratacion,
                DepartamentoId = x.DepartamentoId
            }).AsNoTracking().ToList());
        }

        public IActionResult Empleados_Nombre_and_Id()
        {
            var empleados = from empleado in context.Empleados select new
            {
                nombre= empleado.Nombre+" "+empleado.Apellido,
                id=empleado.EmpleadoId
            };

            return new JsonResult(empleados);
        }

        public IActionResult EmpleadoById(string id)
        {
            var empleado = context.Empleados.Find(Guid.Parse(id));

            if(empleado == null)
            {
                return new JsonResult(new
                {
                    message = "no se encontro empleado con ese Id",
                    code = StatusCodes.Status404NotFound
                });
            }


            return new JsonResult(empleado);
        }

        public IActionResult ActualizarEmpleado(ActualizarEmpleadoDTO empleadoNuevo)
        {
            var empleado = context.Empleados.Find(empleadoNuevo.EmpleadoId);

            if (empleado == null)
            {
                return new JsonResult(new
                {
                    message = "no se encontro empleado con ese Id",
                    code = StatusCodes.Status404NotFound
                });
            }

            empleado.Apellido = empleadoNuevo.Apellido ?? empleado.Apellido;
            empleado.Telefono = empleadoNuevo.Telefono ?? empleado.Telefono;
            empleado.Direccion = empleadoNuevo.Direccion ?? empleado.Direccion;
            empleado.CorreoElectronico = empleadoNuevo.CorreoElectronico ?? empleado.CorreoElectronico;
            empleado.FechaContratacion = empleadoNuevo.FechaContratacion ?? empleado.FechaContratacion;
            empleado.FechaNacimiento = empleadoNuevo.FechaNacimiento ?? empleado.FechaNacimiento;
            empleado.Genero = empleadoNuevo.Genero ?? empleado.Genero;
            empleado.Nombre = empleadoNuevo.Nombre ?? empleado.Nombre;


            context.SaveChanges();

            return new JsonResult(new
            {
                message = "Empleado actualizado correctamente",
                code = StatusCodes.Status200OK
            });
        }


        public IActionResult Cantidad()
        {
            var mujeres = context.Empleados.Where(x => x.Genero.ToLower().Equals("femenino"));
            var hombres = context.Empleados.Where(x => x.Genero.ToLower().Equals("masculino"));
            var otros = context.Empleados.Where(x => x.Genero.ToLower().Equals("otro"));



            return new JsonResult(new
            {
                hombres = hombres.Count(),
                mujeres = mujeres.Count(),
                otros = otros.Count()
            });
        }



        public IActionResult Borrar_Empleado(string id)
        {
            var empleado = context.Empleados.Find(Guid.Parse(id));
            var tareaEmpleasdo = context.TareasProyectos.Where(x => x.EmpleadoId.Equals(Guid.Parse(id)));
            string nombre = empleado.Nombre;

            if (empleado == null)
            {
                return new JsonResult(new
                {
                    message = "no se encontro empleado con ese Id",
                    code = StatusCodes.Status404NotFound
                });
            }

            if(tareaEmpleasdo != null)
            {

            foreach (var item in tareaEmpleasdo)
            {
                context.TareasProyectos.Remove(item);
            }
           
            }

            context.Empleados.Remove(empleado);
            context.SaveChanges();

            return new JsonResult(new
            {
                message = "Se elimino el empleado: "+nombre,
                code = StatusCodes.Status200OK
            });
        }
    }
}
