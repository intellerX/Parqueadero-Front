import { Component, OnInit } from '@angular/core';
import { VehiculoService } from '../../shared/service/vehiculo.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Vehiculo } from '@vehiculo/shared/model/vehiculo';
import Swal from 'sweetalert2'

const LONGITUD_MINIMA_PERMITIDA_PLACA = 6;
const LONGITUD_MAXIMA_PERMITIDA_PLACA = 6;

@Component({
  selector: 'app-crear-vehiculo',
  templateUrl: './crear-vehiculo.component.html',
  styleUrls: ['./crear-vehiculo.component.scss']
})
export class CrearVehiculoComponent implements OnInit {
  vehiculoForm: FormGroup;
  constructor(protected vehiculoServices: VehiculoService) { }

  ngOnInit() {
    this.construirFormularioVehiculo();
  }

  cerar() {
    this.vehiculoServices.guardar(this.vehiculoForm.value);
  }

  private construirFormularioVehiculo() {
    this.vehiculoForm = new FormGroup({
      type: new FormControl('Tipo de vehiculo', [Validators.required]),
      cc: new FormControl(null),
      dateOfIn: new FormControl('', [Validators.required]),
      plate: new FormControl('', [Validators.required, Validators.minLength(LONGITUD_MINIMA_PERMITIDA_PLACA),
      Validators.maxLength(LONGITUD_MAXIMA_PERMITIDA_PLACA)]),
    });
  }

  crearVehiculo() {
    if (this.vehiculoForm.value.type == 1 && this.vehiculoForm.value.cc == null) {
      this.vehiculoForm.value.cc = 0
    }
    this.vehiculoServices.guardar(
      new Vehiculo(
        this.vehiculoForm.value.plate,
        this.vehiculoForm.value.cc,
        +this.vehiculoForm.value.type,
        0, this.vehiculoForm.value.dateOfIn
      )
    ).subscribe(
      value => {
        console.log(value);

        this.successMessage();
      }, error => {
        console.log(error.error.message);

        this.errorMessage(error.error.message);
      }
    )
  }

  successMessage() {
    Swal.fire({
      icon: 'success',
      text: 'Vehiculo creado correctamente',
    }).then((result) => {
      if (result.isConfirmed) {
        window.location.reload();
      }
    })
  }

  errorMessage(errorMessage: any) {
    Swal.fire(
      'Error al cargar los datos',
      'Error: ' + errorMessage,
      'error'
    )
  }



}
