import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RendimientoComponent } from './rendimiento.component';

describe('RendimientoComponent', () => {
  let component: RendimientoComponent;
  let fixture: ComponentFixture<RendimientoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RendimientoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RendimientoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
