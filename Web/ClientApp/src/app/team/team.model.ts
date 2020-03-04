import { User } from '../user/user.model';


export class Team {

    teamId?: number = null;
    teamName: string = null;
    captainUser: User = null;
    users: User[] = null;
    paymentTerm: string = null;
    paymentMethod?: string = null;
    paymentDate?: Date = null;
}
