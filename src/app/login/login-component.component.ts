import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.scss']
})
export class LoginComponentComponent implements OnInit {

  constructor() { }

  signinForm: FormGroup;
  registerForm: FormGroup;

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
        ])),
        confirmPassword: new FormControl('',[Validators.required])
    });
  }

  onSubmitLogin() {
    console.log("onLogin");
    console.log(this.signinForm);
  }

  onSubmitRegister() {
    console.log("onregister");
    console.log(this.registerForm);
  }

  arePasswordEqualValidator(formGroup: FormGroup) : any {
    const password = formGroup.get('password').value;
    const confirmPassword = formGroup.get('confirmPassword').value;
  
    return password === confirmPassword ? null : { notSame: true } 
  }
}
