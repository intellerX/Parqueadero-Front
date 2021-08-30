import { Injectable } from '@angular/core';
import { HttpService } from '@core-service/http.service';
import { environment } from 'src/environments/environment';
import { Vehiculo } from '../model/vehiculo';


@Injectable()
export class VehiculoService {

  constructor(protected http: HttpService) { }

  public consultar() {
    return this.http.doGet<Vehiculo[]>(`${environment.endpoint}/tiposFamilia`, this.http.optsName('consultar vehiculos'));
  }

  public guardar(vehiculo: Vehiculo) {
    return this.http.doPost<Vehiculo, boolean>(`${environment.endpoint}/vehiculos`, vehiculo,
      this.http.optsName('crear/actualizar vehiculos'));
  }

  public eliminar(vehiculo: Vehiculo) {
    return this.http.doDelete<boolean>(`${environment.endpoint}/vehiculos/${vehiculo.id}`,
      this.http.optsName('eliminar vehiculos'));
  }
}
