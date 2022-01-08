import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators  } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {


  editForm: FormGroup;

  constructor(private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.editForm = new FormGroup({
      email: new FormControl(null,[Validators.required, Validators.email]),
      firstName: new FormControl(null, Validators.required ),
      lastName: new FormControl(null, Validators.required ),
      phoneNumber: new FormControl(null, Validators.required),
      birthday: new FormControl(null, Validators.required),
      gearType: new FormControl(null, Validators.required),
    });
  }


  onSubmit() {
    console.log("onEdit");
    this.editForm.markAllAsTouched();
    console.log(this.editForm);

    console.log(this.editForm.valid);
    if (this.editForm.valid){
      this._snackBar.open("Modificarea a fost efectuată!", "", {
        duration: 4000, 
        panelClass: ['green-snackbar', ]   
      });
    }
  }
}
