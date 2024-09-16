import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ProductService } from 'src/app/demo/service/product.service';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { ProductosService } from 'src/app/services/productos.service';

import { ProductoModel } from 'src/app/Models/producto.model';
import { CategoriaModel } from 'src/app/Models/categoria.model';
import { ProductoXcategoriaService } from 'src/app/services/producto-xcategoria.service';
import { ProductoXcategoriaModel } from 'src/app/Models/productoXcategoria.model';
import { DialogCategoriaComponent } from './dialogcategoria/dialogcategoria.component';
import { CategoriaService } from 'src/app/services/categoria.service';

@Component({
  selector: 'app-componente',
  templateUrl: './categoria.component.html',
  styles: ``,
  providers: [MessageService, ConfirmationService]
})
export class CategoriaComponent {
  @ViewChild(DialogCategoriaComponent) dialogoCategoria: DialogCategoriaComponent;
  _serviceCategoria = inject(CategoriaService);
  private _servicesProductoXCategoria=inject(ProductoXcategoriaService);
  xs:string='';
  productoList:ProductoModel[]=[];
  categoriaList:CategoriaModel[]=[];
  loading: boolean = true;
  nombreCategoria='';
  constructor(public layoutService: LayoutService, 
     private messageService: MessageService) {}
  

    
  activityValues: number[] = [0, 100];
  

  
  ngOnInit(): void {   
      this._serviceCategoria.getCategoriaAll().subscribe({
        next:resp=>{
          this.categoriaList=resp['data']
          console.log(this.categoriaList)
        }
      })
  }
  dialogNuevoCliente(){
    this.dialogoCategoria.textoTitle='Crear Categoria';
    this.dialogoCategoria.visibleClient = true;
  }
  registrarCategoria(categoria:CategoriaModel){      
    this.productoList=this.dialogoCategoria.productoSelect;
    this.nombreCategoria=categoria.NombCat;
    console.log("asdas"+this.nombreCategoria);              
    console.log(this.productoList)
      if(categoria.IdCat!=null){
        this._serviceCategoria.putCategoria(categoria).subscribe({
          next:resp=>{
            if(resp['cod']==200){
              this.messageService.add({ severity: 'succcess', summary: 'Notificacion', detail: 'Actualizado Correctamente' });
            this._serviceCategoria.getCategoriaAll().subscribe({
              next:resp=>{
                this.categoriaList=resp["data"]
                let catId=this.categoriaList.find(x=>x.NombCat==this.nombreCategoria).IdCat
                this.productoList.forEach(x=>{
                  let proXcat:ProductoXcategoriaModel={
                    id:0,
                    idCat:catId,
                    idProd:x.IdProd
                  }
                  this._servicesProductoXCategoria.postProductoXCategoria(proXcat);
                })
              }
            })
            }
        }
      })     
      return;
  }
  categoria.IdCat=0;
  this._serviceCategoria.postCategoria(categoria).subscribe({
    next:resp=>{
      if(resp['cod']==200){
        this.messageService.add({ severity: 'succcess', summary: 'Notificacion', detail: 'Ingresado Correctamente' });        
        this._serviceCategoria.getCategoriaAll().subscribe({
          next:resp=>{
            this.categoriaList=resp["data"]
            let catId=this.categoriaList.find(x=>x.NombCat==this.nombreCategoria).IdCat
            this.productoList.forEach(x=>{
              let proXcat:ProductoXcategoriaModel={
                id:0,
                idCat:catId,
                idProd:x.IdProd
              }
              this._servicesProductoXCategoria.postProductoXCategoria(proXcat);
            })
          }
        })
      }
  }
  })
}
  actualizarProducto(categoria:CategoriaModel){
    this.dialogoCategoria.textoTitle='Actualizar Categoria';
    this.dialogoCategoria.categoria=categoria;
    this.dialogoCategoria.visibleClient=true;
  }
  eliminarProducto(categoria:CategoriaModel){

    this._servicesProductoXCategoria.getProductoXCategoriaAll().subscribe({
      next:resp=>{
        let prodXcat=resp['data']
        let prodXcatDelete=prodXcat.filter(x=>x.idCategoria==categoria.IdCat)
        prodXcatDelete.array.forEach(element => {
          this._servicesProductoXCategoria.deleteProductoXCategoria(element).subscribe({
            next:()=>{
              this._serviceCategoria.deleteCategoria(categoria).subscribe({
                next:resp=>{
                  if(resp['cod']==200){
                    this.messageService.add({ severity: 'succcess', summary: 'Notificacion', detail: 'Eliminado Correctamente' });
                    this._serviceCategoria.getCategoriaAll().subscribe({
                      next:resp=>this.categoriaList=resp['data']
                    })
                  }
                } 
              });
            }
          })
        });
      }
    })
  }
}

