import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ProductService } from 'src/app/demo/service/product.service';
import { CategoriaModel } from 'src/app/Models/categoria.model';
import { ProductoModel } from 'src/app/Models/producto.model';
import { CategoriaService } from 'src/app/services/categoria.service';
import { ProductosService } from 'src/app/services/productos.service';

@Component({
  selector: 'app-dialogcliente',
  templateUrl: './dialogproducto.component.html',
  styles: ``
})
export class DialogproductoComponent implements OnInit{
  @Output()productoEmitter=new EventEmitter();
  textoTitle:string='';
  private _servicesProducto=inject(ProductosService);
  private _servicesCategoria=inject(CategoriaService);
  private _formBuilder=inject(FormBuilder);
  private messageService=inject(MessageService);
  form!:FormGroup;
  visibleClient: boolean = false;
  producto:ProductoModel=new ProductoModel();
  categoriaList:CategoriaModel[]=[];
  categoriaSelect:CategoriaModel[]=[]

  constructor(){
    this.initForm();
  }
  ngOnInit(): void {
    this._servicesCategoria.getCategoriaAll().subscribe({
      next:resp=>this.categoriaList=resp['data']
    })    
  }
  initForm(){
    this.form=this._formBuilder.group(
      { 
        nombre:['', Validators.required, Validators.minLength(10)],
        descrip:['', Validators.required],
        precio:['', Validators.required ],
        fecha:['', Validators.required],
        categoria:['', Validators.required],
        marca:['', Validators.required],
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
    this.producto.NombProd=this.form.get("nombre").value
    this.producto.DescripProd=this.form.get("descrip").value
    this.producto.Precio=this.form.get("precio").value
    this.producto.FechaFabricacion=this.form.get("fecha").value
    this.producto.Marca=this.form.get("marca").value    
    Object.values(this.form.controls).forEach(controls=>controls.markAsUntouched());
    this.productoEmitter.emit(this.producto);
    this.producto=new ProductoModel();
    console.log(this.categoriaSelect);
  }
}
