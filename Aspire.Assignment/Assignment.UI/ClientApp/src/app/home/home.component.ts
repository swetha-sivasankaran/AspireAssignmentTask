import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { TokenResponse, User } from '../_models/user';



@Component({ templateUrl: 'home.component.html' })
export class HomeComponent{
    user: TokenResponse | null;

    

    constructor(private accountService: AccountService
        ) {
        this.user = this.accountService.userValue;
    }

    
}
