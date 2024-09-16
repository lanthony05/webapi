import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  {
    path: 'producto',
    loadChildren: () => import('./producto/producto.module').then(m => m.ProductoModule)
  },
  {
    path: 'categoria',
    loadChildren: () => import('./categoria/categoria.module').then(m => m.CategoriaModule)
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventarioRoutingModule { }
