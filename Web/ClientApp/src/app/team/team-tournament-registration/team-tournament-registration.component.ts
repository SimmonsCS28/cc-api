import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup,  FormControl, Validators } from '@angular/forms';
import { Team } from '../team.model';
import { ActivatedRoute, Router } from '@angular/router';
import { TeamService } from '../team.service';
import { User } from 'src/app/user/user.model';

@Component({
  selector: 'app-team-tournament-registration',
  templateUrl: './team-tournament-registration.component.html',
  styleUrls: ['./team-tournament-registration.component.scss']
})
export class TeamTournamentRegistrationComponent implements OnInit {

  @ViewChild('pay-later-submit', {static: false}) registerLater: ElementRef;

  teamRegistrationForm: FormGroup;
  paymentTerm: string;

  team: Team;

  constructor(
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private teamService: TeamService
  ) { }

  ngOnInit() {
    window.scrollTo(0,0);
    this.team = new Team();
    this.teamRegistrationForm = this.createNewFormGroup(this.team);
    this.paymentTerm = '';
  }

  onRegister() {
    if(this.validateForm()) {
      this.transformFormToTeamModel(this.team, this.teamRegistrationForm);
      this.teamService.registerTeam(this.team)
      .subscribe({
        next: (data:any) => {
          this.team = data;
          console.log(this.team);
          if(this.paymentTerm == 'PaidUponRegistering') {
            this.externalPayPalRedirect();
          }
          this.router.navigate(['/team', this.team.teamId]);
        },
        error: error => {
          //TODO Add alert service here for when there's a problem registering the team. 
          console.error(error)
        }
      });
    }
  }

  private transformFormToTeamModel(team: Team, form: FormGroup) {
    var teamCaptain: User = new User();
    var players = new Array<User>();
    

    team.teamName = form.controls['team-name'].value;

    teamCaptain.firstName = form.controls['team-captain-first-name'].value;
    teamCaptain.lastName = form.controls['team-captain-last-name'].value;
    teamCaptain.email = form.controls['team-captain-email'].value;
    team.teamCaptain = teamCaptain;

    var user2: User = new User();
    user2.firstName = form.controls['player2-first-name'].value;
    user2.lastName = form.controls['player2-last-name'].value;
    user2.email = form.controls['player2-email'].value;
    players.push(user2);


    var user3: User = new User();
    user3.firstName = form.controls['player3-first-name'].value;
    user3.lastName = form.controls['player3-last-name'].value;
    user3.email = form.controls['player3-email'].value;
    players.push(user3);

    var user4: User = new User();
    user4.firstName = form.controls['player4-first-name'].value;
    user4.lastName = form.controls['player4-last-name'].value;
    user4.email = form.controls['player4-email'].value;
    players.push(user4);

    var user5: User = new User();
    user5.firstName = form.controls['player5-first-name'].value;
    user5.lastName = form.controls['player5-last-name'].value;
    user5.email = form.controls['player5-email'].value;
    players.push(user5);

    if (form.controls['player6-first-name'].value &&
        form.controls['player6-last-name'].value &&
        form.controls['player6-last-name'].value) {
          var user6: User = new User();
          user6.firstName = form.controls['player6-first-name'].value;
          user6.lastName = form.controls['player6-last-name'].value;
          user6.email = form.controls['player6-email'].value;
          players.push(user6);
    }
    
    if (form.controls['player7-first-name'].value &&
        form.controls['player7-last-name'].value &&
        form.controls['player7-email'].value) {
          var user7: User = new User();
          user7.firstName = form.controls['player7-first-name'].value;
          user7.lastName = form.controls['player7-last-name'].value;
          user7.email = form.controls['player7-email'].value;
          players.push(user7);
    }

    team.players = players;
    team.paymentTerm = this.paymentTerm;
  }

  private validateForm() :boolean {
    if(this.teamRegistrationForm.valid) {
      return true;
    } else {
      for (const ctrl in this.teamRegistrationForm.controls) {
        if (this.teamRegistrationForm.controls.hasOwnProperty(ctrl)) {
          this.teamRegistrationForm.controls[ctrl].markAsDirty();
        }
      }
      return false;
    }
  }

  setPaymentTermPayLater(): void {
    this.paymentTerm = 'PayLater';
  }

  setPaymentTermPaidUponRegistering(): void {
    this.paymentTerm = 'PaidUponRegistering';
  }

  private createNewFormGroup(team: Team): FormGroup {
    return new FormGroup({
      'team-name': new FormControl(null, Validators.required),
      'team-captain-first-name': new FormControl(null, Validators.required),
      'team-captain-last-name': new FormControl(null, Validators.required),
      'team-captain-email': new FormControl(null, [Validators.required, Validators.email]),
      'player2-first-name': new FormControl(null),
      'player2-last-name': new FormControl(null),
      'player2-email': new FormControl(null, [Validators.required, Validators.email]),
      'player3-first-name': new FormControl(null),
      'player3-last-name': new FormControl(null),
      'player3-email': new FormControl(null, [Validators.required, Validators.email]),
      'player4-first-name': new FormControl(null),
      'player4-last-name': new FormControl(null),
      'player4-email': new FormControl(null, [Validators.required, Validators.email]),
      'player5-first-name': new FormControl(null),
      'player5-last-name': new FormControl(null),
      'player5-email': new FormControl(null, [Validators.required, Validators.email]),
      'player6-first-name': new FormControl(null),
      'player6-last-name': new FormControl(null),
      'player6-email': new FormControl(null, [Validators.email]),
      'player7-first-name': new FormControl(null),
      'player7-last-name': new FormControl(null),
      'player7-email': new FormControl(null, [Validators.email]),
    })
  }

  private externalPayPalRedirect() {
    window.open('https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=VMVY6WHE56Y5Q', '_blank');
  }

  reset() {
    this.teamRegistrationForm.reset();
  }

}
