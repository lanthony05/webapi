import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NotfoundComponent } from './demo/components/notfound/notfound.component';
import { AppLayoutComponent } from "./layout/app.layout.component";
import { loginGuard } from './guards/login.guard';
import { sesionGuard } from './guards/sesion.guard';

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'techstore', pathMatch: 'full'}, 
            {
                path: 'techstore', component: AppLayoutComponent,
                children: [
                    { path: 'inventarios', loadChildren: () => import('./modulos/inventarios/inventario.module').then( m => m.InventarioModule ) },

                ]
            },
            { path: 'landing', loadChildren: () => import('./demo/components/landing/landing.module').then(m => m.LandingModule) },
            { path: 'notfound', component: NotfoundComponent },
            { path: '**', redirectTo: '/notfound' },
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
