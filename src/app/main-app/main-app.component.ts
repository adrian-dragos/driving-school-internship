import { Component} from '@angular/core';

@Component({
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.scss']
})
export class MainAppComponent {

  title: string = "Planificare Lecții";
  name = 'Donald Trump';
  openedAvatar: boolean = false;
  loged: boolean = false;


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
}
