import { Component, OnInit } from '@angular/core';
import { TeamService } from './team.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Team } from './team.model';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {

  teamName: string = '';
  team: Team;
  teamId: number;


  constructor(
    private readonly router: Router,
    private route: ActivatedRoute,
    private teamService: TeamService) {
     }
  

  ngOnInit() {
    this.team = new Team();
    this.route.paramMap.subscribe(params => {
      let id = params.get('id');
      this.teamId = +id;
    });

    this.teamService.getTeam(this.teamId).subscribe({
      next: (data:any) => {
        this.team = data;
        this.teamName = this.team.teamName;
        console.log(this.team);
      },
      error: error => {
        //TODO Add alert service here for when there's a problem registering the team. 
        console.error(error)
      }
    });
  }

}
