import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomValidators } from 'src/app/login/custom-validators/custom-validators';


@Component({
  selector: 'app-modify-password',
  templateUrl: './modify-password.component.html',
  styleUrls: ['./modify-password.component.scss']
})
export class ModifyPasswordComponent implements OnInit {

  constructor(private _snackBar: MatSnackBar) {}

  modifyPasswordForm: FormGroup;
  submitted: boolean = false;

  ngOnInit(): void {
    this.modifyPasswordForm = new FormGroup ({
      _oldPassword: new FormControl('', [Validators.required, Validators.minLength(5),  Validators.maxLength(30)]),
      _newPassword: new FormControl('', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(30),
        Validators.required,
        CustomValidators.patternValidator(/\d/, { hasNumber: true }),
        CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true }),
        CustomValidators.patternValidator(/[a-z]/, { hasSmallCase: true }),
        ])),
        confirmPassword: new FormControl('',[Validators.required]),
      }, this.arePasswordEqualValidator);
    }

  arePasswordEqualValidator(formGroup: FormGroup) : any {
    const password = formGroup.get('_newPassword').value;
    const confirmPassword = formGroup.get('confirmPassword').value;
  
    if (password !== confirmPassword) 
    {
      // if they don't match, set an error in our confirmPassword form control
      formGroup.get('confirmPassword').setErrors({ NoPassswordMatch: true });
    }
  }

  onSubmit() {
    console.log("onModifyPassword");
    this.modifyPasswordForm.markAllAsTouched();
    console.log(this.modifyPasswordForm);
    this.submitted = true;

    if (this.modifyPasswordForm.valid){
      this._snackBar.open("Parola a fost modificată", "", {
        duration: 4000, 
        panelClass: ['green-snackbar', ]   
      });

      this.modifyPasswordForm.reset();
      this.modifyPasswordForm.get('_oldPassword').clearValidators();
      this.modifyPasswordForm.get('_oldPassword').updateValueAndValidity();
      this.modifyPasswordForm.get('_newPassword').clearValidators();
      this.modifyPasswordForm.get('_newPassword').updateValueAndValidity();
      this.modifyPasswordForm.get('confirmPassword').clearValidators();
      this.modifyPasswordForm.get('confirmPassword').updateValueAndValidity();        
    }
  }
}
