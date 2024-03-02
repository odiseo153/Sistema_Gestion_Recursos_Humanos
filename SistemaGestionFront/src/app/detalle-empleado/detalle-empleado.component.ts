import { Component } from '@angular/core';
import { Empleado, Tarea } from '../Interfaces';
import { Api_Services } from '../Api_Services';
import { ActivatedRoute } from '@angular/router';
import { mensajeEmergente } from '../MensajeEmergente';
import { MatDialog } from '@angular/material/dialog';
import { AddTareaComponent } from '../add-tarea/add-tarea.component';

@Component({
  selector: 'app-detalle-empleado',
  templateUrl: './detalle-empleado.component.html',
  styleUrls: ['./detalle-empleado.component.css']
})
export class DetalleEmpleadoComponent {

  empleado!: Empleado;
  tareas: Tarea[] = [];
  idEmpleado: string = ''
  
  chica:string = 'https://i.pinimg.com/474x/33/e7/82/33e782b75c322c909f04134cb5e9feba.jpg'
  chico:string = 'https://i.pinimg.com/236x/1e/9c/92/1e9c9281863922a660036bf44861a2a3.jpg'


  constructor(private api: Api_Services, private route: ActivatedRoute,private dialogo: MatDialog) {
    const id = this.route.snapshot.params['idEmpleado'];
    
    this.api.getEmpleado(id).subscribe((e: Empleado) => {
      this.empleado = e;
       console.log(e)
    })

    this.api.getTareas(id).subscribe((e) => {
      this.tareas = e;
      console.log(e)
    })

  }

  Eliminar(id: string) {

    if (window.confirm("esta seguro que desea eliminar este Empleado")) {
      this.api.EliminarEmpleado(id).subscribe((e: any) => {
        mensajeEmergente(e.message);
        window.location.href = 'Empleados'
      })
    }

  }


  open() {
    sessionStorage.setItem('Id', this.empleado.empleadoId)
    this.dialogo.open(AddTareaComponent);
  }

  EditTarea(id: string) {
    sessionStorage.setItem('idTarea', id)
    this.dialogo.open(AddTareaComponent);
  }

  EstadoTarea(estado: string): string {
 
    if (estado.toLocaleLowerCase() === 'terminada') {
      return "terminada"
    }
    else if (estado.toLocaleLowerCase() === 'en progreso') {
      return 'EnProcesso'
    }
    else if (estado.toLocaleLowerCase() === 'no comenzada') {
      return 'noComenzada'
    }
    return 'niguna'
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
