import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LayoutComponent } from "./layout.component";
import { FirstComponent } from "./pages/first-component/first.component";
import { SecondComponent } from "./pages/second-component/second.component";

const rutas: Routes = [
    {
        path: 'first', component: FirstComponent
    },
    {
        path: 'second', component: SecondComponent
    },
    {
        path: 'layout', component: LayoutComponent
    },
    {
        path: '**', component: LayoutComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(rutas)],
    exports: [RouterModule]
})
export class LayoutRouting {}