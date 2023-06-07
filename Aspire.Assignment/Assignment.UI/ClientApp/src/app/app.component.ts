import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';
import { Employee } from './_models/employee';
import { ReferenceTbl } from './_models/referenceTbl';
import { EmployeeService } from './_services/employee.service';
import { ActivatedRoute } from '@angular/router';


@Component({ selector: 'app-root', templateUrl: 'app.component.html' })
export class AppComponent  {
    user?: User | null;

    constructor(private accountService: AccountService) {
        this.accountService.user.subscribe(x => this.user = x);
    }


    logout() {
        this.accountService.logout();
    }
}