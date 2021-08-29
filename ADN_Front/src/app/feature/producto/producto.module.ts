import { NgModule } from '@angular/core';

import { ProductoRoutingModule } from './producto-routing.module';
import { BorrarProductoComponent } from './components/borrar-producto/borrar-producto.component';
import { ListarProductoComponent } from './components/listar-producto/listar-producto.component';
import { CrearProductoComponent } from './components/crear-producto/crear-producto.component';
import { ProductoComponent } from './components/producto/producto.component';
import { SharedModule } from '@shared/shared.module';
import { ProductoService } from './shared/service/producto.service';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
@NgModule({
  declarations: [
    CrearProductoComponent,
    ListarProductoComponent,
    BorrarProductoComponent,
    ProductoComponent,
  ],
  imports: [
    ProductoRoutingModule,
    SharedModule,
    SweetAlert2Module,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
  ],
  providers: [ProductoService]
})
export class ProductoModule { }
