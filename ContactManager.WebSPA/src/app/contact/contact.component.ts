import { Component, OnInit, ViewContainerRef, ComponentRef } from '@angular/core';

import { IPager } from '../shared/model/pager.model';
import { IContactList } from '../shared/model/contactList.model';
import { IContact, ContactType } from '../shared/model/contact.model';
import { ContactService } from './contact.service';
import { Observable } from 'rxjs/Observable';
import { CostumerFormComponent, SupplierFormComponent } from '../shared/component/contactForm/contactForm.component';
import { DialogService } from 'ngx-bootstrap-modal';
import { ContentType } from '@angular/http/src/enums';
import { Contact } from '../shared/model/contact';
import { error } from 'selenium-webdriver';

@Component({
    selector: 'test-contact .test-contact',
    styleUrls: ['./contact.component.scss'],
    templateUrl: './contact.component.html'
})
export class ContactComponent implements OnInit{
    
    contactList:IContactList;
    paginationInfo:IPager;
    errorReceived:boolean;

    constructor(private service: ContactService, private dialogService: DialogService){
        
    }

    ngOnInit(){
        this.getContactList(15, 0);
    }

    getContactList(pageSize:number, pageIndex:number){
        this.errorReceived = false;

        this.service.getContactList(pageIndex, pageSize)
        .catch((error)=> this.handleError(error))
        .subscribe(list => {
            this.contactList = list;
            this.paginationInfo = {
                actualPage : list.pageIndex,
                itemsPage : list.pageSize,
                totalItems : list.count,
                totalPages : Math.ceil((list.count / list.pageSize)),
                items : list.pageSize
            };
        });
    }

    addCostumer(){
        this.dialogService.addDialog(CostumerFormComponent,{
            title: "Add a Costumer",
            question: ""
        }).subscribe((newCostumer)=>{
            this.service.addCostumer(newCostumer)
                .catch((error)=> this.handleError(error));
        });
    }

    editCostumer(costumer:any){
        this.dialogService.addDialog(CostumerFormComponent,{
            title: "Edit a Costumer",
            contact : costumer
        }).subscribe((supplier)=>{
            this.service.addSupplier(supplier).subscribe(res => {
            });     
        });
    }

    addSupplier(){
        this.dialogService.addDialog(SupplierFormComponent,{
            title: "Add a Supplier",
            question: ""
        }).subscribe((supplier)=>{
            this.service.addSupplier(supplier).subscribe(res => {
            });     
        });
    }

    editSupplier(supplier:any){
        this.dialogService.addDialog(SupplierFormComponent,{
            title: "Edit a Supplier",
            contact : supplier
        }).subscribe((supplier)=>{
            this.service.addSupplier(supplier).subscribe(res => {
            });     
        });
    }

    removeContact(contact:any){
        this.service.removeContact(contact);
    }
    

    onPageChanged(value: any) {
        console.log('catalog pager event fired' + value);
        event.preventDefault();
        this.paginationInfo.actualPage = value;
        this.getContactList(this.paginationInfo.itemsPage, value);
    }

    private handleError(error: any){
        this.errorReceived = true;
        return Observable.throw(error);
    }
}
