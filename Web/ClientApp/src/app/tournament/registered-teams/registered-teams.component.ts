import { Component, OnInit } from '@angular/core';
import { Team } from 'src/app/team/team.model';
import { TeamService } from 'src/app/team/team.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registered-teams',
  templateUrl: './registered-teams.component.html',
  styleUrls: ['./registered-teams.component.scss']
})
export class RegisteredTeamsComponent implements OnInit {

  teams: Array<Team>;

  constructor(
    private readonly router: Router,
    private teamService: TeamService
  ) { }

  ngOnInit() {
    this.teamService.getAllTeams().subscribe({
      next: (data:any) => {
        this.teams = data;
        console.log(this.teams);
      },
      error: error => {
        //TODO Add alert service here for when there's a problem registering the team. 
        console.error(error)
      }
    });
  }

}
