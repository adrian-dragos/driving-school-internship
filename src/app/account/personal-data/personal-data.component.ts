import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { IPersonalData } from '../personal-data';
import { PersonalDataService } from '../personal-data.service';

@Component({
  selector: 'app-personal-data',
  templateUrl: './personal-data.component.html',
  styleUrls: ['./personal-data.component.scss']
})
export class PersonalDataComponent implements OnInit {

  personalData: IPersonalData;

  constructor(private personalDataService: PersonalDataService,
              private router: Router,
              private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.personalData = this.personalDataService.getPersonalData();

    if (this.personalData.firstName == '' || this.personalData.firstName == null
      || this.personalData.firstName == undefined) {
      this.goToEdit();

      this._snackBar.open("Vă rugăm să complentați pentru a vedea datele personale!", "", {
        duration: 4000, 
        panelClass: ['green-snackbar', ]   
      });
    }
  }

  goToEdit() {
    this.router.navigate(['/main/account/edit']);
  }
}
