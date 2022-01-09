import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators  } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { IPersonalData } from '../personal-data';
import { PersonalDataService } from '../personal-data.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {


  editForm: FormGroup;
  personalData: IPersonalData;

  constructor(private _snackBar: MatSnackBar,
              private personalDataService: PersonalDataService,
              private router: Router,) {}

  ngOnInit(): void {
    this.personalData = this.personalDataService.getPersonalData();

    this.editForm = new FormGroup({
      email: new FormControl(this.personalData.email,[Validators.required, Validators.email]),
      firstName: new FormControl(this.personalData.firstName, Validators.required ),
      lastName: new FormControl(this.personalData.lastName, Validators.required ),
      phoneNumber: new FormControl(this.personalData.phoneNumber, Validators.required),
      birthday: new FormControl(this.personalData.birthday, Validators.required),
      gearType: new FormControl(this.personalData.gearType, Validators.required),
    });
  }


  onSubmit() {
    console.log("onEdit");
    this.editForm.markAllAsTouched();
    console.log(this.editForm);

    console.log(this.editForm.valid);
    if (this.editForm.valid) {
      this._snackBar.open("Modificarea a fost efectuată!", "", {
        duration: 4000, 
        panelClass: ['green-snackbar', ]   
      });      
      this.personalDataService.setPersonalData(this.editForm.value);
      //this.router.navigate(['/main/account/personal-data']);
    }
  }
}
