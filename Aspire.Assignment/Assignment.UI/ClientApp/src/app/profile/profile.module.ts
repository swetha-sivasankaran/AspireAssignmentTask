import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile.component';
import { LayoutComponent } from './layout.component';
import { ProfileRoutingModule } from './profile-routing.module';



@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        ProfileRoutingModule
    ],
    declarations: [
        LayoutComponent,
        ProfileComponent,
    ]
})
export class ProfileModule { }