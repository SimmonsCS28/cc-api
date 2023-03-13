import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-volunteer-registration-form-page',
  templateUrl: './volunteer-registration-form-page.component.html',
  styleUrls: ['./volunteer-registration-form-page.component.scss']
})
export class VolunteerRegistrationFormPageComponent implements OnInit {

  volunteerRegistrationForm: FormGroup;

  constructor(private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router) { }

  ngOnInit() {
    window.scrollTo(0,0);
  }
  

}
