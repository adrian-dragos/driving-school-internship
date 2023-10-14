import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppService } from 'src/app/app.service';
import { Person } from 'src/app/Person';
import { IPersonalData } from '../personal-data';
import { PersonalDataService } from '../personal-data.service';

@Component({
  selector: 'app-personal-data',
  templateUrl: './personal-data.component.html',
  styleUrls: ['./personal-data.component.scss']
})
export class PersonalDataComponent implements OnInit {

  personalData: Person;
zzzzz
  constructor(private appService: AppService,
              private router: Router,
              private _snackBar: MatSnackBar) { }


  async ngOnInit() {
    await this.appService.getGlobalUserById()
    .subscribe(
      (response) => {                           //next() callback
        console.log('response received')
        this.personalData = response;
        if (this.personalData.firstName == '' || this.personalData.firstName == null
          || this.personalData.firstName == undefined) {
          this.goToEdit();

          this._snackBar.open("Vă rugăm să complentați pentru a vedea datele personale!", "", {
            duration: 4000, 
            panelClass: ['green-snackbar', ]   
          });
        }
        console.log(response.email);
        console.log("complete");
    })

  }

  goToEdit() {
    this.router.navigate(['/main/account/edit']);
  }
}
