import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.scss']
})
export class LoginComponentComponent implements OnInit {

  constructor() { }

  signupForm: FormGroup;

  ngOnInit(): void {
    this.signupForm = new FormGroup ({
      email: new FormControl('')
    });
  }
}
