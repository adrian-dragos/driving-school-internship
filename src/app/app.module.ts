import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule} from '@angular/material/menu';
import { SchedulComponent } from './schedule/schedule.component';
import { AccountComponent } from './account/account.component';
import { PaymentsComponent } from './payments/payments.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { LessonsComponent } from './lessons/lessons.component';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table'



@NgModule({
  declarations: [
    AppComponent,
    SchedulComponent,
    AccountComponent,
    PaymentsComponent,
    ReviewsComponent,
    LessonsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatMenuModule,
    HttpClientModule,
    MatTableModule,
    RouterModule.forRoot([
      { path: 'practice', component: SchedulComponent},
      { path: 'account', component: AccountComponent },
      { path: 'payments', component: PaymentsComponent },
      { path: 'reviews', component: ReviewsComponent},
      { path: 'lessons', component: LessonsComponent},
      { path: '', redirectTo: 'practice', pathMatch: 'full' },
      { path: '**', redirectTo: 'practice', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
