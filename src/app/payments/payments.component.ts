import { Component, OnInit } from '@angular/core';
import { IPayments } from './payments';
import { PaymentsService } from './payments.service';

@Component({
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class PaymentsComponent implements OnInit {
  
  payments: IPayments[] = [];
   
  constructor(private paymentsService: PaymentsService) {}

  ngOnInit(): void {
  }

}

