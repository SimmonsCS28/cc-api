import { NgModule, Optional, SkipSelf } from "@angular/core";
import { RouterModule } from '@angular/router';
import { throwIfAlreadyLoaded} from '../../module-import-guard';
import { VolunteerRegistrationFormPageComponent } from './volunteer-registration-form-page/volunteer-registration-form-page.component'

@NgModule({
    imports: [RouterModule],
    declarations: [VolunteerRegistrationFormPageComponent]
})

export class UserVolunteerRegistrationModule {
    constructor(@Optional() @SkipSelf() parentModule: UserVolunteerRegistrationModule) {
        throwIfAlreadyLoaded(parentModule, 'UserVolunteerRegistrationModule');
    }
}