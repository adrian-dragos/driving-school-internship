import { Component, OnChanges, SimpleChanges} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CancelLessonDialogComponent } from './cancel-lesson-dialog/cancel-lesson-dialog.component';
import { ILesson } from './lesson';
import { ScheduleService } from './schedule.serice';

@Component({
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class SchedulComponent {

  selected: Date | null;
  
  lessons: any[];
  filteredLessons: any[];

  errorMessage: string = '';
   
  constructor(private scheduleService: ScheduleService, 
              private _snackBar : MatSnackBar,
              private dialog: MatDialog) {}


  ngOnInit(): void {
    this.lessons = this.scheduleService.getLessons();
    this.lessons = this.lessons.map(item => ({
      ...item,
      isSelected: false
    }));
    this.selected = new Date();
    this.filteredLessons = this.lessons;
    this.filteredLessons = this.filterByDate();
  }

  ngOnDestroy(): void {
  
  }

  filterByDate() : ILesson[] { 
    return this.lessons.filter((lesson : ILesson) => (lesson.date.getDate() == this.selected.getDate() &&
      lesson.date.getMonth() == this.selected.getMonth() && lesson.date.getFullYear() == this.selected.getFullYear()));
  }

  sortAscedning(lessons: any) : ILesson[] {
    return lessons.sort((a : ILesson, b : ILesson) => (a.date.getHours() - b.date.getHours()) && (a.date.getHours() - b.date.getHours()));
  }
  
  filterListByDate() {
    this.filteredLessons = this.filterByDate();
    this.filteredLessons = this.sortAscedning(this.filteredLessons);
  }
 
  changeBackgroundColor(lesson: any) {
    // daca lectia este selectata
    if (lesson.isSelected) {
      // se deschide on dialog
      const dialogRef = this.dialog.open(CancelLessonDialogComponent);
      // se primete raspuns de la dialog
      dialogRef.afterClosed().subscribe(isLessonCanceled => {
        // daca raspunsul arata ca lectia a fost anulata
        if (isLessonCanceled) {
          this._snackBar.open("Lecția a fost anulată.", "", {
            duration: 5000, 
            panelClass: ['blue-snackbar', ]   
          });
          lesson.isSelected = false;
        }
      });        
    } else { // daca lectia nu este selectata
      this._snackBar.open("Lecția a fost planificată.", "", {
        duration: 5000, 
        panelClass: ['green-snackbar', ]   
      });
    }
  }

  toggleLessonsSelection(lesson: any) {
    if (!lesson.isSelected) {
      lesson.isSelected = true;
    }
  }
}
