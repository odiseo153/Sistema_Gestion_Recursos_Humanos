import { Component } from '@angular/core';
import { Api_Services } from '../Api_Services';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  private data = [
    {
      "name": "Germany",
      "value": 8940000
    },
    {
      "name": "USA",
      "value": 5000000
    },
    {
      "name": "France",
      "value": 7200000
    },
      {
      "name": "UK",
      "value": 6200000
    }
  ];
  cantidad: { hombres: string, mujeres: string, otros: string } = {
    hombres: '',
    mujeres: '',
    otros: ''
  };
  
  view: [number, number] = [900, 400];

  // options
  gradient: boolean = true;
  showLegend: boolean = true;
  showLabels: boolean = true;
  isDoughnut: boolean = false;
single: any;


  constructor(private api: Api_Services) {
    this.api.getCantidad().subscribe((e: { hombres: string, mujeres: string, otros: string }) => {
      this.cantidad = e;
    })

  }

  onRandomData() {
    [
      {
        "name": "Germany",
        "value": Math.random() * 1000000
      },
      {
        "name": "USA",
        "value": Math.random() * 1000000
      },
      {
        "name": "France",
        "value": Math.random() * 1000000
      },
        {
        "name": "UK",
        "value": Math.random() * 1000000
      }
    ];
  }

  onSelect(data: any): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate(data: any): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data: any): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }
    



  
}
