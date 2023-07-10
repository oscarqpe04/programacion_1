import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { LoginComponent } from './login.component';
import { LoginRouting } from './login.routing';
import { RegisterComponent } from './register/register.component';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [
        LoginRouting,
        CommonModule,
        FormsModule,
    ],
    exports: [],
    declarations: [LoginComponent, RegisterComponent],
    providers: [],
})
export class LoginModule { }
