export interface Empleado {
  empleadoId: string;  
  nombre: string;
  apellido: string;
  fechaNacimiento: Date ;
  genero: string;
  direccion: string;
  telefono: string;
  correoElectronico: string;
  fechaContratacion: string;
  departamentoId: string;
}


export interface Tarea {
  tareaId: string;
  descripcion: string;
  fechaAsignacion: Date ;
  fechaVencimiento: Date ;
  estado: string;
  empleadoId: string;
}

export interface Evaluacion {
  evaluacionId:string;
  empleadoId:string;
  competenciasEvaluadas: string;
  resultados: string;
  fechaEvaluacion: string;
}

export interface ServerResponse {
  message?: string;
  code?: number;
}


