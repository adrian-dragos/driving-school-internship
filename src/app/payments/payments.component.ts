import { Component, OnDestroy, OnInit } from '@angular/core';
import { IPayments } from './payments';
import { PaymentsService } from './payments.service';


@Component({
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class PaymentsComponent implements OnInit, OnDestroy {
  
  payments: IPayments[] = [];
  errorMessage: string = '';
   
  constructor(private paymentsService: PaymentsService) {}

  ngOnInit(): void {
    this.payments = this.paymentsService.getPayments();
  }

  ngOnDestroy(): void {
  
  }
}

