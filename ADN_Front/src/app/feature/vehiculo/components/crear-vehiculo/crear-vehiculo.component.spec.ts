import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { CrearVehiculoComponent } from './crear-vehiculo.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterTestingModule } from '@angular/router/testing';
import { VehiculoService } from '../../shared/service/vehiculo.service';
import { HttpService } from 'src/app/core/services/http.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

describe('CrearVehiculoComponent', () => {
  let component: CrearVehiculoComponent;
  let fixture: ComponentFixture<CrearVehiculoComponent>;
  let vehiculoService: VehiculoService;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [CrearVehiculoComponent],
      imports: [
        CommonModule,
        HttpClientModule,
        RouterTestingModule,
        ReactiveFormsModule,
        FormsModule
      ],
      providers: [VehiculoService, HttpService],
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrearVehiculoComponent);
    component = fixture.componentInstance;
    vehiculoService = TestBed.inject(VehiculoService);
    spyOn(vehiculoService, 'guardar').and.returnValue(
      of(true)
    );
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('formulario es invalido cuando esta vacio', () => {
    expect(component.vehiculoForm.valid).toBeFalsy();
  });

  it('Registrando vehiculo', () => {
    expect(component.vehiculoForm.valid).toBeFalsy();
    component.vehiculoForm.controls.id.setValue('001');
    component.vehiculoForm.controls.descripcion.setValue('Vehiculo test');
    expect(component.vehiculoForm.valid).toBeTruthy();

    component.cerar();

    // Aca validamos el resultado esperado al enviar la petición
    // TODO adicionar expect
  });
});
