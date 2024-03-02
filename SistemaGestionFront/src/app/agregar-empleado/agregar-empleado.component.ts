import { Component } from '@angular/core';
import { Empleado } from '../Interfaces';
import { Api_Services } from '../Api_Services';
import { mensajeEmergente } from '../MensajeEmergente';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-agregar-empleado',
  templateUrl: './agregar-empleado.component.html',
  styleUrls: ['./agregar-empleado.component.css']
})
export class AgregarEmpleadoComponent {
  empleado: Empleado = {
    nombre: '',
    apellido: '',
    fechaNacimiento: new Date(),
    genero: '',
    direccion: '',
    telefono: '',
    correoElectronico: '',
    fechaContratacion: '',
    departamentoId: '',
    empleadoId: ''
  };
  departamentos: { nombre: string, id: string }[] = [];
  idEmpleado:string = ''
  editando:boolean = false;

  constructor(
    private http: Api_Services,
    private route: ActivatedRoute
    ) {

    this.idEmpleado = this.route.snapshot.params['idEmpleado'];

    this.TraerEmpleadoParaEditar();
    this.http.getDepartamentos().subscribe((e: any) => {
      this.departamentos = e;
    })
  }


  submitForm() {
    // Lógica de envío del formulario

    
    if(this.validarCamposNoVacios()){
      this.http.AgregarEmpleados(this.empleado).subscribe((e) => {
        console.log(e)
        this.empleado = {
          nombre: '',
          apellido: '',
          fechaNacimiento: new Date(),
          genero: '',
          direccion: '',
          telefono: '',
          correoElectronico: '',
          fechaContratacion: '',
          departamentoId: '',
          empleadoId:''
        };
        mensajeEmergente(e.message)
      })
      
    }
 
   
    console.log(this.empleado);
  }

  validarCamposNoVacios(): boolean {
    const camposVacios = [];
    const empleado = this.empleado;
  
    if (empleado.nombre === '') {
      camposVacios.push('nombre');
    }
    if (empleado.apellido === '') {
      camposVacios.push('apellido');
    }
    if (empleado.genero === '') {
      camposVacios.push('genero');
    }
    if (empleado.direccion === '') {
      camposVacios.push('direccion');
    }
    if (empleado.telefono === '') {
      camposVacios.push('telefono'); 
    }
    if (empleado.correoElectronico === '') {
      camposVacios.push('correoElectronico');
    }
    if (empleado.fechaContratacion === '') {
      camposVacios.push('fechaContratacion');
    }
    if (empleado.departamentoId === '') {
      camposVacios.push('departamento');
    }

    
    

     if(camposVacios.length !== 0){mensajeEmergente('Los siguientes estan vacios \n'+camposVacios.join('  \n') )}

    return camposVacios.length === 0;
  }
  


  TraerEmpleadoParaEditar(){
    if (this.idEmpleado != '' && this.idEmpleado != undefined && this.idEmpleado != null){
      this.http.getEmpleado(this.idEmpleado).subscribe((e:Empleado)=>{
        this.empleado = e;
        this.editando = true;
      })
    }
  }

  EditarEmpleado(){
  
  this.http.EditarEmpleado(this.empleado).subscribe((e)=>{
    mensajeEmergente(e.message)
    this.empleado = {
      nombre: '',
      apellido: '',
      fechaNacimiento: new Date(),
      genero: '',
      direccion: '',
      telefono: '',
      correoElectronico: '',
      fechaContratacion: '',
      departamentoId: '',
      empleadoId:''
    };
    this.editando = false;
  })



  }
}
