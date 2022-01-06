import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SchedulComponent } from './schedule/schedule.component';
import { AccountComponent } from './account/account.component';
import { PaymentsComponent } from './payments/payments.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { LessonsComponent } from './lessons/lessons.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialExampleModule } from 'material.module';
import { ModifyPasswordComponent } from './account/modify-password/modify-password.component';
import { PersonalDataComponent } from './account/personal-data/personal-data.component';
import { EditComponent } from './account/edit/edit.component';
import { UploadComponent } from './account/upload/upload.component';
import { LoginComponentComponent } from './login/login-component.component';
import { MainAppComponent } from './main-app/main-app.component';



@NgModule({
  declarations: [
    AppComponent,
    SchedulComponent,
    AccountComponent,
    PaymentsComponent,
    ReviewsComponent,
    LessonsComponent,
    ModifyPasswordComponent,
    PersonalDataComponent,
    EditComponent,
    UploadComponent,
    LoginComponentComponent,
    MainAppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialExampleModule,
    RouterModule.forRoot([
      { path: 'main', redirectTo: 'main/account/personal-data'},
      { path: 'main/account', redirectTo: 'main/account/personal-data'},
      {
        path: 'main', component: MainAppComponent,
        children: [
        { 
          path: 'account', component: AccountComponent,
          children: [
            { path: 'personal-data', component: PersonalDataComponent},
            { path: 'edit', component: EditComponent},
            { path: 'upload', component: UploadComponent},
            { path: 'change-password', component: ModifyPasswordComponent},
          ]
        },
        { path: 'lessons', component: LessonsComponent},
        { path: 'practice', component: SchedulComponent},
        { path: 'payments', component: PaymentsComponent },
        { path: 'reviews', component: ReviewsComponent},
        ]
      },
      { path: 'login', component: LoginComponentComponent},
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

