import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CustomService } from 'src/app/service/custom.service';

@Component({
    selector: 'layout-component',
    templateUrl: 'layout.component.html'
})

export class LayoutComponent implements OnInit {

    profileForm = new FormGroup({
        firstName: new FormControl(''),
        lastName: new FormControl('')
    })

    profile: any = {}

    usuarios: any[] = [];

    constructor(private customService: CustomService) { }

    ngOnInit() {
        this.onCargarUsuarios();
    }

    onCargarUsuarios() {
        this.customService.getUsuarios()
        .subscribe((response: any) => {
            console.log(response);
            this.usuarios = response.usuarios;
        });
    }

    onSubmit() {
        console.log(this.profile);
        let body = {
            
        };
        this.customService.crearUsuario(body)
        .subscribe((response: any) => {
            console.log(response);
        })
    }
}