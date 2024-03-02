import { Component } from '@angular/core';
import { Api_Services } from '../Api_Services';
import { Tarea } from '../Interfaces';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { AddTareaComponent } from '../add-tarea/add-tarea.component';
import { mensajeEmergente } from '../MensajeEmergente';

@Component({
  selector: 'app-tareas',
  templateUrl: './tareas.component.html',
  styleUrls: ['./tareas.component.css']
})
export class TareasComponent {

  tareas: Tarea[] = [];
  idEmpleado: string = ''

  constructor(private api: Api_Services, private route: ActivatedRoute, private dialogo: MatDialog) {

    const id = this.route.snapshot.params['idEmpleado']
    this.idEmpleado = id;

    this.api.getTareas(id).subscribe((e) => {
      this.tareas = e;
      console.log(e)
    })
  }

  open() {
    sessionStorage.setItem('Id', this.idEmpleado)
    this.dialogo.open(AddTareaComponent);
  }

  EditTarea(id: string) {
    sessionStorage.setItem('idTarea', id)
    this.dialogo.open(AddTareaComponent);
  }

  EstadoTarea(id: string): string {
    const tarea = this.tareas.find(x => x.tareaId == id);

    if (tarea?.estado === 'Terminada') {
      return "priority low"
    }
    else if (tarea?.estado === 'En progreso') {
      return 'priority medium'
    }
    else if (tarea?.estado === 'No comenzada') {
      return 'priority high'
    }
    return 'priority primary'
  }

  eliminarTarea(id: string) {
    this.api.EliminarTarea(id).subscribe((e) => {
      mensajeEmergente(e.message)
      this.tareas = this.tareas.filter(x => x.tareaId != id);
    })
  }

  formatearFecha(fechaString: string): string {
    const fecha = new Date(fechaString);
    if (isNaN(fecha.getTime())) {
      // Verificar si la conversión a fecha fue exitosa
      return 'Fecha inválida';
    }
  
    const dia = fecha.getDate();
    const mes = fecha.getMonth() + 1; // Los meses comienzan desde 0
    const año = fecha.getFullYear();
  
    // Formateamos la fecha con ceros a la izquierda si es necesario
    const diaFormateado = dia < 10 ? `0${dia}` : dia.toString();
    const mesFormateado = mes < 10 ? `0${mes}` : mes.toString();
  
    // Devolvemos la fecha formateada
    return `${diaFormateado}/${mesFormateado}/${año}`;
  }



}
