import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { App } from "../_models/app";
import { Observable } from "rxjs";


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    public getAll() {
        return this.http.get<App[]>(`${environment.apiUrl}/api/App`);
    }

    public getById(id: number) {
        return this.http.get<App[]>(`${environment.apiUrl}/api/App/${id}`);
    }

    public post(app: App) : Observable<any> {
        return this.http.post<any>(`${environment.apiUrl}/api/App`, app);
    }
} 