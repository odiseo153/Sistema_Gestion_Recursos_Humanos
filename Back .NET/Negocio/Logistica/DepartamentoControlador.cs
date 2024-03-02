using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.DTO;
using Modelos.Modelos;
using Negocio.Context;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Negocio.Logistica
{
    public class DepartamentoControlador
    {
        private GestionDatabaseContext context;
        private IMapper mapper;

        public DepartamentoControlador(GestionDatabaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Los_Departamentos()
        {
            var depas = from depa in context.Departamentos select new { 
            nombre = depa.NombreDepartamento,
            id = depa.DepartamentoId
            };

            return new JsonResult(depas);
        }

        public IActionResult CrearDepartamento(CrearDepartamentoDTO departamento)
        {
            var depa = mapper.Map<Departamento>(departamento);

            depa.DepartamentoId = Guid.NewGuid();   
            
            context.Add(depa);
            context.SaveChanges();

            return new JsonResult(new
            {
                message= "Departamento creado con exito",
                code = StatusCodes.Status201Created
            });
        }

        public IActionResult DepartamentoById(string id)
        {
            var depa = context.Departamentos.Find(Guid.Parse(id));

            if(depa == null)
            {
                return new JsonResult(new
                {
                    message = "no existe departamento con ese id",
                    code = StatusCodes.Status404NotFound
                });
            }

            return new JsonResult(depa);
        }

      

        public IActionResult Empleados_Departamento(string id)
        {
            var depa_ = context.Departamentos.Include(x => x.Empleados).FirstOrDefault(x => x.DepartamentoId.Equals(Guid.Parse(id)));

            if (depa_ == null)
            {
                return new JsonResult(new
                {
                    message = "no existe departamento con ese id",
                    code = StatusCodes.Status404NotFound
                });
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Otras opciones según tus necesidades
            };

            // Serializar historial a JSON
            var jsonString = JsonSerializer.Serialize(depa_, options);

            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                StatusCode = 200
            };

        }
    }
}
