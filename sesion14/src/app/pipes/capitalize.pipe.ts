import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'capitalize'
})
export class CapitalizePipe implements PipeTransform {
    transform(value: string, todas: boolean = true): any {
        value = value.toLocaleLowerCase(); "oscar edmit juan"
        let nombres = value.split(" "); //["oscar","edmit", "juan"]
        if (todas) {
            nombres = nombres.map(nombre => {
                return nombre[0].toUpperCase() + nombre.substr(1); // O + scar, E + dmit
            });
        } else {
            nombres[0] = nombres[0][0].toUpperCase() + nombres[0].substr(1); // O + scar
        }
        return nombres.join(" ");
    }
}