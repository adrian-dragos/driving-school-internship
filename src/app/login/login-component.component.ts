import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomValidators } from './custom-validators/custom-validators';

@Component({
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.scss']
})
export class LoginComponent implements OnInit {

  signinForm: FormGroup;
  registerForm: FormGroup;
  hideSignInPassword: boolean = true;
  hideRegisterPassword: boolean = true;
  hideConfirmPassword: boolean = true;
  tabIndex = 0;

  ngOnInit(): void {
    this.signinForm = new FormGroup ({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('',  Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(30),
        Validators.required,
        ])),
      rememberMe: new FormControl('')
    });

    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.compose([
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

  onSubmitLogin() {
    console.log("onSingin");
    console.log(this.signinForm);
  }


  
  onSubmitRegister() {
    console.log("onregister");
    console.log(this.registerForm);
    if (this.registerForm.valid) {        
      this.registerForm.reset();
      this.registerForm.get('email').clearValidators();
      this.registerForm.get('email').updateValueAndValidity();
      this.registerForm.get('password').clearValidators();
      this.registerForm.get('password').updateValueAndValidity();
      this.registerForm.get('confirmPassword').clearValidators();
      this.registerForm.get('confirmPassword').updateValueAndValidity();        
  
    }
  }

  arePasswordEqualValidator(formGroup: FormGroup) : any {
    const password = formGroup.get('password').value;
    const confirmPassword = formGroup.get('confirmPassword').value;
  
    if (password !== confirmPassword) 
    {
      // if they don't match, set an error in our confirmPassword form control
      formGroup.get('confirmPassword').setErrors({ NoPassswordMatch: true });
    }
  }

  durationInSeconds = 5;

  constructor(private _snackBar: MatSnackBar) {}

  openSuccessfullLoginBar() {
    this._snackBar.openFromComponent(AlertSuccessfullLoginComponent, {
      duration: this.durationInSeconds * 1000,
      panelClass: ['green-snackbar']
    });
  }

  openSuccessfullRegisterBar() {
    this._snackBar.openFromComponent(AlertSuccessfullRegisterComponent, {
      duration: this.durationInSeconds * 1000, 
      panelClass: ['green-snackbar']   
    });
  } 

  switchToTabOne()
  {
    this.tabIndex = 0;
  }
}


@Component({
  templateUrl: 'login-bar-component.html',
})
export class AlertSuccessfullLoginComponent {}

@Component({
  templateUrl: 'register-bar-component.html',
})
export class AlertSuccessfullRegisterComponent {}