import { Component, OnInit } from '@angular/core';
import { Team } from 'src/app/team/team.model';
import { User } from 'src/app/user/user.model'
import { TeamService } from 'src/app/team/team.service';
import { Router } from '@angular/router';
import { TournamentService } from '../tournament.service';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-registered-teams',
  templateUrl: './registered-teams.component.html',
  styleUrls: ['./registered-teams.component.scss']
})
export class RegisteredTeamsComponent implements OnInit {

  teams: Array<Team>;
  teamSkatersViewString: string;

  constructor(
    private readonly router: Router,
    private teamService: TeamService,
    private tournamentService: TournamentService
  ) { }

  ngOnInit() {
    this.tournamentService.getCurrentTournamentRegisteredTeams().subscribe({
      next: (data:any) => {
        this.teams = data;
        this.formatTeams(this.teams)
        console.log(this.teams);
      },
      error: error => {
        //TODO Add alert service here for when there's a problem registering the team. 
        console.error(error)
        throwError("There was an issue retrieving all the teams. Error: " + error);
      }
    });
  }

  formatTeams(tournamentTeams: Array<Team>) {
    if(tournamentTeams.length != 0) {
      tournamentTeams.forEach(team => {
        var captainIndexLocation = team.users.indexOf(team.users.find(e => e.userId = team.captainUser.userId));
        if (captainIndexLocation > -1) {
          team.users.splice(captainIndexLocation, 1);
       }
       this.formatTeamSkatersView(team.users);
      });
    }
  }

  formatTeamSkatersView(teamUsers: Array<User>) {
    var concatedString = "";
    teamUsers.forEach(user => {
      concatedString = concatedString.concat(user.firstName + " " + user.lastName +", ");
      
    });
    concatedString = concatedString.substring(0, concatedString.length-2);
    this.teamSkatersViewString = concatedString;
  }

}
