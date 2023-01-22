import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VolunteerRegistrationFormPageComponent } from './volunteer-registration-form-page.component';

describe('VolunteerRegistrationFormPageComponent', () => {
  let component: VolunteerRegistrationFormPageComponent;
  let fixture: ComponentFixture<VolunteerRegistrationFormPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VolunteerRegistrationFormPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VolunteerRegistrationFormPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
