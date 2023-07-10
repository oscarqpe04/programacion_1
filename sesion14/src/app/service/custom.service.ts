import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class CustomService {
    constructor(private http: HttpClient) { }
    
    getUsuarios() {
        return this.http.get("http://localhost:5219/api/Usuario")
    }

    crearUsuario(body: any) {
        return this.http.post("http://localhost:5219/api/Usuario", body);
    }
}