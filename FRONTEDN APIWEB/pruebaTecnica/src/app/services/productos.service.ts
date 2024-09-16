import { Any } from './../../../node_modules/@sigstore/protobuf-specs/dist/__generated__/google/protobuf/any.d';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  private _http=inject(HttpClient)
  url:string=environment.urlBase;
  constructor() { }
  getProductosAll():Observable<any>{
    return this._http.get(this.url+environment.pathGetProducto);
  }
  getProductoID(id:number):Observable<any>{
    return this._http.get(`${this.url}${environment.pathGetProducto}?idProducto=${id}`);
  }
  postProducto(producto:any):Observable<any>{
    return this._http.post(`${this.url}${environment.pathPostProducto}`, producto);
  }
  putProducto(producto:any):Observable<any>{
    return this._http.put(`${this.url}${environment.pathPutProducto}`, producto);
  }
  deleteProducto(producto:any):Observable<any>{
    return this._http.delete(`${this.url}${environment.pathPostProducto}`, producto);
  }
}
