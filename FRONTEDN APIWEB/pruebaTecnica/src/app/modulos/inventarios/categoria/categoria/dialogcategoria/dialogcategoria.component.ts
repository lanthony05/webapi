import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { CategoriaModel } from 'src/app/Models/categoria.model';
import { ProductoModel } from 'src/app/Models/producto.model';
import { CategoriaService } from 'src/app/services/categoria.service';
import { ProductosService } from 'src/app/services/productos.service';

@Component({
  selector: 'app-dialogcliente',
  templateUrl: './dialogcategoria.component.html',
  styles: ``
})
export class DialogCategoriaComponent implements OnInit{
  @Output()categoriaEmitter=new EventEmitter();
  textoTitle:string='';
  private _servicesProducto=inject(ProductosService);
  private _servicesCategoria=inject(CategoriaService);
  private _formBuilder=inject(FormBuilder);
  private messageService=inject(MessageService);
  form!:FormGroup;
  visibleClient: boolean = false;
  categoria:CategoriaModel=new CategoriaModel();
  productoList:ProductoModel[]=[];
  productoSelect:ProductoModel[]=[]

  constructor(){
    this.initForm();    
  }
  ngOnInit(): void {
    this._servicesProducto.getProductosAll().subscribe({
      next:resp=>this.productoList=resp['data']
    })    
  }
  initForm(){
    this.form=this._formBuilder.group(
      { 
        nombre:['', Validators.required, Validators.minLength(10)],
        producto:['', Validators.required],
      }
    )
  }
  getInvalid(argument:string){
    return this.form.get(argument).invalid && this.form.get(argument).touched;
  }
  registrarProducto(){
    if(this.form.invalid){
      Object.values(this.form.controls).forEach(controls=>controls.markAsTouched());
      this.messageService.add({ severity: 'error', summary: 'Notificacion', detail: 'Campos Invalidos' });
      return;
    }
    this.categoria.NombCat=this.form.get('nombre').value
    Object.values(this.form.controls).forEach(controls=>controls.markAsUntouched());
    this.categoriaEmitter.emit(this.categoria);
    console.log(this.categoria.NombCat);
    this.categoria=new CategoriaModel();
    console.log(this.productoSelect);
  }
}
