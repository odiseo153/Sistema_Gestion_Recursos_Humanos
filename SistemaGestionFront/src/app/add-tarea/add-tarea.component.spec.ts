import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTareaComponent } from './add-tarea.component';

describe('AddTareaComponent', () => {
  let component: AddTareaComponent;
  let fixture: ComponentFixture<AddTareaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTareaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddTareaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
