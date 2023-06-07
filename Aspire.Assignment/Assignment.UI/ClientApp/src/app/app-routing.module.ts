import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_helpers/auth.guard';
import { EmployeeBYIDComponent } from './employee/employeeById.component';


const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const usersModule = () => import('./users/users.module').then(x => x.UsersModule);
const employeeModule=()=>import('./employee/employee.module').then(x=>x.EmployeeModule);
const profileModule =()=>import('./profile/profile.module').then(x=>x.ProfileModule);
const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'apps', loadChildren: usersModule, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },
    { path:'empl',loadChildren:employeeModule, canActivate: [AuthGuard]},
    {path:'view',loadChildren:profileModule},




    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }