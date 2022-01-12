import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators  } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppService } from 'src/app/app.service';
import { Person } from 'src/app/Person';
import { IPersonalData } from '../personal-data';
import {formatDate} from '@angular/common';
import { MainAppComponent } from 'src/app/main-app/main-app.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  hide: boolean = true;
  editForm: FormGroup;
  personalData: IPersonalData;
  personalDataString: string;
  loading: boolean = false;
  errorMessage;
  hasBirthday: boolean = false;

  constructor(private _snackBar: MatSnackBar,
              private appService : AppService,
              private router: Router) {}

  async ngOnInit(): Promise<void> {

    await this.appService.getGlobalUserById()
    .subscribe(
      (response) => {                           //next() callback
        console.log('response received')
        this.personalData = response;
        let birthday =  "";
        if (this.personalData.firstName != null) {
          this.hasBirthday = true; 
          birthday =  formatDate(this.personalData.birthday,'dd/MM/yyyy','en-US');
        }
        console.log(response.email);
        this.editForm = new FormGroup({
          userEmail: new FormControl(response.email, [Validators.required, Validators.email]),
          firstName: new FormControl(this.personalData.firstName, Validators.required ),
          lastName: new FormControl(this.personalData.lastName, Validators.required ),
          phoneNumber: new FormControl(this.personalData.phoneNumber, Validators.required),
          birthday: new FormControl(birthday, Validators.required),
          gearType: new FormControl(this.personalData.gearType, Validators.required),
        });
    })
  }

  onSubmit() {
    console.log("onEdit");
    this.editForm.markAllAsTouched();
    console.log(this.editForm);

    console.log(this.editForm.valid);
    if (this.editForm.valid) {        
      console.log(this.editForm);
      this.setPersonalData();      
      //this.router.navigate(['/main/account/personal-data']);
    }
  }


  async setPersonalData() {
    console.log(this.editForm);
    let email = this.editForm.get('userEmail').value;
    let firstName = this.editForm.get('firstName').value;
    let lastName = this.editForm.get('lastName').value;
    let phoneNumber = this.editForm.get('phoneNumber').value;
    let birthday = this.toDate(this.editForm.get('birthday').value);    
    let gearType = this.editForm.get('gearType').value;
    console.log("birthday" + birthday);
    let person = new Person(email, this.appService.globalId, firstName, lastName, phoneNumber, birthday, gearType);

    await this.appService.modifyUserPersonalData(person)
      .subscribe(
        (response) => {     
          console.log("respone on register on server: ");
          console.log(response);   
        })

    this._snackBar.open("Modificarea a fost efectuată!", "", {
      duration: 4000, 
      panelClass: ['green-snackbar', ]   
    });  
  }

  toDate(date: string) : Date {
    date.trim;
    let res = date.split('/')
    console.log(res);
    return new Date(date);
  }
}

