import { Component} from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  

  title: string = "Planificare Lecții";
  name = 'Donald Trump';
  openedAvatar: boolean = false;


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
