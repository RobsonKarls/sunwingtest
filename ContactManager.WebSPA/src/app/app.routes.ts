import { Routes, RouterModule } from '@angular/router';
import { ContactComponent } from './contact/contact.component';

export const routes: Routes =[
    { path: '', redirectTo: 'contact', pathMatch: 'full'},
    { path: 'contact', component: ContactComponent }
];
export const routing = RouterModule.forRoot(routes);