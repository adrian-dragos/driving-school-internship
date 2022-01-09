import { ContentObserver } from "@angular/cdk/observers";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IPersonalData } from "./personal-data";


@Injectable({
  providedIn: 'root'
})
export class PersonalDataService {
    private paymentUrl = 'api/payments/payments.json';
    private personalData = {
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: '',
        birthday: null,
        gearType: ''
    }

    constructor(private http: HttpClient) { }

    // getPayments() : Observable<IPayments[]> {
    //   return this.http.get<IPayments[]>(this.paymentUrl).pipe(
    //     tap(data => console.log('All: ', JSON.stringify(data))),
    //     catchError(this.handleError)
    //   );
    // }

    getPersonalData() : IPersonalData {
      console.log("get persoanal data");
      console.log(this.personalData);
      return this.personalData;
    }

    setPersonalData(data: any) : void {
        this.personalData.firstName = data.firstName;
        this.personalData.lastName = data.lastName;
        this.personalData.email = data.email
        this.personalData.phoneNumber = data.phoneNumber;
        this.personalData.birthday = data.birthday;
        this.personalData.gearType = data.gearType;
        
        console.log("set personal data");
        console.log(this.personalData);
    }
    
}