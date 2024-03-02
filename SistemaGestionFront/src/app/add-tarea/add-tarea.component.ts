import { Component } from '@angular/core';
import { Tarea } from '../Interfaces';
import { Api_Services } from '../Api_Services';
import { mensajeEmergente } from '../MensajeEmergente';

@Component({
  selector: 'app-add-tarea',
  templateUrl: './add-tarea.component.html',
  styleUrls: ['./add-tarea.component.css']
})
export class AddTareaComponent {

  tarea: Tarea = {
    tareaId: '',
    descripcion: '',
    fechaAsignacion: new Date(),
    fechaVencimiento: new Date(),
    estado: '',
    empleadoId: ''
  };

  editando: boolean = false;

  constructor(private api: Api_Services) {
    const idEmpleado = sessionStorage.getItem('Id');
    const idTask = sessionStorage.getItem('idTarea');

    if (idEmpleado != null) {
      this.tarea.empleadoId = idEmpleado
 
    }

    if (idTask != null) {
      this.api.getTarea(idTask).subscribe((e) => {
        this.tarea = e
        this.editando = true;
        sessionStorage.removeItem('idTarea')
      })
    }


  }

  validarCamposNoVacios(): boolean {
    const camposVacios = [];
    const tarea = this.tarea;


    if (tarea.descripcion === '') {
      camposVacios.push('descripcion');
    }
    if (tarea.fechaVencimiento === null) {
      camposVacios.push('fechaVencimiento');
    }
    if (tarea.estado === '') {
      camposVacios.push('estado');
    }



    if (camposVacios.length !== 0) { mensajeEmergente('Los siguientes estan vacios \n' + camposVacios.join('  \n')) }

    return camposVacios.length === 0;
  }



  agregarTarea() {
    if (this.validarCamposNoVacios()) {

      this.api.AgregarTarea(this.tarea).subscribe((e) => {
        mensajeEmergente(e.message)
        window.location.reload();
      })

    }

  }

  editarTarea() {
    if (this.validarCamposNoVacios()) {
    this.api.ActualizarTarea(this.tarea.tareaId, this.tarea).subscribe((e) => {
      mensajeEmergente(e.message);
      sessionStorage.removeItem('idTarea');
      window.location.reload();
    })
  }
  }

}
