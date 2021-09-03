import { Injectable } from '@angular/core';
import { HttpService } from '@core-service/http.service';
import { environment } from 'src/environments/environment';
import { Vehiculo } from '../model/vehiculo';
import { Observable } from "rxjs";

@Injectable()
export class VehiculoService {

  constructor(protected http: HttpService) { }

  public consultar(): Observable<Vehiculo[]> {
    return this.http.doGet<Vehiculo[]>(`${environment.endpoint}/vehicle`, this.http.optsName('consultar vehiculos'));
  }

  public guardar(vehiculo: Vehiculo) {
    return this.http.doPost<Vehiculo, boolean>(`${environment.endpoint}/vehicle`, vehiculo,
      this.http.optsName('crear vehiculos'));
  }

  public sacar(id: string) {
    return this.http.doPut<{ id: string }, { cost: number }>(`${environment.endpoint}/vehicle`, { id },
      this.http.optsName('eliminar vehiculos'));
  }
}
