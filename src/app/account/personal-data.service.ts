import { ContentObserver } from "@angular/cdk/observers";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import { AppService } from "../app.service";
import { IPersonalData } from "./personal-data";


@Injectable({
  providedIn: 'root'
})
export class PersonalDataService {    


    private Url = 'https://localhost:44340/api/Students/';

    constructor(private http: HttpClient, private appService : AppService) { }

    getUserPersonalData(): Observable<any> {
      return this.http.get(this.Url + "email?email=" + encodeURIComponent(this.appService.globalEmail));
    }


    private personalData = {
      firstName: '',
      lastName: '',
      email: '',
      phoneNumber: '',
      birthday: null,
      gearType: ''
    }

    getPersonalData() : IPersonalData {
      return this.personalData;
    }

    setPersonalData(data: any) : void {
        this.personalData.firstName = data.firstName;
        this.personalData.lastName = data.lastName;
        this.personalData.email = data.email
        this.personalData.phoneNumber = data.phoneNumber;
        this.personalData.birthday = data.birthday;
        this.personalData.gearType = data.gearType;
    }

    

   
}