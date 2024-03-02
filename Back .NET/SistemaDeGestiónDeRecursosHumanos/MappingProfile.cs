using AutoMapper;
using Modelos.DTO;
using Modelos.Modelos;

namespace SistemaDeGestiónDeRecursosHumanos
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CrearUsuarioDTO,Usuario>();
            CreateMap<ActualizarUsuarioDTO, Usuario>();
            CreateMap<CrearDepartamentoDTO , Departamento>();
            CreateMap<CrearEmpleadoDTO, Empleado>();
            CreateMap<ActualizarEmpleadoDTO, Empleado>();
            CreateMap<CrearTareaDTO, TareasProyecto>();
            CreateMap<CrearEvaluacionDTO, EvaluacionDesempeno>();
        }
    }
}
