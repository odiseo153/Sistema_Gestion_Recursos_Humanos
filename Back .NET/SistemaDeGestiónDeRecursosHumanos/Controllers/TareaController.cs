using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using Negocio.Logistica;

namespace SistemaDeGestiónDeRecursosHumanos.Controllers
{
    public class TareaController : Controller
    {
        private TareaControlador controlador;

        public TareaController(TareaControlador tarea)
        {
            this.controlador = tarea;
        }

        [HttpGet("Tareas/{id}")]
        public IActionResult Obtener_Tarea(string id)
        {
            return controlador.Obtener_Tareas_De_Un_Empleado(id);
        }

        [HttpGet("Tarea/{id}")]
        public IActionResult Obtener_Tarea_By_Id(string id)
        {
            return controlador.Obtener_Tarea_By_Id(id);
        }

        [HttpPut("Tarea/{id}")]
        public IActionResult Actualizar_Tarea(string id,[FromBody]CrearTareaDTO tarea)
        {
            return controlador.Actualizar_Tarea(id,tarea);
        }

        [HttpDelete("Tarea/{id}")]
        public IActionResult Eliminar_Tarea(string id)
        {
            return controlador.Eliminar_Tarea(id);
        }

        [HttpPost("Tarea")]
        public IActionResult Crear_Tarea([FromBody]CrearTareaDTO tarea)
        {
            return controlador.Crear_Tarea(tarea);
        }


    }
}
