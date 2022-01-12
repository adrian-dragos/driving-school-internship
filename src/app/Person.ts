export class Person {
    email: string;
    id: number;
    firstName: string
    lastName: string;
    phoneNumber: string;
    birthday: Date;
    gearType: string;

    constructor(email : string, id : number, firstName : string, lastName : string, phoneNumber : string, birthday : Date, gearType: string) { 
        this.email = email; 
        this.id = id; 
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.birthday = birthday;
        this.gearType = gearType;
    }
}
