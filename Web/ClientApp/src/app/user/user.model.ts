export class User {

    userId?: number = null;
    firstName: string = null;
    lastName: string = null;
    email: string = null;
    phoneNumber?: string = null;
    tshirtSize?: string = null;

    public constructor(original: User = null) {
        Object.assign(this, original);
    }
}
