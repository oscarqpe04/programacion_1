import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'second-component',
    templateUrl: 'second.component.html'
})

export class SecondComponent implements OnInit {
    nombre1: string = 'kaus sergSi Valde';
    
    constructor() { }

    ngOnInit() { }
}