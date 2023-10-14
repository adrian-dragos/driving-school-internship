import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancelLessonDialogComponent } from './cancel-lesson-dialog.component';

describe('CancelLessonDialogComponent', () => {
  let component: CancelLessonDialogComponent;
  let fixture: ComponentFixture<CancelLessonDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CancelLessonDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CancelLessonDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
