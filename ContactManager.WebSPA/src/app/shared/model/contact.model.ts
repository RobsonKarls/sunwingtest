export enum ContactType{
    Supplier = 0,
    Costumer = 1
}

export interface IContact{
    id:number;
    firsName:string;
    lastName:string;
    contactType:ContactType;
    telephone:string;
    email:string;
    birthDate:Date;
}