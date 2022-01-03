import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  constructor() { }
  title: string = "Date personale";

  ngOnInit(): void {
  }


  changeTitleToPersonalData() {
    this.title = "Date personale";
  }

  changeTitleToEdit() {
    this.title = "Editați contul";
  }

  changeTitleToUpload() {
    this.title = "Încărcați documente";
  }

  changeTitleToChangePassword() {
    this.title = "Modifică parola";
  }
}
