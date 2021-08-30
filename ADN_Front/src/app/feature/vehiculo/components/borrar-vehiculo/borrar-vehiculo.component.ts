import { Component, OnInit } from '@angular/core';
import { VehiculoService } from '../../shared/service/vehiculo.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

const LONGITUD_MINIMA_PERMITIDA_TEXTO = 3;
const LONGITUD_MAXIMA_PERMITIDA_TEXTO = 20;

@Component({
  selector: 'app-borrar-vehiculo',
  templateUrl: './borrar-vehiculo.component.html',
  styleUrls: ['./borrar-vehiculo.component.scss']
})
export class BorrarVehiculoComponent implements OnInit {
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
      id: new FormControl('', [Validators.required]),
      descripcion: new FormControl('', [Validators.required, Validators.minLength(LONGITUD_MINIMA_PERMITIDA_TEXTO),
      Validators.maxLength(LONGITUD_MAXIMA_PERMITIDA_TEXTO)])
    });


  }
}
