import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UserService } from '../_services/user.service';
import { App } from '../_models/app';


@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    apps?: App[];

    constructor(private userService: UserService) {}

    ngOnInit() {
        this.userService.getAll()
           // .pipe(first())
            .subscribe(apps => this.apps = apps);
    }

}