import { Injectable } from '@angular/core';
import { Response } from '@angular/http';

import { DataService } from '../shared/services/data.service';

import { IContact, ContactType } from '../shared/model/contact.model';
import { IContactList } from '../shared/model/contactList.model';

import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';

@Injectable()
export class ContactService{
    private contactApiUrl = 'http://localhost:5000';
    private contactList = '';
    private contactCostumer = '';
    private contactSupplier = '';

    constructor(private service: DataService){
        this.contactList = this.contactApiUrl +  '/api/v1/contacts/items';
        this.contactCostumer = this.contactApiUrl + '/api/v1/costumers';
        this.contactSupplier = this.contactApiUrl + '/api/v1/Suppliers';
    }

    getContactList(pageIndex: number, pageSize: number): Observable<IContactList>{
        let url = this.contactList;

        url = url + '?pageIndex=' + pageIndex + '&pageSize=' + pageSize;

        return this.service.get(url).map((res:Response)=>{return res.json()});
    }

    addCostumer(contact:IContact): Observable<IContact>{
        
        contact.contactType = ContactType.Costumer;

        return this.service.post(this.contactCostumer, contact)
        .map((res:Response) =>{ return res.json()});
    }

    addSupplier(contact:IContact): Observable<IContact>{
        
        contact.contactType = ContactType.Supplier;

        return this.service.post(this.contactSupplier, contact)
        .map((res:Response) =>{ return res.json()});
    }

    removeContact(contact:IContact){
        if(contact.contactType == 1){
            this.service.delete(this.contactCostumer + '/' + contact.id.toString());
        }

        this.service.delete(this.contactSupplier + '/' + contact.id.toString());
    }
}