import { Component } from '@angular/core';
import { DialogComponent } from 'ngx-bootstrap-modal';
import { IContact, ContactType } from '../../model/contact.model';
import { Contact } from '../../model/contact';
import { concat } from 'rxjs/observable/concat';

export interface PromptModel {
  title: string;
  contact:Contact;
}

@Component({
  selector: 'prompt',
  templateUrl: './costumerForm.component.html',
  styleUrls: ['./contactForm.component.css'],
})
export class CostumerFormComponent extends DialogComponent<PromptModel, any> implements PromptModel {
  title: string;
  contact: Contact = new Contact();

  // submitted = false;

  // onSubmit(){
  //   this.submitted = true;
  //   console.log(this.contact);
  // }

  apply() {
    this.result = this.contact;
    this.close();
  }
}

@Component({
  selector: 'prompt',
  templateUrl: './supplierForm.component.html',
  styleUrls: ['./contactForm.component.css'],
})
export class SupplierFormComponent extends DialogComponent<PromptModel, any> implements PromptModel {
  title: string;
  contact: Contact = new Contact();

  apply() {
    this.contact.birthDate = null;
    this.result = this.contact;
    this.close();
  }
}