import { NgModule } from '@angular/core';

import { VehiculoRoutingModule } from './vehiculo-routing.module';
import { BorrarVehiculoComponent } from './components/borrar-vehiculo/borrar-vehiculo.component';
import { ListarVehiculoComponent } from './components/listar-vehiculo/listar-vehiculo.component';
import { CrearVehiculoComponent } from './components/crear-vehiculo/crear-vehiculo.component';
import { VehiculoComponent } from './components/vehiculo/vehiculo.component';
import { SharedModule } from '@shared/shared.module';
import { VehiculoService } from './shared/service/vehiculo.service';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
@NgModule({
  declarations: [
    CrearVehiculoComponent,
    ListarVehiculoComponent,
    BorrarVehiculoComponent,
    VehiculoComponent,
  ],
  imports: [
    VehiculoRoutingModule,
    SharedModule,
    SweetAlert2Module,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
  ],
  providers: [VehiculoService]
})
export class VehiculoModule { }
