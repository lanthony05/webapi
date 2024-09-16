import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  private _http=inject(HttpClient);
  url:string=environment.urlBase;
  constructor() { }
  getCategoriaAll():Observable<any>{
    return this._http.get(this.url+environment.pathGetCategoria);
  }
  getCategoria(id:number):Observable<any>{
    return this._http.get(`${this.url}${environment.pathGetCategoria}?idcategoria=${id}`);
  }
  postCategoria(categoria:any):Observable<any>{
    return this._http.post(`${this.url}${environment.pathPostCategoria}`, categoria);
  }
  putCategoria(categoria:any):Observable<any>{
    return this._http.put(`${this.url}${environment.pathPutCategoria}`, categoria);
  }
  deleteCategoria(categoria:any):Observable<any>{
    return this._http.delete(`${this.url}${environment.pathPostCategoria}`, categoria);
  }
}
