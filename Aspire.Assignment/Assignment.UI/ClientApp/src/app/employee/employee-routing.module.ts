import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LayoutComponent } from './layout.component';
import { EmployeeComponent } from './employee.component';
import { AddeditemployeeComponent } from './addeditemployee.component';
import { EmployeeBYIDComponent } from './employeeById.component';
import { EditemployeeComponent } from './editemployee.component';

const routes: Routes = [
    {
        path: '', component: LayoutComponent,
        children: [
            { path: '', component: EmployeeComponent },
            { path: 'addEmployee', component: AddeditemployeeComponent},
            { path: 'view/:id', component: EmployeeBYIDComponent},
            { path: 'edit/:id', component: EditemployeeComponent},


        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class EmployeeRoutingModule { }