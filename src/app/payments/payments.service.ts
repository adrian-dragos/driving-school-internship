import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IPayments } from "./payments";

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {
    private paymentUrl = 'api/payments/payments.json';

    constructor(private http: HttpClient) { }

    // getPayments() : Observable<IPayments[]> {
    //   return this.http.get<IPayments[]>(this.paymentUrl).pipe(
    //     tap(data => console.log('All: ', JSON.stringify(data))),
    //     catchError(this.handleError)
    //   );
    // }

    getPayments() : IPayments[] {
      return [
        {
          "date": new Date(2021, 12, 4),
          "sum": 200,
          "service": "Practică",
          "paymentMethod": "Credit Card",
          "payer": "Donald Trump"
        },
        {
            "date": new Date(2021, 8, 1),
            "sum": 200,
            "service": "Practică",
            "paymentMethod": "Credit Card",
            "payer": "Donald Trump"
          },
          {
            "date": new Date(2021, 2, 10),
            "sum": 949,
            "service": "Practică",
            "paymentMethod": "Cash",
            "payer": "Admin"
          }
      ]
    }
}