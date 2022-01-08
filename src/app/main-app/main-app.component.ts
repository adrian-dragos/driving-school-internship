import { Component} from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.scss']
})
export class MainAppComponent {

  title: string = "Planificare Lecții";
  name = 'Donald Trump';
  openedAvatar: boolean = false;
  loged: boolean = false;
  
  constructor(private _snackBar: MatSnackBar) {}

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
}
