import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SistemaGestionFront';

   IsLogeado = () => {

    const IsLoger = sessionStorage.getItem('user') ? true : false;

    if (IsLoger) {
      return true;
    }
    else {
      return false;
    }
  }

  

  CerrarSesion = () => {

   sessionStorage.removeItem('user')
   window.location.href = ''
  }

}
