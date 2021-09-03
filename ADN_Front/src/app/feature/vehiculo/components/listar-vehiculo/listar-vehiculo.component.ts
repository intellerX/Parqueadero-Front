import { Component, OnInit } from '@angular/core';

import { VehiculoService } from '@vehiculo/shared/service/vehiculo.service';
import { Vehiculo } from '@vehiculo/shared/model/vehiculo';
import Swal from 'sweetalert2'
@Component({
  selector: 'app-listar-vehiculo',
  templateUrl: './listar-vehiculo.component.html',
  styleUrls: ['./listar-vehiculo.component.scss']
})
export class ListarVehiculoComponent implements OnInit {
  public listaVehiculos: Vehiculo[];
  public dicTipoCarro = {
    0: "Moto",
    1: "Carro"
  }



  constructor(protected vehiculoService: VehiculoService) { }

  ngOnInit() {
    this.loadingMesssage();
    this.getVehicles();
  }

  getVehicles() {
    this.vehiculoService.consultar().subscribe({
      next: value => {
        this.listaVehiculos = value;
      }, error: error => {
        this.errorMessage(error);
      }
    })
  }

  updateVehicle(id: string) {

    this.vehiculoService.sacar(id).subscribe(value => {
      this.successMessage(value.cost);
    })
  }

  successMessage(cost: number) {

    Swal.fire(
      'El Vehiculo se ha retirado correctamente',
      'Costo total: ' + cost,
      'success'

    ).then((result) => {
      if (result.isConfirmed) {
        window.location.reload();
      }
    })

  }

  errorMessage(errorMessage: any) {

    Swal.fire(
      'Error al cargar los datos',
      'compruebe la conexión a internet: ' + errorMessage,
      'error'
    )

  }

  loadingMesssage() {
    Swal.fire({
      toast: true,
      showConfirmButton: false,
      position: 'top-end',
      title: 'Cargando...',
      timer: 2000,
      timerProgressBar: true,
      didOpen: () => {
        Swal.showLoading()
      }
    })
  }

}
