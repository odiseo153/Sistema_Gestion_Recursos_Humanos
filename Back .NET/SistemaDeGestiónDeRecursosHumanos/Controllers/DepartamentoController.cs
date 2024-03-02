using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using Negocio.Logistica;

namespace SistemaDeGestiónDeRecursosHumanos.Controllers
{
    public class DepartamentoController : Controller
    {
        private DepartamentoControlador context;

        public DepartamentoController(DepartamentoControlador depa)
        {
                
            this.context = depa;
        }

        [HttpGet("Departamento")]
        public IActionResult departamentos()
        {
            return context.Los_Departamentos();
        }

        [HttpGet("Departamento/{id}")]
        public IActionResult departamentosById(string id)
        {
            return context.DepartamentoById(id);
        }

        [HttpGet("Departamento_Empleado/{id}")]
        public IActionResult departamentoEmpleados(string id)
        {
            return context.Empleados_Departamento(id);
        }

        [HttpPost("Departamento")]
        public IActionResult Creardepartamento(CrearDepartamentoDTO depa)
        {
            return context.CrearDepartamento(depa);
        }
    }
}
