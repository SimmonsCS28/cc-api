import { NgModule, Optional, SkipSelf } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { RouterModule } from '@angular/router';
import { throwIfAlreadyLoaded} from '../../../module-import-guard';
import { VolunteerRegistrationFormPageComponent } from "./volunteer-registration-form-page.component";

@NgModule({
    imports: [RouterModule],
    declarations: [VolunteerRegistrationFormPageComponent]
})

export class VolunteerRegistrationFormPageModule {

    teamRegistrationForm: FormGroup;

    constructor(@Optional() @SkipSelf() parentModule: VolunteerRegistrationFormPageModule) {
        throwIfAlreadyLoaded(parentModule, 'VolunteerRegistrationFormPageModule');
    }
}