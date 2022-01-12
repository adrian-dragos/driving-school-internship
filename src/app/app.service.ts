import { ContentObserver } from "@angular/cdk/observers";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { Person } from "./Person";


@Injectable({
  providedIn: 'root'
})
export class AppService {    
    private Url:string = 'https://localhost:44340/api/Students/';
    public globalEmail:string ="grosu.marin41@gmail.com";
    public globalId:number = 7;

    constructor(private http: HttpClient) { }


    getGlobalUserByEmail(): Observable<any> {
      return this.http.get(this.Url + "email?email=" + encodeURIComponent(this.globalEmail));
    }


    getGlobalUserById(): Observable<any> {
        console.log(this.globalId);
        return this.http.get(this.Url + this.globalId);
      }

    setGlobalUserEmail(email: any) {
        this.globalEmail = email;
    }

    setGlobalId(id : number) {
        this.globalId = id;
    }


    getLessons() {
       // return this.http.get(this.Url + "email?email=" + encodeURIComponent(email));
    }

    modifyUserPersonalData(person : Person): Observable<any> {
        const headers = { 'content-type': 'application/json'};
        const body=JSON.stringify(person);
        console.log(body);
        return this.http.patch(this.Url + "student", body,{'headers':headers})
    }
}
