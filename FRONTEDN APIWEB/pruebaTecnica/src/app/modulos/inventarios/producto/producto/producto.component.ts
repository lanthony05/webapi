import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ProductService } from 'src/app/demo/service/product.service';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { DialogproductoComponent } from './dialogproducto/dialogproducto.component';
import { ProductosService } from 'src/app/services/productos.service';

import { ProductoModel } from 'src/app/Models/producto.model';
import { CategoriaModel } from 'src/app/Models/categoria.model';
import { ProductoXcategoriaService } from 'src/app/services/producto-xcategoria.service';
import { ProductoXcategoriaModel } from 'src/app/Models/productoXcategoria.model';

@Component({
  selector: 'app-componente',
  templateUrl: './producto.component.html',
  styles: ``,
  providers: [MessageService, ConfirmationService]
})
export class ProductoComponent {
  @ViewChild(DialogproductoComponent) dialogoProducto: DialogproductoComponent;
  _serviceProducto = inject(ProductosService);
  private _servicesProductoXCategoria=inject(ProductoXcategoriaService);
  xs:string='';
  productoList:ProductoModel[]=[];
  categoriaList:CategoriaModel[]=[];
  loading: boolean = true;
  nombreProducto='';
  constructor(public layoutService: LayoutService, 
     private messageService: MessageService) {}
  

    
  activityValues: number[] = [0, 100];
  

  
  ngOnInit(): void {   
      this._serviceProducto.getProductosAll().subscribe({
        next:resp=>{
          this.productoList=resp['data']
        }
      })
  }
  dialogNuevoCliente(){
    this.dialogoProducto.textoTitle='Crear Producto';
    this.dialogoProducto.visibleClient = true;
  }
  registrarProduct(producto:ProductoModel){      
    this.categoriaList=this.dialogoProducto.categoriaSelect;
      if(producto.IdProd!=null){
        this._serviceProducto.putProducto(producto).subscribe({
          next:resp=>{
            if(resp['cod']==200){
              this.messageService.add({ severity: 'succcess', summary: 'Notificacion', detail: 'Actualizado Correctamente' });
              this.nombreProducto=producto.NombProd;              
            this._serviceProducto.getProductosAll().subscribe({
              next:resp=>{
                this.productoList=resp["data"]
                let producId=this.productoList.find(x=>x.NombProd==this.nombreProducto).IdProd
                this.categoriaList.forEach(x=>{
                  let proXcat:ProductoXcategoriaModel={
                    id:0,
                    idCat:x.IdCat,
                    idProd:producId
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
  producto.IdProd=0;
  this._serviceProducto.postProducto(producto).subscribe({
    next:resp=>{
      if(resp['cod']==200){
        this.messageService.add({ severity: 'succcess', summary: 'Notificacion', detail: 'Ingresado Correctamente' });        
        this._serviceProducto.getProductosAll().subscribe({
          next:resp=>{
            this.productoList=resp["data"]
            let producId=this.productoList.find(x=>x.NombProd==this.nombreProducto).IdProd
            this.categoriaList.forEach(x=>{
              let proXcat:ProductoXcategoriaModel={
                id:0,
                idCat:x.IdCat,
                idProd:producId
              }
              this._servicesProductoXCategoria.postProductoXCategoria(proXcat);
            })
          }
        })
      }
  }
  })
}
  actualizarProducto(producto:ProductoModel){
    this.dialogoProducto.textoTitle='Actualizar Producto';
    this.dialogoProducto.producto=producto;
    this.dialogoProducto.visibleClient=true;
  }
  eliminarProducto(producto:ProductoModel){
    this._servicesProductoXCategoria.getProductoXCategoriaAll().subscribe({
      next: resp=>{
          let prodXcat=resp['data']
          let prodXcatDelete=prodXcat.filter(x=>x.idProdcuto==producto.IdProd);
          prodXcatDelete.array.forEach(element => {
            this._servicesProductoXCategoria.deleteProductoXCategoria(element).subscribe({
              next: ()=>{}
            })
            this._serviceProducto.deleteProducto(producto).subscribe({
              next:resp=>{
                if(resp['cod']==200){
                  this.messageService.add({ severity: 'succcess', summary: 'Notificacion', detail: 'Eliminado Correctamente' });
                  this._serviceProducto.getProductosAll().subscribe({
                    next: resp=>this.productoList=resp['data']
                  })
                }
              } 
            });      
          });
      }
    })
  }
}

