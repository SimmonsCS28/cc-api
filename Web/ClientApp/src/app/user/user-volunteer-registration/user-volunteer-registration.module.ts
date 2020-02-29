import { NgModule, Optional, SkipSelf } from "@angular/core";
import { RouterModule } from '@angular/router';
import { throwIfAlreadyLoaded} from '../../module-import-guard'

@NgModule({
    imports: [RouterModule]
})

export class UserVolunteerRegistrationModule {
    constructor(@Optional() @SkipSelf() parentModule: UserVolunteerRegistrationModule) {
        throwIfAlreadyLoaded(parentModule, 'UserVolunteerRegistrationModule');
    }
}