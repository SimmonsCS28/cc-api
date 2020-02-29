import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamTournamentRegistrationComponent } from './team-tournament-registration.component';

describe('TeamTournamentRegistrationComponent', () => {
  let component: TeamTournamentRegistrationComponent;
  let fixture: ComponentFixture<TeamTournamentRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamTournamentRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamTournamentRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
