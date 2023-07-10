import { NgModule } from '@angular/core';

import { LayoutComponent } from './layout.component';
import { LayoutRouting } from './layout.routing';
import { FirstComponent } from './pages/first-component/first.component';
import { SecondComponent } from './pages/second-component/second.component';
import { VoteTakerComponent } from 'src/app/components/vote-taker/vote.taker.component';
import { VoteComponent } from 'src/app/components/app-vote/app.vote.component';
import { CapitalizePipe } from 'src/app/pipes/capitalize.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        LayoutRouting,
        ReactiveFormsModule,
        MatButtonModule
    ],
    exports: [],
    declarations: [
        LayoutComponent, FirstComponent, SecondComponent,
        VoteTakerComponent,
        VoteComponent,
        CapitalizePipe
    ],
    providers: [],
})
export class LayoutModule { }
