
import { Component} from '@angular/core';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  

  title = 'UserInterface';
  name = 'Donald Trump';
  sidenavIsOpened: boolean = true;
  openedAvatar: boolean = false;

  toggleSideBar() {
    this.sidenavIsOpened = !this.sidenavIsOpened;
  }

  toggleMenu() {
    this.openedAvatar = !this.openedAvatar;
  }




  doSomething() {
    let element = (<HTMLElement>document.getElementById('dropDown'));
    element.click();
    console.log("vasea");
    //this.dropDown.nativeElement.innerHTML.triggerHandler('click');
  }
}
