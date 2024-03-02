using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using Modelos.Modelos;
using Negocio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logistica
{
    public class TareaControlador
    {
        private GestionDatabaseContext context;
        private IMapper mapper;

        public TareaControlador(GestionDatabaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Obtener_Tareas_De_Un_Empleado(string id)
        {
            return new JsonResult(context.TareasProyectos.Where(x => x.EmpleadoId.Equals(Guid.Parse(id))));
        }

        public IActionResult Obtener_Tarea_By_Id(string id)
        {
            return new JsonResult(context.TareasProyectos.FirstOrDefault(x => x.TareaId.Equals(Guid.Parse(id))));
        }

        public IActionResult Actualizar_Tarea(string id,CrearTareaDTO Ntarea)
        {

            var tarea = context.TareasProyectos.FirstOrDefault(x => x.TareaId.Equals(Guid.Parse(id)));

            if(tarea == null)
            {
                return new JsonResult(new
                {
                    message = "no se encontro tarea con ese Id",
                    code = StatusCodes.Status200OK
                });
            }

            tarea.Estado = Ntarea.Estado ?? tarea.Estado;
            tarea.Descripcion = Ntarea.Descripcion ?? tarea.Descripcion;
            tarea.FechaVencimiento = Ntarea.FechaVencimiento ?? tarea.FechaVencimiento;

            context.SaveChanges();


            return new JsonResult(new
            {
                message = "Tarea actualizada correctamente",
                code = StatusCodes.Status200OK
            });
        }

        public IActionResult Crear_Tarea(CrearTareaDTO tarea)
        {
            var tareaNueva = mapper.Map<TareasProyecto>(tarea);

            tareaNueva.TareaId = Guid.NewGuid();

            context.TareasProyectos.Add(tareaNueva);
            context.SaveChanges();

            return new JsonResult(new
            {
                message = "Tarea creada con exito",
                code = StatusCodes.Status201Created
            });
        }

        public IActionResult Eliminar_Tarea(string id)
        {
            var tarea = context.TareasProyectos.FirstOrDefault(x => x.TareaId.Equals(Guid.Parse(id)));

            if (tarea == null)
            {
                return new JsonResult(new
                {
                    message = "No se encontro tarea con ese Id",
                    code = StatusCodes.Status404NotFound
                });
            }

            context.TareasProyectos.Remove(tarea);
            context.SaveChanges();

            return new JsonResult(new
            {
                message = "se elimino la tarea"+tarea.Descripcion,
                code = StatusCodes.Status200OK
            });
        }

    }
}
