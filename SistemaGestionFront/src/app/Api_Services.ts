import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Empleado,Evaluacion,Tarea } from './Interfaces';

@Injectable({
    providedIn: 'root'
})
export class Api_Services {
    constructor(private http: HttpClient) { }

    url = 'https://localhost:7249/';

    getEmpleados(): Observable<any> {
        return this.http.get(`${this.url}Empleados`);
    }

    getEmpleadosNombres(): Observable<any> {
        return this.http.get(`${this.url}Empleados_Nombres`);
    }

    getEvaluaciones(idEmpleado:string): Observable<any> {
        return this.http.get(`${this.url}Evaluacion/`+idEmpleado);
    }

    getCantidad(): Observable<any> {
        return this.http.get(`${this.url}Cantidad_Empleados`);
    }

    getTareas(id:string): Observable<any> {
        return this.http.get(`${this.url}Tareas/${id}`);
    }

    getTarea(id:string): Observable<any> {
        return this.http.get(`${this.url}Tarea/${id}`);
    }

    ActualizarTarea(id:string,tarea:Tarea): Observable<any> {
        return this.http.put(`${this.url}Tarea/${id}`,tarea);
    }

    ActualizarEvaluacion(evaluacion:any): Observable<any> {
        return this.http.put(`${this.url}Evaluacion`,evaluacion);
    }

    EditarEmpleado(nuevo_Empleado:Empleado): Observable<any> {
        return this.http.put(`${this.url}Empleados`,nuevo_Empleado);
    }
    getEmpleado(id:string): Observable<any> {
        return this.http.get(`${this.url}Empleados/${id}`);
    }

    EliminarEmpleado(Id:string): Observable<any> {
        return this.http.delete(`${this.url}Empleados/${Id}`);
    }

    EliminarEvaluacion(Id:string): Observable<any> {
        return this.http.delete(`${this.url}Evaluacion/${Id}`);
    }

    addEvaluacion(evaluacion:any): Observable<any> {
        return this.http.post(`${this.url}Evaluacion`,evaluacion);
    }

    EliminarTarea(Id:string): Observable<any> {
        return this.http.delete(`${this.url}Tarea/${Id}`);
    }

    AgregarTarea(Tarea:Tarea): Observable<any> {
        return this.http.post(`${this.url}Tarea`, Tarea);
    }

    AgregarEmpleados(empleado: Empleado): Observable<any> {
        return this.http.post(`${this.url}Empleados`, empleado);
    }

    getDepartamentos(): Observable<any> {
        return this.http.get(`${this.url}Departamento`);
    }

    AgregarUsuario(usuario:{nombreUsuario:string,claveAcceso:string,rol:string}) {
        return this.http.post(`${this.url}usuario`, usuario)
    }


    IniciarSesion(usuario: string, clave: string) {
        const params = { "usuario": usuario, "clave": clave }
        console.log(params)
        return this.http.post(`${this.url}Login?usuario=${usuario}&clave=${clave}`, params)
    }
}