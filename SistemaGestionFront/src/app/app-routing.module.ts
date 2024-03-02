import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AgregarEmpleadoComponent } from './agregar-empleado/agregar-empleado.component';
import { DetalleEmpleadoComponent } from './detalle-empleado/detalle-empleado.component';
import { TareasComponent } from './tareas/tareas.component';
import { RendimientoComponent } from './rendimiento/rendimiento.component';


const IsLogeado = () =>{

  const IsLoger = sessionStorage.getItem('user') ? true : false;

  if(IsLoger){
    return true;
  }
    window.location.href = ''
    return false;
  
}

const routes: Routes = [
  {path:'',component:LoginComponent}, 
  {path:'Empleados',component:EmpleadosComponent,canActivate:[IsLogeado]},
  {path:'home',component:DashboardComponent,canActivate:[IsLogeado]},
  {path:'addEmpleado',component:AgregarEmpleadoComponent,canActivate:[IsLogeado]},
  {path:'addEmpleado/:idEmpleado',component:AgregarEmpleadoComponent,canActivate:[IsLogeado]},
  {path:'DetalleEmpleado/:idEmpleado',component:DetalleEmpleadoComponent,canActivate:[IsLogeado]},
  {path:'tareas/:idEmpleado',component:TareasComponent,canActivate:[IsLogeado]},
  {path:'rendimiento',component:RendimientoComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
}) 


export class AppRoutingModule { }
