import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductoRoutingModule } from './producto-routing.module';
import { TableModule } from 'primeng/table';
import { ProductoComponent } from './producto/producto.component';
import { DialogproductoComponent } from './producto/dialogproducto/dialogproducto.component';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { DividerModule } from 'primeng/divider';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { MultiSelectModule } from 'primeng/multiselect';


@NgModule({
  declarations: [
    ProductoComponent,
    DialogproductoComponent
  ],
  imports: [
    CommonModule,
    ProductoRoutingModule,
    TableModule,
    DialogModule,
    CalendarModule,
    DropdownModule,
    DividerModule,
    InputTextModule,
    InputNumberModule,
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    MultiSelectModule
  ]
})
export class ProductoModule { }
