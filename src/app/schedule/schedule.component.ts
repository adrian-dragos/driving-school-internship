import { Component} from '@angular/core';

@Component({
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class SchedulComponent {
  selected: Date | null;
}