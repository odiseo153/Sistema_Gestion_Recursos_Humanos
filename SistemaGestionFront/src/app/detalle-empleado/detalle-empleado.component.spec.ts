import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleEmpleadoComponent } from './detalle-empleado.component';

describe('DetalleEmpleadoComponent', () => {
  let component: DetalleEmpleadoComponent;
  let fixture: ComponentFixture<DetalleEmpleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetalleEmpleadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetalleEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
