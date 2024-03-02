import { Component, OnInit, inject } from '@angular/core';
import { Api_Services } from '../Api_Services';
import { mensajeEmergente } from '../MensajeEmergente';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  user: string = ''
  clave: string = ''

  loading: boolean = true;
  posicion: boolean = false;

  N_user: string = '';
  N_clave: string = '';
  N_rol: string = ''

  constructor(private http: Api_Services) {
    const sessionActiva = sessionStorage.getItem('user') ? true : false;

    if (sessionActiva) {
      window.location.href = '/home'
    }

  }

  ngOnInit(): void {

  }

  addUser() {
    if (this.validarCamposNoVaciosRegister()) {
      const user = { "nombreUsuario": this.N_user, "claveAcceso": this.N_clave, "rol": this.N_rol }
      this.http.AgregarUsuario(user).subscribe((e:any) => {
        mensajeEmergente(e.message)

        this.N_user = '';
        this.N_clave = '';
        this.N_rol = '';
        this.posicion = false;
      })
    }
  }

  cambiarPosicion(posicion: boolean) {
    this.posicion = posicion;
  }

  IniciarSesion() {
    this.loading = false;

    if (this.validarCamposNoVaciosLogin()) {
      this.http.IniciarSesion(this.user, this.clave).subscribe((res: any) => {
        if (res.code == 200) {
          this.loading = true;
          sessionStorage.setItem('user', 'valido')
          window.location.href = '/home'
        }
        else if (res.code == 404) {
          this.loading = true;
          mensajeEmergente(res.message);
        }
      })
    }

  }

  validarCamposNoVaciosLogin(): boolean {
    let camposVacios = []

    if (this.user === '') {
      camposVacios.push('nombre');
    }
    if (this.clave === '') {
      camposVacios.push('Contraseña');
    }
    if (camposVacios.length !== 0) { mensajeEmergente('Los siguientes estan vacios \n' + camposVacios.join('  \n')) }

    return camposVacios.length === 0;
  }

  validarCamposNoVaciosRegister(): boolean {
    let camposVacios = []

    if (this.N_user === '') {
      camposVacios.push('nombre');
    }
    if (this.N_clave === '') {
      camposVacios.push('Contraseña');
    }

    if (this.N_rol === '') {
      camposVacios.push('Rol');
    }

    if (camposVacios.length !== 0) { mensajeEmergente('Los siguientes estan vacios \n' + camposVacios.join('  \n')) }

    return camposVacios.length === 0;
  }

}
