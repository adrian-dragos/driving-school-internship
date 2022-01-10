import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {

  
  reviewForm: FormGroup;
  haveReviews: boolean = true;
  greenButtonColor: string = '#acf1ac';  
  yellowButtonColor: string = '#fbfbbf'; 
  redButtonColor: string = '#fcc2c2';  
  greenButton  : boolean = false;
  yellowButton: boolean = false;
  redButton: boolean = false;
  showError: boolean = false;


  constructor (private router : Router, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.reviewForm = new FormGroup({
      description: new FormControl(null, Validators.required)    
    });
  }

  changeColorGreenButton () {
    this.yellowButtonColor = '#fbfbbf';
    this.redButtonColor = '#fcc2c2';
    if (this.greenButton) {
      this.greenButton = false;
      this.greenButtonColor = '#acf1ac';
    } else {
      this.greenButton = true;
      this.greenButtonColor = '#10d610';
    }

    this.yellowButton = false;
    this.redButton = false;
  }
  
  changeColorYellowButton () {
    this.greenButtonColor = '#acf1ac';
    this.redButtonColor = '#fcc2c2';
    if (this.yellowButton) {
      this.yellowButton = false;
      this.yellowButtonColor = '#fbfbbf';
    } else {
      this.yellowButton = true;
      this.yellowButtonColor = '#f3f347';
    }
    this.greenButton = false;
    this.redButton = false;
  }

  changeColorRedButton () {
    this.greenButtonColor = '#acf1ac';
    this.yellowButtonColor = '#fbfbbf';
    if (this.redButton) {
      this.redButton = false;
      this.redButtonColor = '#fcc2c2';
    } else {
      this.redButton = true;
      this.redButtonColor = '#f64f4f'
    }
    this.greenButton = false;
    this.yellowButton = false;
  }


  onSumbit() {
    console.log("onEdit");
    this.reviewForm.markAllAsTouched();
    console.log(this.reviewForm);
    console.log("green button:" + this.greenButton  + "\nyellow button: " + this.yellowButton + "\nred button:" + this.redButton);

    if (this.redButton || this.yellowButton || this.greenButton) {      
      this.showError = false;
      this.goToSchedule();
      this._snackBar.open("Evaluarea efectuată cu succes. Vă mulțumim pentru evaluarea dvs.", "", {
        duration: 5000, 
        panelClass: ['green-snackbar', ]   
      });
    } else {
      this.showError = true;
    }
  }

  goToSchedule() {
    this.router.navigate(['/main/practice']);
  }
}
