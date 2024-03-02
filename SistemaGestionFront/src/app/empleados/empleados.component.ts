import { Empleado } from './../Interfaces';
import { Component } from '@angular/core';
import { Api_Services } from '../Api_Services';
import { mensajeEmergente } from '../MensajeEmergente';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent {

  empleados: Empleado[] = []
  nombre: string = '';
  chica:string = 'https://i.pinimg.com/474x/33/e7/82/33e782b75c322c909f04134cb5e9feba.jpg'
  chico:string = 'https://i.pinimg.com/236x/1e/9c/92/1e9c9281863922a660036bf44861a2a3.jpg'

  constructor(private api: Api_Services) { 
    this.api.getEmpleados().subscribe((e: any) => {
      this.empleados = e;
    })
  }

  Filtro(): Empleado[] {
    let data = this.empleados;

    if (this.nombre != '') {
      data = data.filter(x => x.nombre.toLocaleLowerCase().includes(this.nombre.toLocaleLowerCase()));
    }

    return data;
  }



}
