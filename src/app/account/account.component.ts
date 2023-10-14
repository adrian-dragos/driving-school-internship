import { Component, OnInit } from '@angular/core';
import { UrlWithStringQuery } from 'url';

@Component({
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  constructor() { }
  title: string = "Date personale";
  personalDataNavButtonColor: string = '#878f93';
  editNavButtonColor: string = '#878f93';
  uploadNavButtonColor: string ='#878f93';
  changePasswordNavButtonColor: string = '#878f93';

  ngOnInit(): void {
  }


  changeTitleToPersonalData() {
    this.title = "Date personale";
    this.personalDataNavButtonColor = '#ffffff';    
    this.editNavButtonColor = '#878f93';
    this.uploadNavButtonColor = '#878f93';
    this.changePasswordNavButtonColor = '#878f93';
  }

  changeTitleToEdit() {
    this.title = "Editați contul";
    this.editNavButtonColor = '#ffffff';
    this.personalDataNavButtonColor = '#878f93';
    this.uploadNavButtonColor = '#878f93';
    this.changePasswordNavButtonColor = '#878f93';
  }

  changeTitleToUpload() {
    this.title = "Încărcați documente";
    this.uploadNavButtonColor = '#ffffff';
    this.personalDataNavButtonColor = '#878f93';
    this.editNavButtonColor = '#878f93';
    this.changePasswordNavButtonColor = '#878f93';
  }

  changeTitleToChangePassword() {
    this.title = "Modifică parola";
    this.changePasswordNavButtonColor = 'white';
    this.personalDataNavButtonColor = '#878f93';
    this.editNavButtonColor = '#878f93';
    this.uploadNavButtonColor ='#878f93';
  }
}
