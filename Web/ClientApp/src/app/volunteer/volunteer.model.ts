export class Volunteer {

    userId?: number = null;
    firstName: string = null;
    lastName: string = null;
    phoneNumber: number = null;
    email: string = null;
    tshirtSize?: string = null
    volunteerType: number[] = null;

    public constructor(original: Volunteer = null) {
        Object.assign(this, original)
    }
}