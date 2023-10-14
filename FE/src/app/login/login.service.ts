import { ContentObserver } from "@angular/cdk/observers";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class LoginService {
    //private Url = 'https://localhost:44340/api/Students/email?email=grosu.marin41%40gmail.com';
    private Url = 'https://localhost:44340/api/Students/';

    constructor(private http: HttpClient) { }

    getUserByEmail(email : any): Observable<any> {
        return this.http.get(this.Url + "email?email=" + encodeURIComponent(email));
    }
}
