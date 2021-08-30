import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { ListarVehiculoComponent } from './listar-vehiculo.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterTestingModule } from '@angular/router/testing';
import { VehiculoService } from '../../shared/service/vehiculo.service';
import { Vehiculo } from '../../shared/model/vehiculo';
import { HttpService } from 'src/app/core/services/http.service';

describe('ListarVehiculoComponent', () => {
  let component: ListarVehiculoComponent;
  let fixture: ComponentFixture<ListarVehiculoComponent>;
  let vehiculoService: VehiculoService;
  const listaVehiculos: Vehiculo[] = [new Vehiculo('1', 'Vehiculo 1'), new Vehiculo('2', 'Vehiculo 2')];

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ListarVehiculoComponent],
      imports: [
        CommonModule,
        HttpClientModule,
        RouterTestingModule
      ],
      providers: [VehiculoService, HttpService]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarVehiculoComponent);
    component = fixture.componentInstance;
    vehiculoService = TestBed.inject(VehiculoService);
    spyOn(vehiculoService, 'consultar').and.returnValue(
      of(listaVehiculos)
    );
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    component.listaVehiculos.subscribe(resultado => {
      expect(2).toBe(resultado.length);
    });
  });

});
