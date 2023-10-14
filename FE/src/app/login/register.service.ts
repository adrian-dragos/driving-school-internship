import { ContentObserver } from "@angular/cdk/observers";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class RegisterService {
    
    private Url = 'https://localhost:44340/api/Students/';

    constructor(private http: HttpClient) { }

    registerUser(email : any, password: any): Observable<any> {
        const headers = { 'content-type': 'application/json'}  
        var person = new Person(email, password);
        const body=JSON.stringify(person);
        console.log(body)
        return this.http.post(this.Url, body,{'headers':headers})
    }
}

class Person {
    email: string;
    password: string;

    constructor(email : string, password : string) { 
        this.email = email; 
        this.password = password; 
    }
}
