import { Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AppService } from '../app.service';

@Component({
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.scss']
})
export class MainAppComponent implements OnInit {

  title: string = "Planificare Lecții";
  name = '';
  openedAvatar: boolean = false;
  loged: boolean = false;
  
  constructor(private appService: AppService, private _snackBar: MatSnackBar) {}


  ngOnInit(): void {
    this.getName();
  }

  toggleMenu() {
    this.openedAvatar = !this.openedAvatar;
  }

  doSomething() {
    let element = (<HTMLElement>document.getElementById('dropDown'));
    element.click();
  }

  refreshPage(): void {
    window.location.reload();
  }

  over() {
    document.getElementById("avatar-name").style.fontWeight = "549";
    document.getElementById("avatar").style.transform = "scale(1.35)";
    document.getElementById("dropDown").style.transform = "scale(1)";
  }

  out() {
    document.getElementById("avatar-name").style.fontWeight = "1.30";
    document.getElementById("avatar").style.transform = "scale(1.30)";
    document.getElementById("dropDown").style.transform = "scale(0.9)";
  }

  durationInSeconds = 5;
  openLogoutBar() {
    this._snackBar.open("Ieșirea a avut loc cu succes", "", {
      duration: this.durationInSeconds * 1000, 
      panelClass: ['green-snackbar', ]   
    });
  }

  async getName() {
    await this.appService.getGlobalUserById()
    .subscribe(
      (response) => {                           //next() callback
        console.log('response received main app')
        if (response.firstName != undefined) {        
          this.name = response.firstName + " " + response.lastName;        
        }
    })
  }

}
