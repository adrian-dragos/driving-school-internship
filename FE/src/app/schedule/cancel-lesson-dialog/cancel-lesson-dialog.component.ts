import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-cancel-lesson-dialog',
  templateUrl: './cancel-lesson-dialog.component.html',
  styleUrls: ['./cancel-lesson-dialog.component.scss']
})
export class CancelLessonDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CancelLessonDialogComponent>) { }

  ngOnInit(): void {
  }


  closeDialog() {
    this.dialogRef.close(true);
  }
}
