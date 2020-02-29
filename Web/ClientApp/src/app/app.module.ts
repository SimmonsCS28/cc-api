import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AboutComponent } from './about/about.component';
import { HomeComponent } from './home/home.component';
import { TeamComponent } from './team/team.component';
import { UserComponent } from './user/user.component';
import { UserRegistrationComponent } from './user/user-registration/user-registration.component';
import { TeamTournamentRegistrationComponent } from './team/team-tournament-registration/team-tournament-registration.component';
import { HttpComponent } from './http/http.component';
import { UserVolunteerRegistrationComponent } from './user/user-volunteer-registration/user-volunteer-registration.component';
import { RouterModule } from '@angular/router';
import { TournamentComponent } from './tournament/tournament.component';

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    HomeComponent,
    TeamComponent,
    UserComponent,
    UserRegistrationComponent,
    TeamTournamentRegistrationComponent,
    HttpComponent,
    UserVolunteerRegistrationComponent,
    TournamentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
