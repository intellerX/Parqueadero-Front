import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { VehiculoService } from './vehiculo.service';
import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/core/services/http.service';
import { Vehiculo } from '../model/vehiculo';
import { HttpResponse } from '@angular/common/http';

describe('VehiculoService', () => {
  let httpMock: HttpTestingController;
  let service: VehiculoService;
  const apiEndpointVehiculoConsulta = `${environment.endpoint}/tiposFamilia`;
  const apiEndpointVehiculos = `${environment.endpoint}/vehiculos`;

  beforeEach(() => {
    const injector = TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [VehiculoService, HttpService]
    });
    httpMock = injector.inject(HttpTestingController);
    service = TestBed.inject(VehiculoService);
  });

  it('should be created', () => {
    const productService: VehiculoService = TestBed.inject(VehiculoService);
    expect(productService).toBeTruthy();
  });

  it('deberia listar vehiculos', () => {
    const dummyVehiculos = [
      new Vehiculo('1', 'Vehiculo 1', '125', 'Carro', 'Activo', '11-11-2020'), new Vehiculo('2', 'Vehiculo 2', '125', 'Carro', 'Activo', '11-11-2020')
    ];
    service.consultar().subscribe(vehiculos => {
      expect(vehiculos.length).toBe(2);
      expect(vehiculos).toEqual(dummyVehiculos);
    });
    const req = httpMock.expectOne(apiEndpointVehiculoConsulta);
    expect(req.request.method).toBe('GET');
    req.flush(dummyVehiculos);
  });

  it('deberia crear un vehiculo', () => {
    const dummyVehiculo = new Vehiculo('1', 'Vehiculo 1', '125', 'Carro', 'Activo', '11-11-2020');
    service.guardar(dummyVehiculo).subscribe((respuesta) => {
      expect(respuesta).toEqual(true);
    });
    const req = httpMock.expectOne(apiEndpointVehiculos);
    expect(req.request.method).toBe('POST');
    req.event(new HttpResponse<boolean>({ body: true }));
  });

  it('deberia eliminar un vehiculo', () => {
    const dummyVehiculo = new Vehiculo('1', 'Vehiculo 1', '125', 'Carro', 'Activo', '11-11-2020');
    service.eliminar(dummyVehiculo).subscribe((respuesta) => {
      expect(respuesta).toEqual(true);
    });
    const req = httpMock.expectOne(`${apiEndpointVehiculos}/1`);
    expect(req.request.method).toBe('DELETE');
    req.event(new HttpResponse<boolean>({ body: true }));
  });
});
