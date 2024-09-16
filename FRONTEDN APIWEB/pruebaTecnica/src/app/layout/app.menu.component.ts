import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Inventarios',
                items: [
                    { label: 'Producto', icon: 'pi pi-fw pi-box' , routerLink: ['/techstore/inventarios/producto'] },
                    { label: 'Categoria', icon: 'pi pi-fw pi-folder', routerLink: ['/techstore/inventarios/categoria'] },
                ]
            },
           
        ];
    }
}
