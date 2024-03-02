using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using Negocio.Logistica;

namespace SistemaDeGestiónDeRecursosHumanos.Controllers
{
    public class EmpleadoController : Controller
    {
        private EmpleadoControlador empleado;

        public EmpleadoController(EmpleadoControlador empleado)
        {
            this.empleado = empleado;
        }

        [HttpGet("Empleados")]
        public IActionResult Obtener_Empleados()
        {
            return empleado.Empleados();
        }

        [HttpDelete("Empleados/{id}")]
        public IActionResult EliminarEmpleado(string id)
        {
            return empleado.Borrar_Empleado(id);
        }

        [HttpPut("Empleados")]
        public IActionResult ActualizarEmpleado([FromBody]ActualizarEmpleadoDTO empleadoNuevo)
        {
            return empleado.ActualizarEmpleado(empleadoNuevo);
        }

        [HttpGet("Empleados_Nombres")]
        public IActionResult NombreEmpleados()
        {
            return empleado.Empleados_Nombre_and_Id();
        }

        [HttpGet("Cantidad_Empleados")]
        public IActionResult Cantidad()
        {
            return empleado.Cantidad();
        }

        [HttpGet("Empleados/{id}")]
        public IActionResult Obtener_Empleado_By_Id(string id)
        {
            return empleado.EmpleadoById(id);
        }

        [HttpPost("Empleados")]
        public IActionResult Crear_Empleados([FromBody]CrearEmpleadoDTO empleado_)
        {
            return empleado.CrearEmpleado(empleado_);
        }
    }
}
