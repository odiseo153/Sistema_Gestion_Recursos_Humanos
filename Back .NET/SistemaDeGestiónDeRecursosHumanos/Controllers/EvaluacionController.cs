using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using Negocio.Logistica;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestiónDeRecursosHumanos.Controllers
{
    public class EvaluacionController : Controller
    {
        private EvaluacionControlador controlador;

        public EvaluacionController(EvaluacionControlador controlador)
        {
            this.controlador = controlador;
        }

        [HttpGet("Evaluaciones")]
        public IActionResult ObtenerEvaluaciones()
        {
            return controlador.Obtener_Evaluaciones();
        }

   
        [HttpGet("Evaluacion/{id}")]
        public IActionResult Obtener_Evaluaciones_De_Empleado([Required] string id)
        {
            return controlador.Obtener_Evaluaciones_By_Empleado(id);
        }

        [HttpPut("Evaluacion")]
        public IActionResult Actualizar_Evaluacion([FromBody]ActualizarEvaluacionDTO eval)
        {
            return controlador.ActualizarEvaluacion(eval);
        }

        [HttpDelete("Evaluacion/{id}")]
        public IActionResult Borrar_La_Evaluacion([Required] string id)
        {
            return controlador.Borrar_Evaluacion(id);
        }

        [HttpPost("Evaluacion")]
        public IActionResult CrearEvaluacion([FromBody] CrearEvaluacionDTO evaluacion)
        {
            return controlador.CrearEvaluacion(evaluacion);
        }


    }
}
