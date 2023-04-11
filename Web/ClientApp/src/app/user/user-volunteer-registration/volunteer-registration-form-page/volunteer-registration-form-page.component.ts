import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Volunteer } from '../../../volunteer/volunteer.model';
import { VolunteerService } from '../../../volunteer/volunteer.service';
import { VolunteerType } from '../../../volunteer/volunteerType.model';

@Component({
  selector: 'app-volunteer-registration-form-page',
  templateUrl: './volunteer-registration-form-page.component.html',
  styleUrls: ['./volunteer-registration-form-page.component.scss']
})
export class VolunteerRegistrationFormPageComponent implements OnInit {
  gamemonitor = new VolunteerType('gamemonitor', 1);
  clockmanager = new VolunteerType('clockmanager', 2);
  registration = new VolunteerType('registration', 3);
  raffle = new VolunteerType('raffle', 4);
  setup = new VolunteerType('setup', 5);
  takedown = new VolunteerType('takedown', 6);

  volunteerRegistrationForm: FormGroup;
  volunteer: Volunteer;
  noRoleSelected: boolean;

  constructor(private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private volunteerService: VolunteerService) { }

  ngOnInit() {
    window.scrollTo(0,0);
    this.volunteer = new Volunteer;
    this.volunteerRegistrationForm = this.createNewFormGroup();
    this.noRoleSelected = false;
  }

  onRegister() {
    if (this.validateForm()) {
      this.transformFormToVolunteerModel(this.volunteer, this.volunteerRegistrationForm);
      this.volunteerService.registerVolunteer(this.volunteer)
      .subscribe({
        next: (data:any) => {
          this.volunteer = data;
          console.log(this.volunteer);

        },
        error: error => {
          console.error(error)
        }
      });
    }
  }

  private transformFormToVolunteerModel(volunteer: Volunteer, form: FormGroup) {

    var roles = new Array<number>();

    volunteer.firstName = form.controls['first-name'].value;
    volunteer.lastName = form.controls['last-name'].value;
    volunteer.email = form.controls['email'].value;
    volunteer.phoneNumber = form.controls['phone'].value;
    volunteer.tshirtSize = form.controls['tshirtSize'].value;

    for (const ctrl in form.controls) {
      console.log(form.controls[ctrl].value)
      if (form.controls[ctrl].value == true) {
        roles.push(this.getId(ctrl));
      }
    }
    volunteer.volunteerType = roles;
  }

  private getId(key: string): number {
    if(key.match(this.gamemonitor.title)) {
        return this.gamemonitor.id;
    }
    if(key.match(this.clockmanager.title)) {
        return this.clockmanager.id;
    }
    if(key.match(this.registration.title)) {
        return this.registration.id;
    }
    if(key.match(this.raffle.title)) {
        return this.raffle.id;
    }
    if(key.match(this.setup.title)) {
        return this.setup.id;
    }
    if(key.match(this.takedown.title)) {
        return this.takedown.id;
    }
    return 0;
}

  private createNewFormGroup() {
    return new FormGroup({
      'first-name': new FormControl(null, Validators.required),
      'last-name': new FormControl(null, Validators.required),
      'email': new FormControl(null, Validators.required),
      'phone': new FormControl(null, Validators.required),
      'tshirtSize': new FormControl(null, Validators.required),
      'gamemonitor': new FormControl(null),
      'registration': new FormControl(null),
      'clockmanager': new FormControl(null),
      'raffle': new FormControl(null),
      'setup': new FormControl(null),
      'takedown': new FormControl(null)
    })
  }

  private validateForm(): boolean{
    if(this.volunteerRegistrationForm.valid && this.hasOneRoleSelected(this.volunteerRegistrationForm)) {
      return true;
    } else {
      for (const ctrl in this.volunteerRegistrationForm.controls) {
        if (this.volunteerRegistrationForm.controls.hasOwnProperty(ctrl)) {
          this.volunteerRegistrationForm.controls[ctrl].markAsDirty();
        }
      }
      return false;
    }
  }

  private hasOneRoleSelected(form: FormGroup): boolean {
    var roleSelected = false;
    for (const ctrl in form.controls) {
      if (form.controls[ctrl].value == true)
      roleSelected = true;
    }
    if (roleSelected) {
      this.noRoleSelected = false;
    } else {
      this.noRoleSelected = true;
    }
    return roleSelected;
  }

  reset() {
    this.volunteerRegistrationForm.reset();
  }
  

}
