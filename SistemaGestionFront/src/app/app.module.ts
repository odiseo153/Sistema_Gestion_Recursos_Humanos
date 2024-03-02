import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AgregarEmpleadoComponent } from './agregar-empleado/agregar-empleado.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EmpleadosComponent } from './empleados/empleados.component';
import { LoadingComponent } from './loading/loading.component'; 
import { DetalleEmpleadoComponent } from './detalle-empleado/detalle-empleado.component';
import { TareasComponent } from './tareas/tareas.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { AddTareaComponent } from './add-tarea/add-tarea.component';
import { RendimientoComponent } from './rendimiento/rendimiento.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AgregarEmpleadoComponent,
    DashboardComponent,
    EmpleadosComponent,
    LoadingComponent,
    DetalleEmpleadoComponent,
    TareasComponent,
    AddTareaComponent,
    RendimientoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    NgxChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
