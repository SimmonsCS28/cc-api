import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserVolunteerRegistrationComponent } from './user-volunteer-registration.component';

describe('UserVolunteerRegistrationComponent', () => {
  let component: UserVolunteerRegistrationComponent;
  let fixture: ComponentFixture<UserVolunteerRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserVolunteerRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserVolunteerRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
