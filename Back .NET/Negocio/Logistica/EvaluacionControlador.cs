using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Modelos.DTO;
using Modelos.Modelos;

namespace Negocio.Logistica
{
    public class EvaluacionControlador
    {
        private GestionDatabaseContext context;
        private IMapper mapper;

        public EvaluacionControlador(IMapper mapper,GestionDatabaseContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult CrearEvaluacion(CrearEvaluacionDTO _evaluacion)
        {
            var empleado = context.Empleados.FirstOrDefault(x => x.EmpleadoId.Equals(_evaluacion.EmpleadoId));


            if (empleado == null)
            {
                return new JsonResult(new
                {
                    message = "No existe empleado con ese id",
                    code = StatusCodes.Status404NotFound
                });
            }

            var evaluacion = mapper.Map<EvaluacionDesempeno>(_evaluacion);

            evaluacion.EvaluacionId = Guid.NewGuid();
            evaluacion.FechaEvaluacion = DateTime.Now;
            
            context.Add(evaluacion);
            context.SaveChanges();


            return new JsonResult(new
            {
                message = "Evaluacion agregada con exito",
                code = StatusCodes.Status201Created
            });

        }

        public IActionResult ActualizarEvaluacion(ActualizarEvaluacionDTO eval)
        {
            var evaluacion = context.EvaluacionDesempenos.FirstOrDefault(x => x.EvaluacionId.Equals(eval.EvaluacionId));


            if (evaluacion == null)
            {
                return new JsonResult(new
                {
                    message = "No existe evaluacion con ese id",
                    code = StatusCodes.Status404NotFound
                });
            }


            evaluacion.Resultados = eval.Resultados ?? evaluacion.Resultados;
            evaluacion.CompetenciasEvaluadas = eval.CompetenciasEvaluadas ?? evaluacion.CompetenciasEvaluadas;


            context.SaveChanges();


            return new JsonResult(new
            {
                message = "Evaluacion Actualizada con exito",
                code = StatusCodes.Status201Created
            });

        }

        public IActionResult Obtener_Evaluaciones()
        {
            var evaluacion = context.EvaluacionDesempenos.ToList();

            if (evaluacion == null)
            {
                return new JsonResult(new
                {
                    message = "No hay evaluaciones",
                    code = StatusCodes.Status404NotFound
                });
            }

            return new JsonResult(evaluacion); 
        }

            public IActionResult Borrar_Evaluacion(string idEvaluacion)
        {
            var evaluacion = context.EvaluacionDesempenos.FirstOrDefault(x => x.EvaluacionId.Equals(Guid.Parse(idEvaluacion)));

            if (evaluacion == null)
            {
                return new JsonResult(new
                {
                    message = "No hay evaluacion con ese Id",
                    code = StatusCodes.Status404NotFound
                });
            }

            context.EvaluacionDesempenos.Remove(evaluacion);
            context.SaveChanges();

            return new JsonResult(new
            {
                message="Evaluacion eliminada",
                code = StatusCodes.Status200OK
            });
        }


        public IActionResult Obtener_Evaluaciones_By_Empleado(string idEmpleado)
        {
            var evaluacion = context.EvaluacionDesempenos.Where(x => x.EmpleadoId.Equals(Guid.Parse(idEmpleado)));

            if (evaluacion == null)
            {
                return new JsonResult(new
                {
                    message = "No hay evaluacion para ese empleado",
                    code = StatusCodes.Status404NotFound
                });
            }

            return new JsonResult(evaluacion);
        }


    }
}
