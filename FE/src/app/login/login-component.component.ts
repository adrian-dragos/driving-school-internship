import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppService } from '../app.service';
import { CustomValidators } from './custom-validators/custom-validators';
import { LoginService } from './login.service';
import { RegisterService } from './register.service';

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

  loading: boolean;
  errorMessage: string;
  user: any;

  constructor(private loginService: LoginService,
              private registerService: RegisterService,
              private appService: AppService,
              private _snackBar: MatSnackBar,
              private router: Router) {}
  

  async ngOnInit() {
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

  async onSubmitLogin() {
    await this.loginService.getUserByEmail(this.signinForm.get('email').value)
      .subscribe(
        (response) => {                           //next() callback
          console.log('response received')
          if (response == undefined) {
            this.openFailLoginBar("Email-ul este inexistent!");
          }
          if (response.password == this.signinForm.get('password').value) {
            this.appService.setGlobalId(response.id);
            this.router.navigate(["/main/account/personal-data"]);
            this.openSuccessfullLoginBar();
          } else {
            this.openFailLoginBar("Parola este greșită.");
          }
        })
  }


  async onSubmitRegister() {
    await this.loginService.getUserByEmail(this.registerForm.get('email').value)
      .subscribe(
        (response) => {                           //next() callback
          console.log('response received')
          this.user = response;
          
          if (this.user != undefined)
          {
              this.onFailRegisterBar();
          } else if (this.registerForm.valid) { 
            this.registerEmailAndPasswordToServer();
            this.clearRegisterForm();       
            this.openSuccessfullRegisterBar();   
            this.switchToTabOne();     
          }
        })
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

  onFailRegisterBar() {
    this._snackBar.open("Email-ul dat există. Vă rugăm să folosiți alt email.", "", {
      duration: 4000, 
      panelClass: ['blue-snackbar', ]   
    });
  }

  openFailLoginBar(message : string) {
    this._snackBar.open(message, "", {
      duration: 4000, 
      panelClass: ['blue-snackbar', ]   
    });
  }

  switchToTabOne()
  {
    this.tabIndex = 0;
  }

  clearRegisterForm() {
    this.registerForm.reset();
    this.registerForm.get('email').clearValidators();
    this.registerForm.get('email').updateValueAndValidity();
    this.registerForm.get('password').clearValidators();
    this.registerForm.get('password').updateValueAndValidity();
    this.registerForm.get('confirmPassword').clearValidators();
    this.registerForm.get('confirmPassword').updateValueAndValidity();
  }

  async registerEmailAndPasswordToServer() {
    await this.registerService.registerUser(this.registerForm.get('email').value, this.registerForm.get('password').value)
      .subscribe(
        (response) => {     
          console.log("respone on register on server: " + response);
        })
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