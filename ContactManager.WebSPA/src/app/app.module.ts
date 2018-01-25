import { NgModule, NgModuleFactoryLoader }       from '@angular/core';
import { BrowserModule  } from '@angular/platform-browser';
// import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import {FormsModule} from '@angular/forms'



import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { routing } from './app.routes';
import { AppService } from './app.service';
import { ContactModule } from './contact/contact.module';
import { CostumerFormComponent, SupplierFormComponent } from './shared/component/contactForm/contactForm.component';

import { BootstrapModalModule, BuiltInOptions } from 'ngx-bootstrap-modal';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    routing,
    SharedModule.forRoot(),
    ContactModule,
    BrowserModule,
    BootstrapModalModule.forRoot({
      container: document.body,
      builtInOptions: <BuiltInOptions>{
      }
  })
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
