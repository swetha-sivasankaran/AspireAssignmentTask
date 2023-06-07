import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { TokenResponse, User } from '../_models/user';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AccountService {
    private userSubject: BehaviorSubject<User | null>;
    public user: Observable<TokenResponse | null>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('user')!));
        this.user = this.userSubject.asObservable();
    }

    public get userValue() {
        return this.userSubject.value;
    }

    login(username: string, password: string) {
        const user : User = new User();
        user.username = username;
        user.password = password;
      //  user.id =0;
    //   let headers = new HttpHeaders({
    //     'Accept': 'application/json',
    //     'Content-Type': 'application/json',
              
    //  });
    // let options = { headers: headers };

        return this.http.post<TokenResponse>(`${environment.apiUrl}/api/Auth`, user)
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this.userSubject.next(user);
                console.log('Juser ==> ',user)
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['/account/login']);
    }

    register(user: User) {  
        user.id =0;
      //  console.log('register input user =>', user);
        // let headers = new HttpHeaders({
        //     'Accept': 'application/json',
        //     'Content-Type': 'application/json',
                  
        //  });
        // let options = { headers: headers };
          //'Authorization': this.basic,
        // 'Accept': 'application/json',
        // 'Content-Type': 'application/json',
        // 'Access-Control-Allow-Origin': '*' 
        //  'Access-Control-Allow-Origin': '*' 
        return this.http.post(`${environment.apiUrl}/api/User`, user);
    }

}