import { IContact } from './contact.model';

export interface IContactList {
    pageIndex:number;
    data: IContact[];
    pageSize:number;
    count:number;
}