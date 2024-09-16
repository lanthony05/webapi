import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { DividerModule } from 'primeng/divider';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { MultiSelectModule } from 'primeng/multiselect';
import { DialogCategoriaComponent } from './categoria/dialogcategoria/dialogcategoria.component';
import { CategoriaComponent } from './categoria/categoria.component';
import { CategoriaRoutingModule } from './categoria-routing.module';


@NgModule({
  declarations: [
    CategoriaComponent,
    DialogCategoriaComponent
  ],
  imports: [
    CommonModule,
    CategoriaRoutingModule,
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
export class CategoriaModule { }
