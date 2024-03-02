import { Component } from '@angular/core';
import { Api_Services } from '../Api_Services';
import { Evaluacion, ServerResponse } from '../Interfaces';
import { mensajeEmergente } from '../MensajeEmergente';

@Component({
  selector: 'app-rendimiento',
  templateUrl: './rendimiento.component.html',
  styleUrls: ['./rendimiento.component.css']
})
export class RendimientoComponent {

  evaluaciones: Evaluacion[] = [];
  empleados: { nombre: string; id: string; }[] = [];
  idEmpleado: string = '';
  respuesta!: ServerResponse;

  competenciasEvaluadas: string = '';
  resultados: string = ''
  IsEdit:boolean = false;
  evaluacionId:string = ''





  constructor(private api: Api_Services) {
    this.api.getEmpleadosNombres().subscribe((e: { nombre: string; id: string; }[]) => {
      this.empleados = e;
      console.log(e)
    })
  }

  TraerEvaluaciones() {
    if (this.idEmpleado.length === 0) {
      this.evaluaciones = []
    } else {

      this.api.getEvaluaciones(this.idEmpleado).subscribe((e: any) => {
        this.evaluaciones = e;
        console.log(e)
      })
    }

  }


  addEvaluacion() {
    const evaluacion:Evaluacion = {
      empleadoId: this.idEmpleado,
      competenciasEvaluadas: this.competenciasEvaluadas,
      resultados: this.resultados,
      evaluacionId: '',
      fechaEvaluacion: ''
    }

    this.api.addEvaluacion(evaluacion).subscribe((e) => {
      mensajeEmergente(e.message);
      this.Limpriar();
      this.evaluaciones.push(evaluacion)
    });


  }

  CamposEvaluacion(resul:string,competencia:string,id:string){
    this.competenciasEvaluadas = competencia;
    this.resultados = resul;
    this.IsEdit = true;
    this.evaluacionId = id;
  }

  Limpriar(){
    this.resultados = '';
    this.competenciasEvaluadas = '';
  }

  editarEvaluacion(){
    const evaluacion:Evaluacion = {
      evaluacionId: this.evaluacionId,
      competenciasEvaluadas: this.competenciasEvaluadas,
      resultados: this.resultados,
      empleadoId: '',
      fechaEvaluacion: ''
    }
    this.Limpriar();
    this.api.ActualizarEvaluacion(evaluacion).subscribe((e)=>{
      mensajeEmergente(e.message);
      this.IsEdit = false;
      const evaluacionIndex = this.evaluaciones.findIndex(x => x.evaluacionId === this.evaluacionId);
      if (evaluacionIndex !== -1) {
        evaluacion.fechaEvaluacion = this.evaluaciones[evaluacionIndex].fechaEvaluacion;
        evaluacion.empleadoId = this.evaluaciones[evaluacionIndex].empleadoId;


        this.evaluaciones[evaluacionIndex] = evaluacion;
      }
    })

    
  }

  obtenerMesYDia(fecha1: string): string {
    const fecha = new Date(fecha1)
    const meses = [
      'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
      'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
    ];

    const nombreMes = meses[fecha.getMonth()];
    const dia = fecha.getDate();

    return `${nombreMes} ${dia}`;
  }

  EliminarEvaluacion(id: string) {
    console.log(this.evaluaciones.find(x => x.evaluacionId == id))
    this.api.EliminarEvaluacion(id).subscribe((e) => {
      mensajeEmergente(e.message)
      this.evaluaciones = this.evaluaciones.filter(x => x.evaluacionId !== id);
    })
  }


}
