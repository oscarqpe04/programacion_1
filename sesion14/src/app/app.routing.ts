import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";

const rutas: Routes = [
    {
        path: 'auth', loadChildren: () => import('./modules/login-module/login.module').then(m => m.LoginModule)
    },
    {
        path: '', loadChildren: () => import('./modules/layout-module/layout.module').then(m => m.LayoutModule)
    },
    {
        path: '**', component: AppComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(rutas)],
    exports: [RouterModule]
})
export class AppRoutingModule {}