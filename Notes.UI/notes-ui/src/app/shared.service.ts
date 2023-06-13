import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
    readonly APIUrl = "https://localhost:7225/api";
    constructor(private http: HttpClient) {}

    login(val: any) {
        return this.http.post(this.APIUrl + '/User/login', val);
    }

    registration(val: any) {
        return this.http.post(this.APIUrl + '/User', val);
    }
}