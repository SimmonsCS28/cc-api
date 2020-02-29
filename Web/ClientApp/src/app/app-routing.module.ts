import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { HomeComponent } from './home/home.component';
import { TeamTournamentRegistrationComponent } from './team/team-tournament-registration/team-tournament-registration.component';
import { UserVolunteerRegistrationComponent } from './user/user-volunteer-registration/user-volunteer-registration.component';
import { UserRegistrationComponent } from './user/user-registration/user-registration.component';
import { TeamComponent } from './team/team.component';
import { TournamentComponent } from './tournament/tournament.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: 'team',
    component: TeamComponent
  },
  {
    path: 'team/:id',
    component: TeamComponent
  },
  {
    path: 'team-registration',
    component: TeamTournamentRegistrationComponent
  },
  {
    path: 'tournament',
    component: TournamentComponent
  },
  {
    path: 'user-registration',
    component: UserRegistrationComponent
  },
  {
    path: 'volunteer-registration',
    component: UserVolunteerRegistrationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
