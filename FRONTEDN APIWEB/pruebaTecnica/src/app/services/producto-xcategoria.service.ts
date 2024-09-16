import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductoXcategoriaService {
  private _http=inject(HttpClient)
  url:string=environment.urlBase;
  getProductoXCategoriaAll():Observable<any>{
    return this._http.get(this.url+environment.pathGetProductoXCategoria);
  }
  getProductoXCategoria(id:number):Observable<any>{
    return this._http.get(`${this.url}${environment.pathGetProductoXCategoria}?idprodXcat=${id}`);
  }  
  postProductoXCategoria(productoXCategoria:any):Observable<any>{
    return this._http.post(`${this.url}${environment.pathPostProductoXCategoria}`, productoXCategoria);
  }
  deleteProductoXCategoria(productoXCategoria:any):Observable<any>{
    return this._http.delete(`${this.url}${environment.pathDeleteProductoXCategoria}`, productoXCategoria);
  }
}
