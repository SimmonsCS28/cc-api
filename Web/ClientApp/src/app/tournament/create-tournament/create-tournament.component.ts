import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
    this.createTournamentForm = this.createNewFormGroup()
  }

  onCreate() {
    if(this.validateForm()) {
      this.transformFormToTournamentModel(this.tournament, this.createTournamentForm)
      this.tournamentService.createNewTournament(this.tournament)
      .subscribe({
        next: (data:any) => {
          this.tournament = data;
          console.log(this.tournament);

        },
        error: error => console.error(error)
      });
    }
  }

  private transformFormToTournamentModel(tournament: Tournament, form: FormGroup) {

    tournament.maxTeams = form.controls["number-of-teams"].value;
    tournament.fee = form.controls["registration-fee"].value;
    tournament.startDate = form.controls["start-date"].value;
    var tLength: number;
    tLength = form.controls["end-date"].value;
    while (tLength > 0) {
      tournament.endDate.setDate(tournament.startDate.getDate() + 1)
      tLength--;
    }
  
    return tournament
  }

  private validateForm() :boolean {
    if(this.createTournamentForm.valid) {
      return true;
    } else {
      for (const ctrl in this.createTournamentForm.controls) {
        if (this.createTournamentForm.controls.hasOwnProperty(ctrl)) {
          this.createTournamentForm.controls[ctrl].markAsDirty();
        }
      }
      return false;
    }
  }

  private createNewFormGroup(): FormGroup {
    return new FormGroup({
      'number-of-teams': new FormControl(null, Validators.required),
      'registration-fee': new FormControl(null, Validators.required),
      'start-date': new FormControl(null, [Validators.required, Validators.email]),
      'tounament-length': new FormControl(null),
      'current-active': new FormControl(null)
    })
  }

  reset(){
    this.createTournamentForm.reset();
  }

}
