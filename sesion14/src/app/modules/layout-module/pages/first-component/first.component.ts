import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'first-component',
    templateUrl: 'first.component.html'
})

export class FirstComponent implements OnInit {
    title = 'Angular APP';
    heroes = ['Superman', 'Batman', 'Flash'];

    constructor() { }

    ngOnInit() { }

    miFuncion() {
        console.log(this.title);
    }

    miFuncion2() {
        this.title = "Hola Mundo";
    }

    miFuncion3(param: string) {
        this.title = param;
    }
}