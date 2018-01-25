import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { SharedModule } from '../shared/shared.module';
import { ContactComponent } from '../contact/contact.component';
import { ContactService } from '../contact/contact.service';
import { Pager } from '../shared/component/pager/pager';
import { CostumerFormComponent, SupplierFormComponent } from '../shared/component/contactForm/contactForm.component';

@NgModule({
    imports: [BrowserModule, SharedModule],
    declarations: [ContactComponent, CostumerFormComponent, SupplierFormComponent],
    providers: [ContactService],
    entryComponents: [
        CostumerFormComponent, SupplierFormComponent
    ]
})
export class ContactModule{
    
}