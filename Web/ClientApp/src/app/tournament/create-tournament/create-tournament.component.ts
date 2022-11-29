import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Tournament } from '../tournament.model';
import { TournamentService } from '../tournament.service';

@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.scss']
})
export class CreateTournamentComponent implements OnInit {

  createTournamentForm: FormGroup;
  tournament: Tournament;

  constructor(
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private tournamentService: TournamentService
  ) { }

  ngOnInit() {
    window.scrollTo(0,0);
    this.tournament = new Tournament;
  }

}
